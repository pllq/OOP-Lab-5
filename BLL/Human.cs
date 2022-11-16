using System;
using Exceptions;

namespace BLL
{
    public abstract class Human : ISwim, IDriving_License
    {
        private string firstname;
        private string lastname;
        private DateTime date;
        private bool drivinglicense;
        protected ISwim swim = new NoSwim();
        public string FirstName
        { get { return this.firstname; } }
        public string LastName
        { get { return this.lastname; } }
        public DateTime Date
        { get { return this.date; } }
        public int Age
        {
            get
            {
                TimeSpan age = DateTime.Now - this.date;
                return Convert.ToInt32(Math.Floor(Math.Round(age.TotalDays) / 365.25));
            }
        }
        public bool DrivingLicense { get { return this.drivinglicense; } }
        protected Human(string f_name, string l_name, int year, int day, int month, bool driving_license, ISwim swim)
        {
            if (this.CheckName(f_name))
            {
                this.firstname = f_name;
            }
            else
            {
                throw new HumanDataException("Incorrect field value \"First name\".");
            }
            if (this.CheckName(l_name))
            {
                this.lastname = l_name;
            }
            else
            {
                throw new HumanDataException("Incorrect field value \"Last name\".");
            }
            this.date = new DateTime(year, month, day);
            this.drivinglicense = driving_license;
            this.swim = swim;
        }
        public bool Swim()
        {
            return this.swim.Swim();
        }
        private bool CheckName(string name)
        {
            bool check = true;
            if (name.Length >= 2 && name.Length <= 30)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if ((name[i] <= 90 && name[i] >= 65) || (name[i] <= 122 && name[i] >= 97) || (name[i] <= 1105 && name[i] >= 1040) || name[i] == 45 || name[i] == 39)
                    {

                    }
                    else
                    {
                        check = false;
                    }
                }
            }
            else
            {
                check = false;
            }
            return check;
        }
    }
}
