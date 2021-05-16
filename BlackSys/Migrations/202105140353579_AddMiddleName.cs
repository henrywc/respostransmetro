namespace BlackSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMiddleName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccesoModels",
                c => new
                    {
                        idestacion = c.Int(nullable: false, identity: true),
                        nombre_acceso = c.String(nullable: false, maxLength: 50),
                        idacceso = c.Int(),
                    })
                .PrimaryKey(t => t.idestacion);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomPermission",
                c => new
                    {
                        CustomPermissionID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        MenuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomPermissionID)
                .ForeignKey("dbo.Menu", t => t.MenuID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        ParentMenuID = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        MenuURL = c.String(maxLength: 100),
                        MenuIcon = c.String(maxLength: 25),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        RoleID = c.String(nullable: false, maxLength: 128),
                        MenuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionID)
                .ForeignKey("dbo.Menu", t => t.MenuID)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleID)
                .Index(t => t.RoleID)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.BusModels",
                c => new
                    {
                        idpiloto = c.Int(nullable: false, identity: true),
                        nombre_bus = c.String(nullable: false, maxLength: 50),
                        idlinea = c.Int(nullable: false),
                        capacidad = c.Int(nullable: false),
                        idparqueo = c.Int(nullable: false),
                        idbus = c.Int(),
                    })
                .PrimaryKey(t => t.idpiloto);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.Component",
                c => new
                    {
                        ComponentID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        ComponentCategoryID = c.Int(nullable: false),
                        UomID = c.Int(nullable: false),
                        CustomerID = c.Int(),
                        CustomerCode = c.String(maxLength: 50),
                        CountryOfOrigin = c.String(maxLength: 100),
                        SupplierID = c.Int(),
                        SupplierCode = c.String(maxLength: 50),
                        Description2 = c.String(maxLength: 200),
                        PurchasingPrice = c.Decimal(nullable: false, storeType: "money"),
                        PurchasingTerms = c.String(maxLength: 50),
                        ListPrice = c.Decimal(nullable: false, storeType: "money"),
                        HtsID = c.Int(),
                        SacID = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        DiscontinuedDate = c.DateTime(),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                        rowguid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ComponentID)
                .ForeignKey("dbo.ComponentCategory", t => t.ComponentCategoryID)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID)
                .ForeignKey("dbo.UnitMeasure", t => t.UomID)
                .Index(t => t.ComponentCategoryID)
                .Index(t => t.UomID)
                .Index(t => t.CustomerID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.ComponentCategory",
                c => new
                    {
                        ComponentCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                        rowguid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ComponentCategoryID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        rowguid = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 25),
                        Code = c.Int(),
                        CompanyName = c.String(nullable: false, maxLength: 125),
                        NRC = c.String(maxLength: 25),
                        NIT = c.String(maxLength: 18),
                        CreationDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        rowguid = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 25),
                        Code = c.Int(),
                        CompanyName = c.String(nullable: false, maxLength: 125),
                        NRC = c.String(maxLength: 25),
                        NIT = c.String(maxLength: 18),
                        CreationDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.UnitMeasure",
                c => new
                    {
                        UomID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UomID);
            
            CreateTable(
                "dbo.ConsultarAccesoes",
                c => new
                    {
                        idacceso = c.Int(nullable: false, identity: true),
                        nombre_acceso = c.String(),
                        nombre_estacion = c.String(),
                    })
                .PrimaryKey(t => t.idacceso);
            
            CreateTable(
                "dbo.ConsultarBus",
                c => new
                    {
                        idbus = c.Int(nullable: false, identity: true),
                        nombre_bus = c.String(),
                        nombre_linea = c.String(),
                        nombre_estacion = c.String(),
                        capacidad = c.Int(nullable: false),
                        nombre_parqueo = c.String(),
                        nombre_piloto = c.String(),
                    })
                .PrimaryKey(t => t.idbus);
            
            CreateTable(
                "dbo.ConsultarDistancias",
                c => new
                    {
                        iddistancia = c.Int(nullable: false, identity: true),
                        estacion_origen = c.String(),
                        estacion_destino = c.String(),
                        distancia = c.Int(nullable: false),
                        nombre_linea = c.String(),
                    })
                .PrimaryKey(t => t.iddistancia);
            
            CreateTable(
                "dbo.ConsultarEstacions",
                c => new
                    {
                        idestacion = c.Int(nullable: false, identity: true),
                        nombre_estacion = c.String(),
                        capacidad = c.Int(nullable: false),
                        nombre_municipalidad = c.String(),
                    })
                .PrimaryKey(t => t.idestacion);
            
            CreateTable(
                "dbo.ConsultarGuardias",
                c => new
                    {
                        idguardia = c.Int(nullable: false, identity: true),
                        nombre_guardia = c.String(),
                        direccion_guardia = c.String(),
                        correo_guardia = c.String(),
                        edad_guardia = c.Int(nullable: false),
                        telefono_guardia = c.Int(nullable: false),
                        celular_guardia = c.Int(nullable: false),
                        nombre_acceso = c.String(),
                    })
                .PrimaryKey(t => t.idguardia);
            
            CreateTable(
                "dbo.ConsultarLineas",
                c => new
                    {
                        idlinea = c.Int(nullable: false, identity: true),
                        nombre_linea = c.String(),
                        nombre_municipalidad = c.String(),
                    })
                .PrimaryKey(t => t.idlinea);
            
            CreateTable(
                "dbo.ConsultarParqueos",
                c => new
                    {
                        idparqueo = c.Int(nullable: false, identity: true),
                        nombre_parqueo = c.String(),
                        nombre_estacion = c.String(),
                    })
                .PrimaryKey(t => t.idparqueo);
            
            CreateTable(
                "dbo.ConsultarPilotoDireccions",
                c => new
                    {
                        idpilotos_direccion = c.Int(nullable: false, identity: true),
                        direccion_piloto = c.String(),
                        zona_piloto = c.String(),
                        colonia_piloto = c.String(),
                        municipio_piloto = c.String(),
                        departamento_piloto = c.String(),
                        nombre_piloto = c.String(),
                    })
                .PrimaryKey(t => t.idpilotos_direccion);
            
            CreateTable(
                "dbo.ConsultarPilotoEducacions",
                c => new
                    {
                        idpilotos_educacion = c.Int(nullable: false, identity: true),
                        nivelcursado = c.String(),
                        fechanivelcursado = c.String(),
                        centroeducativo = c.String(),
                        nombre_piloto = c.String(),
                    })
                .PrimaryKey(t => t.idpilotos_educacion);
            
            CreateTable(
                "dbo.DistanciaModels",
                c => new
                    {
                        idlinea = c.Int(nullable: false, identity: true),
                        idorigen = c.Int(nullable: false),
                        iddestino = c.Int(nullable: false),
                        distancia = c.Int(nullable: false),
                        iddistancia = c.Int(),
                    })
                .PrimaryKey(t => t.idlinea);
            
            CreateTable(
                "dbo.EstacionModels",
                c => new
                    {
                        idmunicipalidad = c.Int(nullable: false, identity: true),
                        nombre_estacion = c.String(nullable: false, maxLength: 50),
                        capacidad = c.Int(nullable: false),
                        idestacion = c.Int(),
                    })
                .PrimaryKey(t => t.idmunicipalidad);
            
            CreateTable(
                "dbo.Fabric",
                c => new
                    {
                        FabricID = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        CategoryID = c.Int(nullable: false),
                        UnitOfMeasurementID = c.Int(nullable: false),
                        PurchasingPrice = c.Decimal(nullable: false, storeType: "money"),
                        IsActive = c.Boolean(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        CustomerID = c.Int(),
                        CustomerCode = c.String(maxLength: 50),
                        CountryOfOrigin = c.String(maxLength: 100),
                        SupplierID = c.Int(),
                        SupplierCode = c.String(maxLength: 50),
                        Description2 = c.String(maxLength: 200),
                        Width = c.String(maxLength: 15),
                        UnitWeight = c.String(maxLength: 5),
                        Weight = c.String(maxLength: 10),
                        Blend = c.String(maxLength: 150),
                        Construction = c.String(maxLength: 200),
                        CutDirection = c.String(maxLength: 150),
                        FabricType = c.String(maxLength: 15),
                        PurchasingTerms = c.String(maxLength: 50),
                        HtsID = c.Int(),
                        SacID = c.Int(),
                        DiscontinuedDate = c.DateTime(),
                        CreationDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FabricID, t.Code, t.Description, t.CategoryID, t.UnitOfMeasurementID, t.PurchasingPrice, t.IsActive, t.rowguid });
            
            CreateTable(
                "dbo.FabricCategory",
                c => new
                    {
                        FabricCategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 128),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FabricCategoryID, t.Name, t.Description, t.CreationDate, t.CreatedBy, t.rowguid });
            
            CreateTable(
                "dbo.GuardiaModels",
                c => new
                    {
                        idacceso = c.Int(nullable: false, identity: true),
                        nombre_guardia = c.String(nullable: false, maxLength: 50),
                        direccion_guardia = c.String(nullable: false, maxLength: 50),
                        correo_guardia = c.String(nullable: false),
                        edad_guardia = c.Int(nullable: false),
                        telefono_guardia = c.Int(nullable: false),
                        celular_guardia = c.Int(nullable: false),
                        idguardia = c.Int(),
                    })
                .PrimaryKey(t => t.idacceso);
            
            CreateTable(
                "dbo.LineaModels",
                c => new
                    {
                        idmunicipalidad = c.Int(nullable: false, identity: true),
                        nombre_linea = c.String(nullable: false, maxLength: 50),
                        idlinea = c.Int(),
                    })
                .PrimaryKey(t => t.idmunicipalidad);
            
            CreateTable(
                "dbo.MenuTemp",
                c => new
                    {
                        MenuID = c.Int(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        ParentMenuID = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        MenuURL = c.String(maxLength: 100),
                        MenuIcon = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => new { t.MenuID, t.DisplayName, t.ParentMenuID, t.OrderNumber });
            
            CreateTable(
                "dbo.MUNICIPALIDADES",
                c => new
                    {
                        idmunicipalidad = c.Int(nullable: false, identity: true),
                        nombre_municipalidad = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.idmunicipalidad);
            
            CreateTable(
                "dbo.ParqueoModels",
                c => new
                    {
                        idestacion = c.Int(nullable: false, identity: true),
                        nombre_parqueo = c.String(nullable: false, maxLength: 50),
                        idparqueo = c.Int(),
                    })
                .PrimaryKey(t => t.idestacion);
            
            CreateTable(
                "dbo.PermissionMenus",
                c => new
                    {
                        MenuID = c.Int(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        ParentMenuID = c.Int(nullable: false),
                        PermissionType = c.Int(nullable: false),
                        Permission = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuID, t.DisplayName, t.ParentMenuID });
            
            CreateTable(
                "dbo.PilotoDireccionModels",
                c => new
                    {
                        idpiloto = c.Int(nullable: false, identity: true),
                        direccion_piloto = c.String(nullable: false, maxLength: 50),
                        zona_piloto = c.String(nullable: false, maxLength: 50),
                        colonia_piloto = c.String(nullable: false, maxLength: 50),
                        municipio_piloto = c.String(nullable: false, maxLength: 50),
                        departamento_piloto = c.String(nullable: false, maxLength: 50),
                        idpilotos_direccion = c.Int(),
                    })
                .PrimaryKey(t => t.idpiloto);
            
            CreateTable(
                "dbo.PilotoEducacionModels",
                c => new
                    {
                        idpiloto = c.Int(nullable: false, identity: true),
                        nivelcursado = c.String(nullable: false, maxLength: 50),
                        fechanivelcursado = c.String(nullable: false, maxLength: 4),
                        centroeducativo = c.String(nullable: false, maxLength: 50),
                        idpilotos_educacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idpiloto);
            
            CreateTable(
                "dbo.PILOTOS",
                c => new
                    {
                        idpiloto = c.Int(nullable: false, identity: true),
                        nombre_piloto = c.String(nullable: false, maxLength: 50),
                        direccion_piloto = c.String(nullable: false, maxLength: 50),
                        correo_piloto = c.String(nullable: false, maxLength: 50),
                        edad_piloto = c.Int(nullable: false),
                        telefono_piloto = c.Int(nullable: false),
                        celular_piloto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idpiloto);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        Style = c.String(nullable: false, maxLength: 50),
                        ProductNumber = c.String(nullable: false, maxLength: 25),
                        MakeFlag = c.Boolean(nullable: false),
                        FinishedGoodsFlag = c.Boolean(nullable: false),
                        SafetyStockLevel = c.Short(nullable: false),
                        StandardCost = c.Decimal(nullable: false, storeType: "money"),
                        ListPrice = c.Decimal(nullable: false, storeType: "money"),
                        DaysToManufacture = c.Int(nullable: false),
                        SellStartDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 128),
                        rowguid = c.Guid(nullable: false),
                        Color = c.String(maxLength: 25),
                        WeightUnitMeasureCode = c.String(maxLength: 5, fixedLength: true),
                        Weight = c.Decimal(precision: 8, scale: 2),
                        ProductLineID = c.Int(),
                        ProductCategory = c.Int(),
                        SellEndDate = c.DateTime(),
                        DiscontinuedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProductID, t.Style, t.ProductNumber, t.MakeFlag, t.FinishedGoodsFlag, t.SafetyStockLevel, t.StandardCost, t.ListPrice, t.DaysToManufacture, t.SellStartDate, t.CreationDate, t.CreatedBy, t.rowguid });
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 128),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProductCategoryID, t.Name, t.Description, t.CreationDate, t.CreatedBy, t.rowguid });
            
            CreateTable(
                "dbo.ProductPhoto",
                c => new
                    {
                        ProductPhotoID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ThumbNailPhoto = c.Binary(),
                        ThumbnailPhotoFileName = c.String(maxLength: 50),
                        LargePhoto = c.Binary(),
                        LargePhotoFileName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ProductPhotoID, t.ModifiedDate });
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Component", "UomID", "dbo.UnitMeasure");
            DropForeignKey("dbo.Component", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Component", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Component", "ComponentCategoryID", "dbo.ComponentCategory");
            DropForeignKey("dbo.Permission", "RoleID", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CustomPermission", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permission", "MenuID", "dbo.Menu");
            DropForeignKey("dbo.CustomPermission", "MenuID", "dbo.Menu");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Component", new[] { "SupplierID" });
            DropIndex("dbo.Component", new[] { "CustomerID" });
            DropIndex("dbo.Component", new[] { "UomID" });
            DropIndex("dbo.Component", new[] { "ComponentCategoryID" });
            DropIndex("dbo.Permission", new[] { "MenuID" });
            DropIndex("dbo.Permission", new[] { "RoleID" });
            DropIndex("dbo.CustomPermission", new[] { "MenuID" });
            DropIndex("dbo.CustomPermission", new[] { "UserID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ProductPhoto");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.PILOTOS");
            DropTable("dbo.PilotoEducacionModels");
            DropTable("dbo.PilotoDireccionModels");
            DropTable("dbo.PermissionMenus");
            DropTable("dbo.ParqueoModels");
            DropTable("dbo.MUNICIPALIDADES");
            DropTable("dbo.MenuTemp");
            DropTable("dbo.LineaModels");
            DropTable("dbo.GuardiaModels");
            DropTable("dbo.FabricCategory");
            DropTable("dbo.Fabric");
            DropTable("dbo.EstacionModels");
            DropTable("dbo.DistanciaModels");
            DropTable("dbo.ConsultarPilotoEducacions");
            DropTable("dbo.ConsultarPilotoDireccions");
            DropTable("dbo.ConsultarParqueos");
            DropTable("dbo.ConsultarLineas");
            DropTable("dbo.ConsultarGuardias");
            DropTable("dbo.ConsultarEstacions");
            DropTable("dbo.ConsultarDistancias");
            DropTable("dbo.ConsultarBus");
            DropTable("dbo.ConsultarAccesoes");
            DropTable("dbo.UnitMeasure");
            DropTable("dbo.Supplier");
            DropTable("dbo.Customer");
            DropTable("dbo.ComponentCategory");
            DropTable("dbo.Component");
            DropTable("dbo.Colors");
            DropTable("dbo.BusModels");
            DropTable("dbo.Permission");
            DropTable("dbo.Menu");
            DropTable("dbo.CustomPermission");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AccesoModels");
        }
    }
}
