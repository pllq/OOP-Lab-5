using System;
using Exceptions;

namespace BLL
{
    public class Farmer : Human
    {
        private int experience;
        public Farmer(string f_name, string l_name, int year, int day, int month, int exp, bool driving_license, ISwim swim) : base(f_name, l_name, year, day, month, driving_license, swim)
        {
            if (exp >= 0 && (DateTime.Now.Year - year + 10) >= exp)
            {
                this.experience = exp;
            }
            else
            {
                throw new FarmerDataException("Incorrect field format \"Experience\".");
            }
        }
        public int Experience
        { get { return this.experience; } }
    }
}
