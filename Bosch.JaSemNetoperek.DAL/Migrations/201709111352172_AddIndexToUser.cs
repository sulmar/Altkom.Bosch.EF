namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToUser : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", new[] { "FirstName", "LastName" }, unique: true, name: "MyIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "MyIndex");
        }
    }
}
