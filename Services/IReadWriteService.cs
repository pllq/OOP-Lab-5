using System;

namespace Services
{
    public interface IReadWriteService<T>
    {
        string File { get; }
        T ReadData();
        void WriteData(T data);
    }
}
