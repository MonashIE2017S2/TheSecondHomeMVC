namespace MvcPWy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        state = c.String(),
                        suburb = c.String(),
                        postCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        studentId = c.String(),
                        surName = c.String(),
                        givenName = c.String(),
                        dob = c.DateTime(nullable: false),
                        aboriginalOrTorres = c.Boolean(nullable: false),
                        gender = c.String(),
                        ethnicOrigin = c.String(),
                        languages = c.String(),
                        placementType = c.String(),
                        courtOrderGiven = c.Boolean(nullable: false),
                        VSN = c.String(),
                        schoolId = c.Int(nullable: false),
                        admissionDate = c.DateTime(nullable: false),
                        yearLevel = c.String(),
                        programStuentDisability = c.Boolean(nullable: false),
                        deleted = c.Boolean(nullable: false),
                        disabilityCategory = c.String(),
                        dateCurrentPlan = c.DateTime(nullable: false),
                        dateNextPlan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentQualities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                        hobby = c.String(),
                        strength = c.String(),
                        social = c.String(),
                        triggerPoints = c.String(),
                        support = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        subjectCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        subjectCode = c.String(),
                        hobby = c.String(),
                        strength = c.String(),
                        social = c.String(),
                        triggerPoints = c.String(),
                        studentId = c.Int(nullable: false),
                        support = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        surName = c.String(),
                        givenName = c.String(),
                        address = c.String(),
                        state = c.String(),
                        schoolId = c.Int(nullable: false),
                        emailId = c.String(),
                        postCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPersonals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        isActive = c.Boolean(nullable: false),
                        deleted = c.Boolean(nullable: false),
                        empId = c.String(),
                        UserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_Id)
                .Index(t => t.UserRole_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        roleName = c.String(),
                        priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSecrets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        password = c.String(),
                        createdAt = c.DateTime(nullable: false),
                        modifiedAt = c.DateTime(nullable: false),
                        createdBy_Id = c.Int(),
                        modifiedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserPersonals", t => t.createdBy_Id)
                .ForeignKey("dbo.UserPersonals", t => t.modifiedBy_Id)
                .Index(t => t.createdBy_Id)
                .Index(t => t.modifiedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSecrets", "modifiedBy_Id", "dbo.UserPersonals");
            DropForeignKey("dbo.UserSecrets", "createdBy_Id", "dbo.UserPersonals");
            DropForeignKey("dbo.UserPersonals", "UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.UserSecrets", new[] { "modifiedBy_Id" });
            DropIndex("dbo.UserSecrets", new[] { "createdBy_Id" });
            DropIndex("dbo.UserPersonals", new[] { "UserRole_Id" });
            DropTable("dbo.UserSecrets");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserPersonals");
            DropTable("dbo.Teachers");
            DropTable("dbo.SubjectPlans");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentQualities");
            DropTable("dbo.Students");
            DropTable("dbo.Schools");
        }
    }
}
