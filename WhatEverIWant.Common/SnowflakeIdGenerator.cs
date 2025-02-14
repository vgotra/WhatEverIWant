namespace WhatEverIWant.Common;

public class SnowflakeIdGenerator : ISnowflakeIdGenerator
{
    private const long Epoch = 1609459200000L; // Jan 01 2021 00:00:00 UTC
    private const int WorkerIdBits = 5;
    private const int DatacenterIdBits = 5;
    private const int SequenceBits = 12;
    private const long SequenceMask = (1L << 12) - 1;    // Max sequence number (4095)

    private const long WorkerId = 1;
    private const long DatacenterId = 1;

    private long _lastTimestamp = -1L;
    private long _sequence = 0L;
    
    private SpinLock _spinLock = new(false);

    public long NextId()
    {
        //TODO Check it later
        var lockTaken = false;
        try
        {
            _spinLock.Enter(ref lockTaken);

            var timestamp = GetCurrentTimestamp();
            if (timestamp < _lastTimestamp)
                throw new InvalidOperationException("Clock moved backwards. Refusing to generate ID.");

            if (timestamp == _lastTimestamp)
            {
                _sequence = (_sequence + 1) & SequenceMask;
                if (_sequence == 0) // Sequence overflow, wait for next millisecond
                    timestamp = WaitForNextMilliseconds(_lastTimestamp);
            }
            else
            {
                _sequence = 0;
            }

            _lastTimestamp = timestamp;

            return ((timestamp - Epoch) << (WorkerIdBits + DatacenterIdBits + SequenceBits))
                   | (DatacenterId << (WorkerIdBits + SequenceBits))
                   | (WorkerId << SequenceBits)
                   | _sequence;
        }
        finally
        {
            if (lockTaken) 
                _spinLock.Exit();
        }
    }

    private static long GetCurrentTimestamp() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    private static long WaitForNextMilliseconds(long lastTimestamp)
    {
        var timestamp = GetCurrentTimestamp();
        while (timestamp <= lastTimestamp) 
            timestamp = GetCurrentTimestamp();
        return timestamp;
    }
}