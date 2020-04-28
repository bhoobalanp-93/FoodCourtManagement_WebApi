namespace FoodCourtManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodCourtInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        customer_ID = c.Int(nullable: false),
                        first_Name = c.String(),
                        last_Name = c.String(),
                        cust_ContactNo = c.String(),
                        cust_MailID = c.String(),
                        cust_Address = c.String(),
                    })
                .PrimaryKey(t => t.customer_ID);
            
            CreateTable(
                "dbo.FoodCategory",
                c => new
                    {
                        categoryId = c.Int(nullable: false),
                        categoryType = c.String(),
                    })
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.FoodOrder",
                c => new
                    {
                        Order_ID = c.Int(nullable: false),
                        orderCustomerId = c.Int(nullable: false),
                        OrderPrice = c.Int(nullable: false),
                        paymentMode = c.String(),
                    })
                .PrimaryKey(t => t.Order_ID);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        orderProductKey = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        fProductid = c.Int(nullable: false),
                        productQuantity = c.Int(nullable: false),
                        productPrice = c.Int(nullable: false),
                        FoodOrder_Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.orderProductKey)
                .ForeignKey("dbo.FoodOrder", t => t.FoodOrder_Order_ID)
                .Index(t => t.FoodOrder_Order_ID);
            
            CreateTable(
                "dbo.FoodProduct",
                c => new
                    {
                        foodProductID = c.Int(nullable: false),
                        foodProductName = c.String(),
                        foodProductPrice = c.Int(nullable: false),
                        fProductCatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.foodProductID)
                .ForeignKey("dbo.FoodCategory", t => t.fProductCatId, cascadeDelete: true)
                .Index(t => t.fProductCatId);
            
            CreateTable(
                "dbo.RestaurantMaster",
                c => new
                    {
                        restaurantId = c.Int(nullable: false),
                        restaurantName = c.String(nullable: false),
                        rest_MailID = c.String(),
                        rest_Contactno = c.String(),
                        rest_Website = c.String(),
                        rest_loaction = c.String(),
                        rest_Address = c.String(),
                        rest_DeliveryTime = c.String(),
                        restaurantType_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.restaurantId)
                .ForeignKey("dbo.RestaurantType", t => t.restaurantType_id, cascadeDelete: true)
                .Index(t => t.restaurantType_id);
            
            CreateTable(
                "dbo.RestaurantType",
                c => new
                    {
                        restType_id = c.Int(nullable: false),
                        rest_TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.restType_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantMaster", "restaurantType_id", "dbo.RestaurantType");
            DropForeignKey("dbo.FoodProduct", "fProductCatId", "dbo.FoodCategory");
            DropForeignKey("dbo.OrderProduct", "FoodOrder_Order_ID", "dbo.FoodOrder");
            DropIndex("dbo.RestaurantMaster", new[] { "restaurantType_id" });
            DropIndex("dbo.FoodProduct", new[] { "fProductCatId" });
            DropIndex("dbo.OrderProduct", new[] { "FoodOrder_Order_ID" });
            DropTable("dbo.RestaurantType");
            DropTable("dbo.RestaurantMaster");
            DropTable("dbo.FoodProduct");
            DropTable("dbo.OrderProduct");
            DropTable("dbo.FoodOrder");
            DropTable("dbo.FoodCategory");
            DropTable("dbo.Customer");
        }
    }
}
