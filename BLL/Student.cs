using System;
using Exceptions;
using System.Text.RegularExpressions;

namespace BLL
{
    public class Student : Human
    {
        private string studentid;
        private int grade;
        public Student(string f_name, string l_name, int year, int day, int month, string s_id, int grade, bool driving_license, ISwim swim) : base(f_name, l_name, year, day, month, driving_license, swim)
        {
            if (s_id.Length == 10 && Regex.IsMatch(s_id, @"[A-Z,А-ЯЁ]{2}\d{8}"))
            {
                this.studentid = s_id;
            }
            else
            {
                throw new StudentDataException("Incorrect field value \"Student's ID card\".");
            }
            if (grade > 0 && grade <= 6)
            {
                this.grade = grade;
            }
            else
            {
                throw new StudentDataException("Incorrect field value \"Grade\".");
            }
        }
        public string StudentID
        { get { return this.studentid; } }
        public int Grade
        { get { return this.grade; } }
    }
}
