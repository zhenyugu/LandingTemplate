namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitData1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Productions", "Production_SerialNumber_Unique");
            AlterColumn("dbo.Productions", "SerialNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productions", "SerialNumber", c => c.String(nullable: false));
            CreateIndex("dbo.Productions", "SerialNumber", unique: true, name: "Production_SerialNumber_Unique");
        }
    }
}
