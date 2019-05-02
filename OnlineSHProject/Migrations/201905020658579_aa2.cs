namespace OnlineSHProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Product_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Products", "ShopOwner_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "ShopOwner_Id");
            AddForeignKey("dbo.Products", "ShopOwner_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "ShopOwner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "ShopOwner_Id" });
            DropColumn("dbo.Products", "ShopOwner_Id");
            DropTable("dbo.Orders");
        }
    }
}
