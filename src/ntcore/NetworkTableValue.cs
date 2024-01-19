using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using NetworkTables.Natives;
using WPIUtil.Marshal;

namespace NetworkTables;

[NativeMarshalling(typeof(NetworkTableValueMarshaller))]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct NetworkTableValue : INativeArrayFree<NetworkTableValueMarshaller.NativeNetworkTableValue>, INativeFree<NetworkTableValueMarshaller.NativeNetworkTableValue>
{
    public static unsafe void Free(NetworkTableValueMarshaller.NativeNetworkTableValue* ptr)
    {
        NtCore.DisposeValue(ptr);
    }

    public static unsafe void FreeArray(NetworkTableValueMarshaller.NativeNetworkTableValue* ptr, int len)
    {
        NtCore.DisposeValueArray(ptr, (nuint)len);
    }

    internal NetworkTableValue(NetworkTableType type, object? obj, long time, long serverTime)
    {
        Type = type;
        Time = time;
        ServerTime = serverTime;
        m_objectValue = obj;
    }

    internal NetworkTableValue(NetworkTableType type, bool value) : this(type, null, NtCore.Now(), 1)
    {
        m_structValue = new(value);
    }

    internal NetworkTableValue(NetworkTableType type, long value) : this(type, null, NtCore.Now(), 1)
    {
        m_structValue = new(value);
    }

    internal NetworkTableValue(NetworkTableType type, float value) : this(type, null, NtCore.Now(), 1)
    {
        m_structValue = new(value);
    }

    internal NetworkTableValue(NetworkTableType type, double value) : this(type, null, NtCore.Now(), 1)
    {
        m_structValue = new(value);
    }

    internal NetworkTableValue(NetworkTableType type, object value) : this(type, value, NtCore.Now(), 1) { }

    internal NetworkTableValue(NetworkTableType type, bool value, long time) : this(type, null, time, 1)
    {
        m_structValue = new(value);
    }

    internal NetworkTableValue(NetworkTableType type, long value, long time) : this(type, null, time, 1)
    {
        m_structValue = new(value);
    }

    internal NetworkTableValue(NetworkTableType type, float value, long time) : this(type, null, time, 1)
    {
        m_structValue = new(value);
    }

    internal NetworkTableValue(NetworkTableType type, double value, long time) : this(type, null, time, 1)
    {
        m_structValue = new(value);
    }

    internal NetworkTableValue(NetworkTableType type, object value, long time) : this(type, value, time, 1)
    {
    }

    /**
 * Get the creation time of the value in local time.
 *
 * @return The time, in the units returned by NtCore.Now().
 */
    public long Time { get; }

    /**
     * Get the creation time of the value in server time.
     *
     * @return The server time.
     */
    public long ServerTime { get; }

    /*
     * Type Checkers
     */

    /**
     * Determine if entry value contains a value or is unassigned.
     *
     * @return True if the entry value contains a value.
     */
    public bool IsValid => Type != NetworkTableType.Unassigned;

    public object? Value
    {
        get
        {
            if (m_objectValue != null)
            {
                return m_objectValue;
            }

            if (Type == NetworkTableType.Boolean)
            {
                bool ret = m_structValue.boolValue;
                return ret;
            }
            else if (Type == NetworkTableType.Double)
            {
                double ret = m_structValue.doubleValue;
                return ret;
            }
            else if (Type == NetworkTableType.Integer)
            {
                long ret = m_structValue.longValue;
                return ret;
            }
            else if (Type == NetworkTableType.Float)
            {
                float ret = m_structValue.floatValue;
                return ret;
            }

            return null;
        }
    }

    public static NetworkTableValue MakeUnassigned()
    {
        return new NetworkTableValue(NetworkTableType.Unassigned, null, NtCore.Now(), 1);
    }

    public static NetworkTableValue MakeUnassigned(long time)
    {
        return new NetworkTableValue(NetworkTableType.Unassigned, null, time, 1);
    }

    // TODO Equals and HashCode

    /**
     * Get the data type.
     *
     * @return The type.
     */
    public NetworkTableType Type { get; }

    internal readonly object? m_objectValue;
    internal readonly ValueStorage m_structValue;

    [StructLayout(LayoutKind.Explicit)]
    internal readonly struct ValueStorage
    {
        public ValueStorage(bool value)
        {
            boolValue = value;
        }

        public ValueStorage(long value)
        {
            longValue = value;
        }

        public ValueStorage(float value)
        {
            floatValue = value;
        }

        public ValueStorage(double value)
        {
            doubleValue = value;
        }

        [FieldOffset(0)]
        public readonly bool boolValue;
        [FieldOffset(0)]
        public readonly long longValue;
        [FieldOffset(0)]
        public readonly float floatValue;
        [FieldOffset(0)]
        public readonly double doubleValue;
    }

    public static implicit operator RefNetworkTableValue(in NetworkTableValue value)
    {
        return value.Type switch
        {
            NetworkTableType.Boolean => RefNetworkTableValue.MakeBoolean(value.m_structValue.boolValue, value.Time),
            NetworkTableType.Double => RefNetworkTableValue.MakeDouble(value.m_structValue.doubleValue, value.Time),
            NetworkTableType.String => RefNetworkTableValue.MakeString((string)value.m_objectValue!, value.Time),
            NetworkTableType.Raw => RefNetworkTableValue.MakeRaw((byte[])value.m_objectValue!, value.Time),
            NetworkTableType.BooleanArray => RefNetworkTableValue.MakeBooleanArray((bool[])value.m_objectValue!, value.Time),
            NetworkTableType.DoubleArray => RefNetworkTableValue.MakeDoubleArray((double[])value.m_objectValue!, value.Time),
            NetworkTableType.StringArray => RefNetworkTableValue.MakeStringArray((string[])value.m_objectValue!, value.Time),
            NetworkTableType.Integer => RefNetworkTableValue.MakeInteger(value.m_structValue.longValue, value.Time),
            NetworkTableType.Float => RefNetworkTableValue.MakeFloat(value.m_structValue.floatValue, value.Time),
            NetworkTableType.IntegerArray => RefNetworkTableValue.MakeIntegerArray((long[])value.m_objectValue!, value.Time),
            NetworkTableType.FloatArray => RefNetworkTableValue.MakeFloatArray((float[])value.m_objectValue!, value.Time),
            _ => RefNetworkTableValue.MakeUnassigned(value.Time),
        };
    }
}
