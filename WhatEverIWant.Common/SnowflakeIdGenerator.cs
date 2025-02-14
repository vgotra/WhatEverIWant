using System;
using System.Threading;

public class SnowflakeIdGenerator
{
    private readonly long epoch = 1609459200000L;
    private readonly int workerIdBits = 5;
    private readonly int datacenterIdBits = 5;
    private readonly int sequenceBits = 12;

    private readonly long maxWorkerId = (1L << 5) - 1;      // Max worker ID (31)
    private readonly long maxDatacenterId = (1L << 5) - 1;  // Max datacenter ID (31)
    private readonly long sequenceMask = (1L << 12) - 1;    // Max sequence number (4095)

    private long lastTimestamp = -1L;
    private long sequence = 0L;

    private readonly SpinLock spinLock = new SpinLock(false);

    public long WorkerId { get; }
    public long DatacenterId { get; }

    public SnowflakeIdGenerator(long workerId, long datacenterId)
    {
        if (workerId > maxWorkerId || workerId < 0)
            throw new ArgumentException($"Worker ID must be between 0 and {maxWorkerId}");

        if (datacenterId > maxDatacenterId || datacenterId < 0)
            throw new ArgumentException($"Datacenter ID must be between 0 and {maxDatacenterId}");

        WorkerId = workerId;
        DatacenterId = datacenterId;
    }

    public long NextId()
    {
        bool lockTaken = false;
        try
        {
            spinLock.Enter(ref lockTaken);

            long timestamp = GetCurrentTimestamp();

            if (timestamp < lastTimestamp)
            {
                throw new Exception("Clock moved backwards. Refusing to generate ID.");
            }

            if (timestamp == lastTimestamp)
            {
                sequence = (sequence + 1) & sequenceMask;
                if (sequence == 0) // Sequence overflow, wait for next millisecond
                {
                    timestamp = WaitForNextMillis(lastTimestamp);
                }
            }
            else
            {
                sequence = 0;
            }

            lastTimestamp = timestamp;

            return ((timestamp - epoch) << (workerIdBits + datacenterIdBits + sequenceBits))
                   | (DatacenterId << (workerIdBits + sequenceBits))
                   | (WorkerId << sequenceBits)
                   | sequence;
        }
        finally
        {
            if (lockTaken)
            {
                spinLock.Exit();
            }
        }
    }

    private long GetCurrentTimestamp()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    private long WaitForNextMillis(long lastTimestamp)
    {
        long timestamp = GetCurrentTimestamp();
        while (timestamp <= lastTimestamp)
        {
            timestamp = GetCurrentTimestamp();
        }
        return timestamp;
    }
}
