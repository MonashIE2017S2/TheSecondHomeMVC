namespace MvcPWy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIdentifyQuestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentifyQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        evidence = c.String(),
                        reference = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IdentifyQuestions");
        }
    }
}
