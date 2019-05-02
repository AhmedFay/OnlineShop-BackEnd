namespace OnlineSHProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductsCarts", "DeliveryDate");
            DropColumn("dbo.ProductsCarts", "ExpireDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductsCarts", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductsCarts", "DeliveryDate", c => c.DateTime(nullable: false));
        }
    }
}
