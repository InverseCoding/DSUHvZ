namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserMatchAspUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "AccountID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AppUsers", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AppUsers", "Email", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AppUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AppUsers", "AccountID", c => c.String(nullable: false, maxLength: 127));
        }
    }
}
