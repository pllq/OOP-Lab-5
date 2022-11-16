using System;


namespace Adapter
{
    public interface IAdaptService <T, V>
    {
        T Adapt(V obj);
        V Adapt(T obj);
    }
}
