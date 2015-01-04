using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.Services
{
    public class ClassroomService
    {
        public void AddClassroom(Classroom classroom)
        {
            using (var db = new DziennikDbContext())
            {
                db.Classrooms.Add(classroom);
                db.SaveChanges();
            }
        }

        public void RemoveClassroom(int id)
        {
            using (var db = new DziennikDbContext())
            {
                var element = db.Classrooms.First(c => c.ClassroomID == id);
                db.Classrooms.Remove(element);
                db.SaveChanges();
            }
        }

        public void EditClassroom(Classroom classroom)
        {
            using (var db = new DziennikDbContext())
            {
                var original = db.Classrooms.Find(classroom.ClassroomID);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(classroom);
                    db.SaveChanges();
                }
            }
        }

        public void AddClassTeacher(Classroom classroom, Teacher teacher)
        {
            using (var db = new DziennikDbContext())
            {
                var original = db.Classrooms.Find(classroom.ClassroomID);
                original.ClassTeacherID = teacher.TeacherID;
                EditClassroom(classroom);
            }
        }
    }
}