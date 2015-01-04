using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Student
    {
        [Required]
        public int StudentID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Required]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(20)]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [StringLength(20)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Column(TypeName="DateTime2")]
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime DateOfBirthday { get; set; }
        [StringLength(20)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [StringLength(20)]
        [Display(Name = "Telefon komórkowy")]
        public string MobilePhone { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data utworzenia konta")]
        public DateTime DateOfJoin { get; set; }
        public Boolean Status { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ostatnio zalogowany")]
        public DateTime LastLoginDate { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}