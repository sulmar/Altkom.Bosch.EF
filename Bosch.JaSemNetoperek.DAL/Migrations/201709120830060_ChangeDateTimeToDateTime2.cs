namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "FromDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Rentals", "ToDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "ToDate", c => c.DateTime());
            AlterColumn("dbo.Rentals", "FromDate", c => c.DateTime(nullable: false));
        }
    }
}
