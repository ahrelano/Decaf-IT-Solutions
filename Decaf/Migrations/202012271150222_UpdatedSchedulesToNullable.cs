namespace Decaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSchedulesToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "SunShiftFrom", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "SunShiftTo", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "MonShiftFrom", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "MonShiftTo", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "TueShiftFrom", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "TueShiftTo", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "WedShiftFrom", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "WedShiftTo", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "ThuShiftFrom", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "ThuShiftTo", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "FriShiftFrom", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "FriShiftTo", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "SatShiftFrom", c => c.Time(precision: 7));
            AlterColumn("dbo.Schedules", "SatShiftTo", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "SatShiftTo", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "SatShiftFrom", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "FriShiftTo", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "FriShiftFrom", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "ThuShiftTo", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "ThuShiftFrom", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "WedShiftTo", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "WedShiftFrom", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "TueShiftTo", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "TueShiftFrom", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "MonShiftTo", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "MonShiftFrom", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "SunShiftTo", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "SunShiftFrom", c => c.Time(nullable: false, precision: 7));
        }
    }
}
