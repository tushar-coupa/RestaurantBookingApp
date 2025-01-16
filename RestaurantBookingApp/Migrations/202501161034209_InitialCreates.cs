namespace RestaurantBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TableId = c.Int(nullable: false),
                        RestuarantId = c.Int(nullable: false),
                        BookingDateTime = c.DateTime(nullable: false),
                        NumOfGuest = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        OpeningTime = c.Time(nullable: false, precision: 7),
                        ClosingTime = c.Time(nullable: false, precision: 7),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TableNumber = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        ReservationDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tables");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Bookings");
        }
    }
}
