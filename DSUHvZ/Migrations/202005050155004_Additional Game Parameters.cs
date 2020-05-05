namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalGameParameters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Description", c => c.String(nullable: false, maxLength: 1024));
            AddColumn("dbo.Games", "Rules", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Rules");
            DropColumn("dbo.Games", "Description");
        }
    }
}
