﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Classroom
    {
        public int ClassroomID { get; set; }
        public int Year { get; set; }
        public int ClassTeacherID { get; set; } //Wychowawca
        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}