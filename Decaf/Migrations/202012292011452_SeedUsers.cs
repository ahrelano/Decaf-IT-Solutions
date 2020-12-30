namespace Decaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserID], [EmployeeID], [FirstName], [MiddleName], [LastName], [BirthDate], [GenderId], [CivilStatusId]) VALUES (N'36b700bf-c53b-4448-a811-3156ca6ff1bb', N'user1@decaf.com', 0, N'AKO2mcE4TXaYjNc5Fs98WSByi/gpxROtS/EP62/kMTkfhkKyifqkMD72wrxMxuR0Sg==', N'b9e5e786-e176-48d8-af97-1e65d7730aa5', NULL, 0, 0, NULL, 1, 0, N'user1', 1, 100001, N'Ace+', N'Asinas+', N'Relano', N'2020-12-25 00:00:00', 1, 5)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserID], [EmployeeID], [FirstName], [MiddleName], [LastName], [BirthDate], [GenderId], [CivilStatusId]) VALUES (N'b5ab3938-ef1e-4c8e-b222-bede109004ef', N'admin@decaf.com', 0, N'AFBLNgutsgwNsrGJ8+fXbDl3FtsbCZz7NQTm6Jk72kPBESiomE5V9cMYmcOODD6tZQ==', N'0df1830c-f53e-4ed0-9daa-e50238171bcd', NULL, 0, 0, NULL, 1, 0, N'admin', 2, 100002, N'Ace', N'Asinas', N'Relano', N'1996-01-12 00:00:00', 1, 5)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e9f0f6a1-15c6-4229-8669-1c635a4add5a', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b5ab3938-ef1e-4c8e-b222-bede109004ef', N'e9f0f6a1-15c6-4229-8669-1c635a4add5a')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
