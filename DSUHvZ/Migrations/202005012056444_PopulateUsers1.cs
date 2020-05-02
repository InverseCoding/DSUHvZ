namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AppUsers (Name, ActiveGameID, Email) VALUES ('John Testman', 1, 'john.testman@example.com')");
            Sql("INSERT INTO AppUsers (Name, ActiveGameID, Email) VALUES ('Sarah Testman', 1, 'sarah.testman@example.com')");
        }
        
        public override void Down()
        {
        }
    }
}
