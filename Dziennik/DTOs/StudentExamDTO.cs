using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.DTOs
{
    public class StudentExamDTO : ExamWithTypeDTO
    {
        public string Marks { get; set; }
        public int ExamResultID { get; set; }
        public int StudentID { get; set; }
    }
}