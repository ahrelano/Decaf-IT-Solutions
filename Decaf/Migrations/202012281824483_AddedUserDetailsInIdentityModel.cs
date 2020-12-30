namespace Decaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserDetailsInIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeID", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "MiddleName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "GenderId", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "CivilStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.AspNetUsers", "GenderId");
            CreateIndex("dbo.AspNetUsers", "CivilStatusId");
            AddForeignKey("dbo.AspNetUsers", "CivilStatusId", "dbo.CivilStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.AspNetUsers", "CivilStatusId", "dbo.CivilStatus");
            DropIndex("dbo.AspNetUsers", new[] { "CivilStatusId" });
            DropIndex("dbo.AspNetUsers", new[] { "GenderId" });
            DropColumn("dbo.AspNetUsers", "CivilStatusId");
            DropColumn("dbo.AspNetUsers", "GenderId");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "MiddleName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "EmployeeID");
        }
    }
}
