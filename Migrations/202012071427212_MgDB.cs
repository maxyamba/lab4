namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MgDB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Countries", "id_city");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "id_city", c => c.Int(nullable: false));
        }
    }
}
