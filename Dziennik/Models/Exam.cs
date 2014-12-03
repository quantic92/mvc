using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Exam
    {
        [Required]
        public int ExamID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        //virtual
    }
}