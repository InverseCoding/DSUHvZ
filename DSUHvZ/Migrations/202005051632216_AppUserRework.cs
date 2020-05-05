namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserRework : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "AccountID", c => c.String(nullable: false, maxLength: 127));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "AccountID", c => c.Int(nullable: false));
        }
    }
}
