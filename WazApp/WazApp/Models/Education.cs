using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WazApp.Models
{
    public class Education
    {
        public int ID { get; set; } 
        public int EmployeeID { get; set; } 
        public string UniversityName { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set;}
    }
}