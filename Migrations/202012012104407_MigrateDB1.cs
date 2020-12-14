namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cinemas", "cinema", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "city", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "country", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "country", c => c.String());
            AlterColumn("dbo.Cities", "city", c => c.String());
            AlterColumn("dbo.Cinemas", "cinema", c => c.String());
        }
    }
}
