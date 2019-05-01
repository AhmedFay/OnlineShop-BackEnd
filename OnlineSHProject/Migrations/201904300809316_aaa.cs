namespace OnlineSHProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductsCarts", "ProductAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductsCarts", "ProductAmount", c => c.String());
        }
    }
}
