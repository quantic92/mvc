using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public DateTime DateOfJoin { get; set; }
        public Boolean Status { get; set; }
        public DateTime LastLoginDate { get; set; }

        public virtual Parent Parent { get; set; }
    }
}