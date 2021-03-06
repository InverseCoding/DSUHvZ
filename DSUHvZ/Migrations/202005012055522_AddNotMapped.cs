namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotMapped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
