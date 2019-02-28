namespace SikayetSitesiMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "TasitTuru", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "TasitTuru", c => c.String());
        }
    }
}
