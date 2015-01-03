namespace Dziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomID = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        ClassTeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassroomID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ClassRoom_ClassroomID = c.Int(),
                    })
                .PrimaryKey(t => t.GradeID)
                .ForeignKey("dbo.Classrooms", t => t.ClassRoom_ClassroomID)
                .Index(t => t.ClassRoom_ClassroomID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Grade_GradeID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Grades", t => t.Grade_GradeID)
                .Index(t => t.Grade_GradeID);
            
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        ExamResultID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        CurseID = c.Int(nullable: false),
                        Marks = c.String(),
                    })
                .PrimaryKey(t => t.ExamResultID)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ExamType_ExamTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ExamID)
                .ForeignKey("dbo.ExamTypes", t => t.ExamType_ExamTypeID)
                .Index(t => t.ExamType_ExamTypeID);
            
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        ExamTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExamTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "ExamType_ExamTypeID", "dbo.ExamTypes");
            DropForeignKey("dbo.ExamResults", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Courses", "Grade_GradeID", "dbo.Grades");
            DropForeignKey("dbo.Grades", "ClassRoom_ClassroomID", "dbo.Classrooms");
            DropIndex("dbo.Exams", new[] { "ExamType_ExamTypeID" });
            DropIndex("dbo.ExamResults", new[] { "ExamID" });
            DropIndex("dbo.Courses", new[] { "Grade_GradeID" });
            DropIndex("dbo.Grades", new[] { "ClassRoom_ClassroomID" });
            DropTable("dbo.ExamTypes");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamResults");
            DropTable("dbo.Courses");
            DropTable("dbo.Grades");
            DropTable("dbo.Classrooms");
        }
    }
}
