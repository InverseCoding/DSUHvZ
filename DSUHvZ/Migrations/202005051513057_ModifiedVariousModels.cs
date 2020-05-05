namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedVariousModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "AccountID", c => c.Int(nullable: false));
            AlterColumn("dbo.AppUsers", "ActiveGameID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "ActiveGameID", c => c.Int(nullable: false));
            DropColumn("dbo.AppUsers", "AccountID");
        }
    }
}
