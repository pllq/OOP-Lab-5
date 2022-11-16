using System;

namespace BLL
{
    public interface ISwim
    {
        bool Swim();
    }
    public class NoSwim : ISwim
    {
        public bool Swim()
        {
            return false;
        }
    }
    public class YesSwim : ISwim
    {
        public bool Swim()
        {
            return true;
        }
    }
}
