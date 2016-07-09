namespace GeekDaysEdu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ResourceModel_ResourceId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.ResourceModels", t => t.ResourceModel_ResourceId)
                .Index(t => t.ResourceModel_ResourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryModels", "ResourceModel_ResourceId", "dbo.ResourceModels");
            DropIndex("dbo.CategoryModels", new[] { "ResourceModel_ResourceId" });
            DropTable("dbo.CategoryModels");
        }
    }
}
