namespace GeekDaysEdu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        Time = c.String(),
                        Link_LinkId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Links", t => t.Link_LinkId)
                .Index(t => t.Link_LinkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "Link_LinkId", "dbo.Links");
            DropIndex("dbo.Schedules", new[] { "Link_LinkId" });
            DropTable("dbo.Schedules");
        }
    }
}
