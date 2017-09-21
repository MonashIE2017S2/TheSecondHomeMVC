namespace MvcPWy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstudentid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "studentId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "studentId");
        }
    }
}
