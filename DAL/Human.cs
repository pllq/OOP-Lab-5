using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DAL
{
    [Serializable]
    public abstract class Human : ISwimAbility, IDrivingAbility
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public bool SwimAbility { get; set; }
        public bool DrivingLicense { get; set; }
        protected Human() { }
        protected Human(SerializationInfo info, StreamingContext context)
        {
            this.FirstName = info.GetString("FirstName");
            this.LastName = info.GetString("LastName");
            this.Date = new DateTime(info.GetInt32("Date_Year"), info.GetInt32("Date_Month"), info.GetInt32("Date_Day"));
            this.SwimAbility = info.GetBoolean("SwimAbility");
            this.DrivingLicense = info.GetBoolean("DrivingLicense");
        }
        protected Human(string f_name, string l_name, int day, int month, int year, bool swim, bool driving_license)
        {
            this.FirstName = f_name;
            this.LastName = l_name;
            this.Date = new DateTime(year, month, day);
            this.SwimAbility = swim;
            this.DrivingLicense = driving_license;
        }
    }
}
