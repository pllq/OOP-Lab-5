using System;
using DAL;
using BLL;

namespace Adapter
{
    public class Adapter : IAdaptService<DAL.Human, BLL.Human>
    {
        public DAL.Human Adapt(BLL.Human obj)
        {
            Type type = obj.GetType();
            if (type == typeof(BLL.Student))
            {
                BLL.Student _obj = (BLL.Student)obj;
                return new DAL.Student(_obj.FirstName, _obj.LastName, _obj.Date.Day, _obj.Date.Month, _obj.Date.Year, _obj.StudentID, _obj.Grade, _obj.DrivingLicense, _obj.Swim());
            }
            else if (type == typeof(BLL.Painter))
            {
                BLL.Painter _obj = (BLL.Painter)obj;
                return new DAL.Painter(_obj.FirstName, _obj.LastName, _obj.Date.Day, _obj.Date.Month, _obj.Date.Year, _obj.Experience, _obj.DrivingLicense, _obj.Swim());
            }
            else if (type == typeof(BLL.Farmer))
            {
                BLL.Farmer _obj = (BLL.Farmer)obj;
                return new DAL.Farmer(_obj.FirstName, _obj.LastName, _obj.Date.Day, _obj.Date.Month, _obj.Date.Year, _obj.Experience, _obj.DrivingLicense, _obj.Swim());
            }
            else
            {
                return null;
            }
        }
        public BLL.Human Adapt(DAL.Human obj)
        {
            Type type = obj.GetType();
            if (type == typeof(DAL.Student))
            {
                DAL.Student _obj = (DAL.Student)obj;
                if (_obj.SwimAbility)
                {
                    return new BLL.Student(_obj.FirstName, _obj.LastName, _obj.Date.Year, _obj.Date.Day, _obj.Date.Month, _obj.StudentID, _obj.Grade, _obj.DrivingLicense, new YesSwim());
                }
                else
                {
                    return new BLL.Student(_obj.FirstName, _obj.LastName, _obj.Date.Year, _obj.Date.Day, _obj.Date.Month, _obj.StudentID, _obj.Grade, _obj.DrivingLicense, new NoSwim());
                }
            }
            else if (type == typeof(DAL.Painter))
            {
                DAL.Painter _obj = (DAL.Painter)obj;
                if (_obj.SwimAbility)
                {
                    return new BLL.Painter(_obj.FirstName, _obj.LastName, _obj.Date.Year, _obj.Date.Day, _obj.Date.Month, _obj.Experience, _obj.DrivingLicense, new YesSwim());
                }
                else
                {
                    return new BLL.Painter(_obj.FirstName, _obj.LastName, _obj.Date.Year, _obj.Date.Day, _obj.Date.Month, _obj.Experience, _obj.DrivingLicense, new NoSwim());
                }
            }
            else if (type == typeof(DAL.Farmer))
            {
                DAL.Farmer _obj = (DAL.Farmer)obj;
                if (_obj.SwimAbility)
                {
                    return new BLL.Farmer(_obj.FirstName, _obj.LastName, _obj.Date.Year, _obj.Date.Day, _obj.Date.Month, _obj.Experience, _obj.DrivingLicense, new YesSwim());
                }
                else
                {
                    return new BLL.Farmer(_obj.FirstName, _obj.LastName, _obj.Date.Year, _obj.Date.Day, _obj.Date.Month, _obj.Experience, _obj.DrivingLicense, new NoSwim());
                }
            }
            else
            {
                return null;
            }
        }
    }
}
