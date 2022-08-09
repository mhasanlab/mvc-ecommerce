namespace MyEcommerceAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admin_Employee",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateofBirth = c.DateTime(),
                        Gender = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.EmpID);
            
            CreateTable(
                "dbo.admin_Login",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        EmpID = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleType = c.Int(),
                        Notes = c.String(),
                        Role_RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.LoginID)
                .ForeignKey("dbo.admin_Employee", t => t.EmpID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleID)
                .Index(t => t.EmpID)
                .Index(t => t.Role_RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        isActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.genPromoRights",
                c => new
                    {
                        PromoRightID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ImageURL = c.String(),
                        AltText = c.String(),
                        OfferTag = c.String(),
                        Title = c.String(),
                        isDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.PromoRightID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SupplierID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        SubCategoryID = c.Int(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        UnitInStock = c.Int(),
                        ProductAvailable = c.Boolean(),
                        ShortDescription = c.String(),
                        PicturePath = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        OrderDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderDetailsID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PaymentID = c.Int(),
                        ShippingID = c.Int(),
                        Discount = c.Int(),
                        Taxes = c.Int(),
                        TotalAmount = c.Int(),
                        isCompleted = c.Boolean(),
                        OrderDate = c.DateTime(),
                        DIspatched = c.Boolean(),
                        DispatchedDate = c.DateTime(),
                        Shipped = c.Boolean(),
                        ShippingDate = c.DateTime(),
                        Deliver = c.Boolean(),
                        DeliveryDate = c.DateTime(),
                        Notes = c.String(),
                        CancelOrder = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentID)
                .ForeignKey("dbo.ShippingDetails", t => t.ShippingID)
                .Index(t => t.CustomerID)
                .Index(t => t.PaymentID)
                .Index(t => t.ShippingID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Gender = c.String(),
                        DateofBirth = c.DateTime(),
                        Country = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        PicturePath = c.String(),
                        status = c.String(),
                        LastLogin = c.DateTime(),
                        Created = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.RecentlyViews",
                c => new
                    {
                        RViewID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        ViewDate = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.RViewID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        ProductID = c.Int(),
                        Name = c.String(),
                        Email = c.String(),
                        Review1 = c.String(),
                        Rate = c.Int(),
                        DateTime = c.DateTime(),
                        isDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        WishlistID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        isActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.WishlistID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        CreditAmount = c.Decimal(precision: 18, scale: 2),
                        DebitAmount = c.Decimal(precision: 18, scale: 2),
                        Balance = c.Decimal(precision: 18, scale: 2),
                        PaymentDateTime = c.DateTime(),
                        PaymentType_PayTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentType_PayTypeID)
                .Index(t => t.PaymentType_PayTypeID);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PayTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PayTypeID);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ShippingID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.ShippingID);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        isActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        ContactName = c.String(nullable: false),
                        ContactTitle = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.genMainSliders",
                c => new
                    {
                        MainSliderID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        AltText = c.String(),
                        OfferTag = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        BtnText = c.String(),
                        isDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.MainSliderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "ShippingID", "dbo.ShippingDetails");
            DropForeignKey("dbo.Payments", "PaymentType_PayTypeID", "dbo.PaymentTypes");
            DropForeignKey("dbo.Orders", "PaymentID", "dbo.Payments");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Wishlists", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Wishlists", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Reviews", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.RecentlyViews", "ProductID", "dbo.Products");
            DropForeignKey("dbo.RecentlyViews", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.genPromoRights", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.admin_Login", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.admin_Login", "EmpID", "dbo.admin_Employee");
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropIndex("dbo.Payments", new[] { "PaymentType_PayTypeID" });
            DropIndex("dbo.Wishlists", new[] { "ProductID" });
            DropIndex("dbo.Wishlists", new[] { "CustomerID" });
            DropIndex("dbo.Reviews", new[] { "ProductID" });
            DropIndex("dbo.Reviews", new[] { "CustomerID" });
            DropIndex("dbo.RecentlyViews", new[] { "ProductID" });
            DropIndex("dbo.RecentlyViews", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "ShippingID" });
            DropIndex("dbo.Orders", new[] { "PaymentID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "SubCategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropIndex("dbo.genPromoRights", new[] { "CategoryID" });
            DropIndex("dbo.admin_Login", new[] { "Role_RoleID" });
            DropIndex("dbo.admin_Login", new[] { "EmpID" });
            DropTable("dbo.genMainSliders");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SubCategories");
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.Wishlists");
            DropTable("dbo.Reviews");
            DropTable("dbo.RecentlyViews");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.genPromoRights");
            DropTable("dbo.Categories");
            DropTable("dbo.Roles");
            DropTable("dbo.admin_Login");
            DropTable("dbo.admin_Employee");
        }
    }
}
