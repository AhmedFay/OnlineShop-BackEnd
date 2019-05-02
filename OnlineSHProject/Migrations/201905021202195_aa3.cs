namespace OnlineSHProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagePath1", c => c.String());
            AddColumn("dbo.Products", "ImagePath2", c => c.String());
            DropColumn("dbo.Products", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            DropColumn("dbo.Products", "ImagePath2");
            DropColumn("dbo.Products", "ImagePath1");
        }
    }
}
