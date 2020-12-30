namespace Decaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableGenderAndCivilStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CivilStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Genders (Id, Name) VALUES (1, 'Male')");
            Sql("INSERT INTO Genders (Id, Name) VALUES (2, 'Female')");

            Sql("INSERT INTO CivilStatus (Id, Name) VALUES (1, 'Married')");
            Sql("INSERT INTO CivilStatus (Id, Name) VALUES (2, 'Widowed')");
            Sql("INSERT INTO CivilStatus (Id, Name) VALUES (3, 'Separated')");
            Sql("INSERT INTO CivilStatus (Id, Name) VALUES (4, 'Divorced')");
            Sql("INSERT INTO CivilStatus (Id, Name) VALUES (5, 'Single')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Genders");
            DropTable("dbo.CivilStatus");
        }
    }
}
