using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.Services
{
    public class GradeService
    {
        public void AddGrade(Grade grade)
        {
            using (var db = new DziennikDbContext())
            {
                db.Grades.Add(grade);
                db.SaveChanges();
            }
        }

        public void EditGrade(Grade grade)
        {
            using (var db = new DziennikDbContext())
            {
                var original = db.Grades.Find(grade.GradeID);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(grade);
                    db.SaveChanges();
                }
            }
        }
    }
}