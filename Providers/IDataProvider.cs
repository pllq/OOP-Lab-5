using System;

namespace Providers
{
    public interface IDataProvider<T>
    {
        string FileType { get; }
        void Write(T data, string connection);
        void Write(T data, string connection, Type[] types);
        T Read(string connection);
        T Read(string connection, Type[] types);
    }
}
