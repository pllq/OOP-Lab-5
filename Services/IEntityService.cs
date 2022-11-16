using System;
using System.Collections.Generic;

namespace Services
{
    public interface IEntityService<T>
    {
        ICollection<T> DataCollection { get; set; }
        T this[int ind] { get; }
        void Add(T item);
        bool Remove(int ind);
        int Operation();
    }
}
