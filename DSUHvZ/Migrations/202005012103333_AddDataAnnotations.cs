namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AppUsers", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "Email", c => c.String());
            AlterColumn("dbo.AppUsers", "Name", c => c.String());
        }
    }
}
