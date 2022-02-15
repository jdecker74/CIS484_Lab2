using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decker_Jake_Monday
{
    public class Scholarship
    {
        private String scholarshipName;
        private String scholarshipYear;
        private String scholarshipAmount;
        public static Scholarship[] scholarshipArray = new Scholarship[25];

        public Scholarship(String name, String year, String amount)
        {
            name = scholarshipName;
            year = scholarshipYear;
            amount = scholarshipAmount;

        }
        public string ScholarshipName
        {
            get
            {
                return scholarshipName;
            }
            set
            {
                scholarshipName = value;
            }
        }
        public string ScholarshipYear
        {
            get
            {
                return scholarshipYear;
            }
            set
            {
                scholarshipYear = value;
            }
        }
        public string ScholarshipAmount
        {
            get
            {
                return scholarshipAmount;
            }
            set
            {
                scholarshipAmount = value;
            }
        }
    }
}