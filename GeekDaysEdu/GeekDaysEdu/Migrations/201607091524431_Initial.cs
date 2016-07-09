namespace GeekDaysEdu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        CommentID = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Userid = c.String(),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.ResourceModels",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        URL = c.String(),
                        Disciption = c.String(),
                        LinkToImg = c.String(),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResourceModels");
            DropTable("dbo.CommentModels");
        }
    }
}
