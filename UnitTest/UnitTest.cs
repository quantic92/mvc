using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dziennik;
using Dziennik.Services;
using Dziennik.Models;
using System.Collections.Generic;


namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void InitialTest()
        {
            var ss = new StudentService();
            Student st = new Student
            {
                DateOfBirthday = new DateTime(2000, 1, 1),
                DateOfJoin = new DateTime(2000, 1, 1),
                Email = "mail@mail.com",
                LastLoginDate = new DateTime(2000, 1, 1),
                LastName = "Test",
                Login = "Test",
                MobilePhone = "12345",
                Name = "Test",
                Password = "Test",
                Phone = "4343434",
                Status = true,
                StudentID = 3
            };
            //ss.AddStudent(st);
            var listFromDb = ss.GetAllStudents();
            Assert.AreEqual(1, listFromDb.Count);
            var student = ss.GetStudentById(3);
            Assert.AreEqual("Name", student.Name);

            var ps = new ParentService();

            var parents = ps.GetAllParents();

            student.Parent = ps.GetParentById(1);
            ss.EditStudent(student);

            student = ss.GetStudentsForParent(1)[0];
            Assert.AreEqual(3, student.StudentID);
        }

        [TestMethod]
        public void ExamsTest()
        {
            var service = new ExamService();
            var exams = service.GetAllExamsWithType();
            Assert.AreEqual(1, exams.Count);
            var findTest = service.GetExamById(exams[0].ExamID);
            Assert.AreEqual(exams[0].ExamID, findTest.ExamID);
            var ss = new StudentService();
            var student = ss.GetStudentById(3);
            Assert.AreEqual(1, service.GetExamsForStudent(student.StudentID).Count);

            

        }
    }
}
