namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cinemas", "Cinema_id_cinema", c => c.Int());
            AddColumn("dbo.Cities", "City_id_city", c => c.Int());
            AddColumn("dbo.Countries", "Country_id_country", c => c.Int());
            CreateIndex("dbo.Cinemas", "Cinema_id_cinema");
            CreateIndex("dbo.Cities", "City_id_city");
            CreateIndex("dbo.Countries", "Country_id_country");
            AddForeignKey("dbo.Cinemas", "Cinema_id_cinema", "dbo.Cinemas", "id_cinema");
            AddForeignKey("dbo.Cities", "City_id_city", "dbo.Cities", "id_city");
            AddForeignKey("dbo.Countries", "Country_id_country", "dbo.Countries", "id_country");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "Country_id_country", "dbo.Countries");
            DropForeignKey("dbo.Cities", "City_id_city", "dbo.Cities");
            DropForeignKey("dbo.Cinemas", "Cinema_id_cinema", "dbo.Cinemas");
            DropIndex("dbo.Countries", new[] { "Country_id_country" });
            DropIndex("dbo.Cities", new[] { "City_id_city" });
            DropIndex("dbo.Cinemas", new[] { "Cinema_id_cinema" });
            DropColumn("dbo.Countries", "Country_id_country");
            DropColumn("dbo.Cities", "City_id_city");
            DropColumn("dbo.Cinemas", "Cinema_id_cinema");
        }
    }
}
