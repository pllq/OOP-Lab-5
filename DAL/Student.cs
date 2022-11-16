using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text.Json.Serialization;
using System.Numerics;

namespace DAL
{
    [Serializable]
    [XmlInclude(typeof(Human))]
    public class Student : Human, ISerializable
    {
        [DataMember]
        public int Grade { get; set; }
        [DataMember]
        public string StudentID { get; set; }
        private Student() { }
        public Student(string f_name, string l_name, int day, int month, int year, string studentID, int grade, bool swim, bool driving_license) :
            base(f_name, l_name, day, month, year, swim, driving_license)
        {
            this.StudentID = studentID;
            this.Grade = grade;
        }
        protected Student(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
            this.Grade = info.GetInt32("Grade");
            this.StudentID = info.GetString("StudentID");
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", this.FirstName);
            info.AddValue("LastName", this.LastName);
            info.AddValue("Date_Year", this.Date.Year);
            info.AddValue("Date_Month", this.Date.Month);
            info.AddValue("Date_Day", this.Date.Day);
            info.AddValue("Grade", this.Grade);
            info.AddValue("StudentID", this.StudentID);
            info.AddValue("SwimAbility", this.SwimAbility);
            info.AddValue("DrivingLicense", this.DrivingLicense);
        }
    }
}
