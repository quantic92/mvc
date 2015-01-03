using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.Services
{
    public class ParentService
    {
        public List<Parent> GetAllParents()
        {
            using (var db = new DziennikDbContext())
            {
                return db.Parents.ToList();
            }
        }
        public Parent GetParentById(int id)
        {
            using (var db = new DziennikDbContext()) {
                return db.Parents.First(p => p.ParentID == id);
            }
        }

        public void AddExistingParentToStudent(Parent parent, Student student)
        {
            using (var db = new DziennikDbContext())
            {
                var original = db.Parents.Find(parent.ParentID);
                parent.Student.Add(student);
                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(parent);
                }
            }
        }

        public void AddPArent(Parent parent)
        {
            using (var db = new DziennikDbContext())
            {
                db.Parents.Add(parent);
                db.SaveChanges();
            }
        }
    }
}