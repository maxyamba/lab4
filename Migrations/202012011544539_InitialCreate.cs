namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        id_cinema = c.Int(nullable: false, identity: true),
                        cinema = c.String(),
                        id_city = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_cinema);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id_city = c.Int(nullable: false, identity: true),
                        city = c.String(),
                        id_country = c.Int(nullable: false),
                        id_cinema = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_city);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        id_country = c.Int(nullable: false, identity: true),
                        country = c.String(),
                        id_city = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_country);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Cinemas");
        }
    }
}
