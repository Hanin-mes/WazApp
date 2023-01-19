using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WazApp.Models
{
    public class Experience
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string CompanyName { get; set; }
        public string PositionCompany { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string Qualifications { get; set; }


    }
}