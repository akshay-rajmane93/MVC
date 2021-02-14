namespace Movieship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberShip : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShips(MonthDuration,SignupFee,MenberShipType) VALUES (0,0,'Pay as you go')");
            Sql("INSERT INTO MemberShips(MonthDuration,SignupFee,MenberShipType) VALUES (1,30,'Monthly')");
            Sql("INSERT INTO MemberShips(MonthDuration,SignupFee,MenberShipType) VALUES (3,90,'Quarterly')");
            Sql("INSERT INTO MemberShips(MonthDuration,SignupFee,MenberShipType) VALUES (12,300,'Annualy')");
        }
        
        public override void Down()
        {
        }
    }
}
