using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace DAL
{
    [Serializable]
    [XmlInclude(typeof(Human))]
    public class Painter : Human, ISerializable
    {
        [DataMember]
        public int Experience { get; set; }
        private Painter() { }
        public Painter(string f_name, string l_name, int day, int month, int year, int experience, bool swim, bool driving_license) :
            base(f_name, l_name, day, month, year, swim, driving_license)
        {
            this.Experience = experience;
        }
        protected Painter(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
            this.Experience = info.GetInt32("Experience");
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", this.FirstName);
            info.AddValue("LastName", this.LastName);
            info.AddValue("Date_Year", this.Date.Year);
            info.AddValue("Date_Month", this.Date.Month);
            info.AddValue("Date_Day", this.Date.Day);
            info.AddValue("Experience", this.Experience);
            info.AddValue("SwimAbility", this.SwimAbility);
            info.AddValue("DrivingLicense", this.DrivingLicense);
        }
    }
}
