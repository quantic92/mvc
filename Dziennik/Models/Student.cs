using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Student
    {
        [Required]
        public int StudentID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirthday { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string MobilePhone { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfJoin { get; set; }
        public Boolean Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastLoginDate { get; set; }
        public virtual Parent Parent { get; set; }
    }
}