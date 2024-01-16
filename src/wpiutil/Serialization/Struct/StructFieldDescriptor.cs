using System.Collections.Generic;

namespace WPIUtil.Serialization.Struct;

public class StructFieldDescriptor
{
    private static int ToBitWidth(int size, int bitWidth)
    {
        if (bitWidth == 0)
        {
            return size * 8;
        }
        else
        {
            return bitWidth;
        }
    }

    private static long ToBitMask(int size, int bitWidth)
    {
        if (size == 0)
        {
            return 0;
        }
        else
        {
            return -1L >>> (64 - ToBitWidth(size, bitWidth));
        }
    }

    internal StructFieldDescriptor(StructDescriptor parent,
                                   string name,
                                   StructFieldType type,
                                   int size,
                                   int arraySize,
                                   int bitWidth,
                                   Dictionary<string, long>? enumValues,
                                   StructDescriptor structDesc)
    {
        Parent = parent;
        Name = name;
        Type = type;
        Size = size;
        ArraySize = arraySize;
        Struct = structDesc;
        EnumValues = enumValues;
        BitWidth = ToBitWidth(size, bitWidth);
        BitMask = ToBitMask(size, bitWidth);
    }

    public long BitMask { get; }

    public Dictionary<string, long>? EnumValues { get; }

    public string Name { get; }

    public int Offset { get; internal set; }
    public int Size { get; internal set; }
    public int ArraySize { get; }
    public bool IsBitField { get; }
    public int BitWidth { get; }
    public int BitShift { get; internal set; }
    public StructFieldType Type { get; }
    public StructDescriptor Struct { get; }

    public StructDescriptor Parent { get; }

    public bool IsInt => Type.GetFieldTypeInfo().IsInt;
    public bool IsUint => Type.GetFieldTypeInfo().IsUint;

    public bool IsArray => ArraySize > 1;

    public bool HasEnum => EnumValues != null;

    public long UintMin => 0;
    public long UintMax => BitMask;
    public long IntMin => (-(BitMask >> 1)) - 1;
    public long IntMax => BitMask >> 1;
}
