namespace Decaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRestDayInScheduleAndLateUndertimeInMinutesInAttendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "LateInMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.Attendances", "UndertimeInMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "SunRestDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "MonRestDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "TueRestDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "WedRestDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "ThuRestDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "FriRestDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "SatRestDay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "SatRestDay");
            DropColumn("dbo.Schedules", "FriRestDay");
            DropColumn("dbo.Schedules", "ThuRestDay");
            DropColumn("dbo.Schedules", "WedRestDay");
            DropColumn("dbo.Schedules", "TueRestDay");
            DropColumn("dbo.Schedules", "MonRestDay");
            DropColumn("dbo.Schedules", "SunRestDay");
            DropColumn("dbo.Attendances", "UndertimeInMinutes");
            DropColumn("dbo.Attendances", "LateInMinutes");
        }
    }
}
