namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFirstNameOnUser : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Users SET FirstName='brak' WHERE FirstName is null");

            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50, defaultValue:"brak"));
        }
        
        public override void Down()
        {
            Sql("UPDATE dbo.Users SET FirstName=null WHERE FirstName ='brak'");

            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
