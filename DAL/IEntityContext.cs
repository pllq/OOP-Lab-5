using System;
using Providers;

namespace DAL
{
    public interface IEntityContext<T>
    {
        string Connection { get; set; }
        IDataProvider<T> DataProvider { get; set; }
        T GetData();
        void SetData(T data);
        bool AreTypesNeeded { get; }
        Type[] Types { get; }
    }
}
