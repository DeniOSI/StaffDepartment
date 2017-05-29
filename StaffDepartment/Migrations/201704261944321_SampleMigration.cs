namespace StaffDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passports", "Worker_WId", "dbo.Workers");
            DropIndex("dbo.Passports", new[] { "Worker_WId" });
            DropColumn("dbo.Passports", "WorkerID");
            RenameColumn(table: "dbo.Passports", name: "Worker_WId", newName: "WorkerID");
            AlterColumn("dbo.Passports", "WorkerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Passports", "WorkerID");
            AddForeignKey("dbo.Passports", "WorkerID", "dbo.Workers", "WId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passports", "WorkerID", "dbo.Workers");
            DropIndex("dbo.Passports", new[] { "WorkerID" });
            AlterColumn("dbo.Passports", "WorkerID", c => c.Int());
            RenameColumn(table: "dbo.Passports", name: "WorkerID", newName: "Worker_WId");
            AddColumn("dbo.Passports", "WorkerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Passports", "Worker_WId");
            AddForeignKey("dbo.Passports", "Worker_WId", "dbo.Workers", "WId");
        }
    }
}
