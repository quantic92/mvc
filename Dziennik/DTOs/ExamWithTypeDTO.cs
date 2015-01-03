using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.DTOs
{
    public class ExamWithTypeDTO
    {
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int ExamID { get; set; }
        public int ExamTypeID { get; set; }
        public int CourseID { get; set; }
    }
}