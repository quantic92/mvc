namespace Dziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentID = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Name = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        DateOfBirthday = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 20),
                        MobilePhone = c.String(maxLength: 20),
                        DateOfJoin = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ParentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Name = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        DateOfBirthday = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 20),
                        MobilePhone = c.String(maxLength: 20),
                        DateOfJoin = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        Parent_ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Parents", t => t.Parent_ParentID)
                .Index(t => t.Parent_ParentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Name = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        DateOfBirthday = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 20),
                        MobilePhone = c.String(maxLength: 20),
                        DateOfJoin = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Parent_ParentID", "dbo.Parents");
            DropIndex("dbo.Students", new[] { "Parent_ParentID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Parents");
        }
    }
}
