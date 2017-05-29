namespace StaffDepartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workers", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workers", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workers", "Addr", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workers", "Patronymic", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workers", "BCountry", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workers", "Nationality", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "Nationality", c => c.String());
            AlterColumn("dbo.Workers", "BCountry", c => c.String());
            AlterColumn("dbo.Workers", "Patronymic", c => c.String());
            AlterColumn("dbo.Workers", "Addr", c => c.String());
            AlterColumn("dbo.Workers", "LastName", c => c.String());
            AlterColumn("dbo.Workers", "Name", c => c.String());
        }
    }
}
