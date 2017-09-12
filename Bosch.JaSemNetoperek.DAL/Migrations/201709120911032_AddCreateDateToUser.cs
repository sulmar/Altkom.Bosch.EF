namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateDateToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreatedDate");
        }
    }
}
