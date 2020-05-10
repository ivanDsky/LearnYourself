using System;

public interface IType<T> where T : struct,IConvertible
{
    T Type { get; }
}