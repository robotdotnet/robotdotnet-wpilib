﻿namespace WPIUtil.Serialization;

public interface IStructBase
{
    public const int SizeBool = 1;
    public const int SizeDouble = 8;

    string TypeString { get; }
    int Size { get; }
    string Schema { get; }

    IStructBase[] Nested => [];
}

public interface IStruct<T> : IStructBase
{
    T Unpack(ref StructUnpacker buffer);

    void Pack(ref StructPacker buffer, T value);
}
