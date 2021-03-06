﻿using Dziennik.DTOs;
using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.Services
{
    public class ExamService
    {
        public List<ExamWithTypeDTO> GetAllExamsWithType()
        {
            using (var db = new DziennikDbContext())
            {
                var resultList = new List<ExamWithTypeDTO>();
                var exams = db.Exams.ToList();
                foreach (var exam in exams)
                {
                    var type = db.ExamTypes.First(t => t.ExamTypeID == exam.ExamType.ExamTypeID);
                    var examWithTypeDTO = new ExamWithTypeDTO
                    {
                        ExamID = exam.ExamID,
                        ExamTypeID = type.ExamTypeID,
                        Name = exam.Name,
                        StartDate = exam.StartDate,
                        TypeDescription = type.Description,
                        TypeName = type.Name
                    };
                    resultList.Add(examWithTypeDTO);
                }
                return resultList;
            }
        }

        public ExamWithTypeDTO GetExamById(int id)
        {
            using (var db = new DziennikDbContext())
            {
                var exam = db.Exams.First(e => e.ExamID == id);
                var type = db.ExamTypes.First(t => t.ExamTypeID == exam.ExamType.ExamTypeID);
                var examWithTypeDTO = new ExamWithTypeDTO
                {
                    ExamID = exam.ExamID,
                    ExamTypeID = type.ExamTypeID,
                    Name = exam.Name,
                    StartDate = exam.StartDate,
                    TypeDescription = type.Description,
                    TypeName = type.Name
                };
                return examWithTypeDTO;
            }
        }

        public List<StudentExamDTO> GetExamsForStudent(int id)
        {
            using (var db = new DziennikDbContext())
            {
                var exams = new List<StudentExamDTO>();
                var ss = new StudentService();
                var student = ss.GetStudentById(id);
                var examResults = db.ExamResults;
                var allExams = db.Exams;
                var examTypes = db.ExamTypes;

                var examsAsQueryable =
                    from r in examResults
                    join e in allExams on r.ExamID equals e.ExamID
                    join t in examTypes on e.ExamType.ExamTypeID equals t.ExamTypeID
                    where r.StudentID == id
                    select new
                    {
                        r, e, t
                    };


                foreach (var exam in examsAsQueryable.ToList())
                {
                    exams.Add(new StudentExamDTO
                    {
                        ExamID = exam.e.ExamID,
                        ExamResultID = exam.r.ExamResultID,
                        ExamTypeID = exam.t.ExamTypeID,
                        CourseID = exam.r.CurseID,
                        Marks = exam.r.Marks,
                        Name = exam.e.Name,
                        StartDate = exam.e.StartDate,
                        StudentID = exam.r.StudentID,
                        TypeDescription = exam.t.Description,
                        TypeName = exam.t.Name,
                    });
                }

                //var examsList = examResults
                //    .Join(allExams, r => r.ExamID, e => e.ExamID, (r, e) => new { r, e })
                //    .Join(examTypes, re => re.e.ExamType.ExamTypeID, t => t.ExamTypeID, (re, t) => new
                //    {

                //    });

                return exams;
            }
        }

        public void AddExamWithType(ExamWithTypeDTO exam)
        {
            using (var db = new DziennikDbContext())
            {
                var type = db.ExamTypes.First(t => t.ExamTypeID == exam.ExamTypeID); 
                var dbExam = new Exam
                {
                    Name = exam.Name,
                    StartDate = exam.StartDate,
                    ExamType = type
                };
                db.Exams.Add(dbExam);
                db.SaveChanges();
            }
        }
    }
}