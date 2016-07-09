namespace GeekDaysEdu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewConnectionBetweenCategoryAndCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryModels", "ResourceModel_ResourceId", "dbo.ResourceModels");
            DropIndex("dbo.CategoryModels", new[] { "ResourceModel_ResourceId" });
            AddColumn("dbo.ResourceModels", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.ResourceModels", "Category_CategoryID");
            AddForeignKey("dbo.ResourceModels", "Category_CategoryID", "dbo.CategoryModels", "CategoryID");
            DropColumn("dbo.CategoryModels", "ResourceModel_ResourceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryModels", "ResourceModel_ResourceId", c => c.Int());
            DropForeignKey("dbo.ResourceModels", "Category_CategoryID", "dbo.CategoryModels");
            DropIndex("dbo.ResourceModels", new[] { "Category_CategoryID" });
            DropColumn("dbo.ResourceModels", "Category_CategoryID");
            CreateIndex("dbo.CategoryModels", "ResourceModel_ResourceId");
            AddForeignKey("dbo.CategoryModels", "ResourceModel_ResourceId", "dbo.ResourceModels", "ResourceId");
        }
    }
}
