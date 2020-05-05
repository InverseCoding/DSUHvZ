namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkedGameId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "OwnerID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "ActiveGameID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ActiveGameID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Games", "OwnerID", c => c.Int(nullable: false));
        }
    }
}
