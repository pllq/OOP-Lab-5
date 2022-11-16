using System;
using System.Collections.Generic;

namespace Adapter
{
    public interface IConvertService<T, V>
    {
        IAdaptService<T, V> Converter { get; }
        ICollection<T> Convert(ICollection<V> collection);
        ICollection<V> Convert(ICollection<T> collection);
    }
}
