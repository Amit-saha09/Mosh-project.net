namespace DvdCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForMembership : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name, Duration, Cost, Discount) VALUES ('Pay As You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Name, Duration, Cost, Discount) VALUES ('Monthly', 1, 100, 10)");
            Sql("INSERT INTO MembershipTypes (Name, Duration, Cost, Discount) VALUES ('Half Yearly', 6, 800, 30)");
            Sql("INSERT INTO MembershipTypes (Name, Duration, Cost, Discount) VALUES ('Yearly', 12, 1000, 50)");
        }
        
        public override void Down()
        {
        }
    }
}
