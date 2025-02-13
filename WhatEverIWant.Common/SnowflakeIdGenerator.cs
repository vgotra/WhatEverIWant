namespace WhatEverIWant.Common;

public class SnowflakeIdGenerator : ISnowflakeIdGenerator
{
    private const long Epoch = 1609459200000L; // Jan 1, 2021
    private const int WorkerIdBits = 5;
    private const int DatacenterIdBits = 5;
    private const int SequenceBits = 12;

    private const long WorkerId = 1L;
    private const long DatacenterId = 1L;
    private const long SequenceMask = (1L << SequenceBits) - 1L;

    private long _lastTimestamp = -1L;
    private long _sequence = 0L;

    private SpinLock _spinLock = new(false);

    public long NextId()
    {
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
                if (_sequence == 0)
                    timestamp = WaitForNextMillisecond(_lastTimestamp);
            }
            else
            {
                _sequence = 0;
            }

            _lastTimestamp = timestamp;
            return ((timestamp - Epoch) << (WorkerIdBits + DatacenterIdBits + SequenceBits)) |
                   (DatacenterId << (WorkerIdBits + SequenceBits)) |
                   (WorkerId << SequenceBits) |
                   _sequence;
        }
        finally
        {
            if (lockTaken)
                _spinLock.Exit();
        }
    }

    private static long GetCurrentTimestamp() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    private static long WaitForNextMillisecond(long lastTimestamp)
    {
        var timestamp = GetCurrentTimestamp();
        while (timestamp <= lastTimestamp)
            timestamp = GetCurrentTimestamp();
        return timestamp;
    }
}