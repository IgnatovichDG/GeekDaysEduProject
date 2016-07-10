namespace GeekDaysEdu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkForCourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        LinkId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Status = c.Int(nullable: false),
                        ResourceModel_ResourceId = c.Int(),
                    })
                .PrimaryKey(t => t.LinkId)
                .ForeignKey("dbo.ResourceModels", t => t.ResourceModel_ResourceId)
                .Index(t => t.ResourceModel_ResourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "ResourceModel_ResourceId", "dbo.ResourceModels");
            DropIndex("dbo.Links", new[] { "ResourceModel_ResourceId" });
            DropTable("dbo.Links");
        }
    }
}
