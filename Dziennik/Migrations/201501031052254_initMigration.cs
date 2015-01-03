namespace Dziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "DateOfBirthday", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfBirthday", c => c.DateTime(nullable: false));
        }
    }
}
