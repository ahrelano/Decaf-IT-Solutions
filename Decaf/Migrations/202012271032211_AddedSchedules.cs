namespace Decaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSchedules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SunShiftFrom = c.Time(nullable: false, precision: 7),
                        SunShiftTo = c.Time(nullable: false, precision: 7),
                        MonShiftFrom = c.Time(nullable: false, precision: 7),
                        MonShiftTo = c.Time(nullable: false, precision: 7),
                        TueShiftFrom = c.Time(nullable: false, precision: 7),
                        TueShiftTo = c.Time(nullable: false, precision: 7),
                        WedShiftFrom = c.Time(nullable: false, precision: 7),
                        WedShiftTo = c.Time(nullable: false, precision: 7),
                        ThuShiftFrom = c.Time(nullable: false, precision: 7),
                        ThuShiftTo = c.Time(nullable: false, precision: 7),
                        FriShiftFrom = c.Time(nullable: false, precision: 7),
                        FriShiftTo = c.Time(nullable: false, precision: 7),
                        SatShiftFrom = c.Time(nullable: false, precision: 7),
                        SatShiftTo = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserID");
            DropTable("dbo.Schedules");
        }
    }
}
