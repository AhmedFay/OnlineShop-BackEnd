namespace OnlineSHProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        ProductAmount = c.String(),
                        Product_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ProductsHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        PurchasedProduct_Id = c.Int(),
                        Purchaser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.PurchasedProduct_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Purchaser_Id)
                .Index(t => t.PurchasedProduct_Id)
                .Index(t => t.Purchaser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsHistories", "Purchaser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsHistories", "PurchasedProduct_Id", "dbo.Products");
            DropForeignKey("dbo.ProductsCarts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsCarts", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductsHistories", new[] { "Purchaser_Id" });
            DropIndex("dbo.ProductsHistories", new[] { "PurchasedProduct_Id" });
            DropIndex("dbo.ProductsCarts", new[] { "User_Id" });
            DropIndex("dbo.ProductsCarts", new[] { "Product_Id" });
            DropTable("dbo.ProductsHistories");
            DropTable("dbo.ProductsCarts");
        }
    }
}
