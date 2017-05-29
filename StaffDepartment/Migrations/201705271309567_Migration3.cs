namespace StaffDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Photo");
        }
    }
}
