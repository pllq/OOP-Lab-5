using System;
using DAL;
using BLL;
using System.Collections.Generic;

namespace Adapter
{
    public class ConvertService : IConvertService<DAL.Human, BLL.Human>
    {
        public IAdaptService<DAL.Human, BLL.Human> Converter { get { return new Adapter(); } }
        public ICollection<DAL.Human> Convert(ICollection<BLL.Human> collection)
        {
            if (collection == null)
            {
                return null;
            }
            else
            {
                List<DAL.Human> list = new List<DAL.Human>();
                foreach (BLL.Human obj in collection)
                {
                    list.Add(this.Converter.Adapt(obj));
                }
                return list;
            }
        }
        public ICollection<BLL.Human> Convert(ICollection<DAL.Human> collection)
        {
            if (collection == null)
            {
                return null;
            }
            else
            {
                List<BLL.Human> list = new List<BLL.Human>();
                foreach (DAL.Human obj in collection)
                {
                    list.Add(this.Converter.Adapt(obj));
                }
                return list;
            }
        }
    }
}
