namespace StaffDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "Addr", c => c.String());
            AddColumn("dbo.WorkPlaces", "CompanyName", c => c.String());
            AddColumn("dbo.WorkPlaces", "ReasonForLeaving", c => c.String());
            AlterColumn("dbo.Passports", "PassportType", c => c.String(maxLength: 50));
            AlterColumn("dbo.Passports", "Series", c => c.String(maxLength: 50));
            AlterColumn("dbo.Passports", "Gave", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Passports", "Gave", c => c.String());
            AlterColumn("dbo.Passports", "Series", c => c.String());
            AlterColumn("dbo.Passports", "PassportType", c => c.String());
            DropColumn("dbo.WorkPlaces", "ReasonForLeaving");
            DropColumn("dbo.WorkPlaces", "CompanyName");
            DropColumn("dbo.Workers", "Addr");
        }
    }
}
