using System;
using System.Collections.Generic;
using BLL;

namespace Services
{
    public class EntityService : IEntityService<BLL.Human>
    {
        private List<BLL.Human> list = new List<BLL.Human>();
        public ICollection<BLL.Human> DataCollection
        {
            get
            {
                return this.list;
            }
            set
            {
                if (value != null)
                {
                    this.list = (List<BLL.Human>)value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }
            public BLL.Human this[int ind]
        {
            get
            {
                if (0 <= ind && ind < this.list.Count)
                {
                    return this.list[ind];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("An element with this index does not exist.");
                }
            }
        }
        public void Add(BLL.Human item)
        {
            if (item != null)
            {
                this.list.Add(item);
            }
            else
            {
                throw new NullReferenceException("Attempting to add an empty element.");
            }
        }
        public bool Remove(int ind)
        {
            if (0 <= ind && ind < this.list.Count)
            {
                this.list.RemoveAt(ind);
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("An element with this index does not exist.");
            }
        }
        public int Operation()
        {
            int count = 0;
            foreach(BLL.Human item in this.list)
            {
                if (item.GetType() == typeof(BLL.Student))
                {
                    BLL.Student _item = (BLL.Student)item;
                    if (_item.Grade == 2 && (_item.Date.Month == 12 || _item.Date.Month == 1 || _item.Date.Month == 2))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
