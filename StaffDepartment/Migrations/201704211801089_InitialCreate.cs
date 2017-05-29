namespace StaffDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EId = c.Int(nullable: false, identity: true),
                        CollegeName = c.String(),
                        Speciality = c.String(),
                        DipNumber = c.Int(nullable: false),
                        SeriesOfDiplom = c.String(),
                        WId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EId)
                .ForeignKey("dbo.Workers", t => t.WId, cascadeDelete: true)
                .Index(t => t.WId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Patronymic = c.String(),
                        INN = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        BDate = c.DateTime(nullable: false),
                        BCountry = c.String(),
                        Nationality = c.String(),
                        WorkBookID = c.Int(nullable: false),
                        BTown = c.String(),
                    })
                .PrimaryKey(t => t.WId);
            
            CreateTable(
                "dbo.Passports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PassportType = c.String(),
                        Series = c.String(),
                        Number = c.Int(nullable: false),
                        Gave = c.String(),
                        DateOfIssue = c.DateTime(nullable: false),
                        WorkerID = c.Int(nullable: false),
                        Worker_WId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.Worker_WId)
                .Index(t => t.Worker_WId);
            
            CreateTable(
                "dbo.WorkBooks",
                c => new
                    {
                        WorkBookID = c.Int(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        RecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkBookID)
                .ForeignKey("dbo.Workers", t => t.WorkBookID)
                .Index(t => t.WorkBookID);
            
            CreateTable(
                "dbo.WorkPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        WokrBookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkBooks", t => t.WokrBookID, cascadeDelete: true)
                .Index(t => t.WokrBookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "WId", "dbo.Workers");
            DropForeignKey("dbo.WorkBooks", "WorkBookID", "dbo.Workers");
            DropForeignKey("dbo.WorkPlaces", "WokrBookID", "dbo.WorkBooks");
            DropForeignKey("dbo.Passports", "Worker_WId", "dbo.Workers");
            DropIndex("dbo.WorkPlaces", new[] { "WokrBookID" });
            DropIndex("dbo.WorkBooks", new[] { "WorkBookID" });
            DropIndex("dbo.Passports", new[] { "Worker_WId" });
            DropIndex("dbo.Educations", new[] { "WId" });
            DropTable("dbo.WorkPlaces");
            DropTable("dbo.WorkBooks");
            DropTable("dbo.Passports");
            DropTable("dbo.Workers");
            DropTable("dbo.Educations");
        }
    }
}
