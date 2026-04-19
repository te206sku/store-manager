CREATE TABLE [dbo].[Store] (
    [StoreId] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [StoreClass] NVARCHAR(100) NOT NULL,
    [StoreNumber] INT NOT NULL,
    [Address] NVARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([StoreId] ASC)
);
GO

CREATE TABLE [dbo].[Department] (
    [DepartmentId] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [ManagerName] NVARCHAR(100) NOT NULL,
    [StoreId] BIGINT NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([DepartmentId] ASC),
    CONSTRAINT [FK_Department_Store]
        FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store]([StoreId])
);
GO

CREATE TABLE [dbo].[Supplier] (
    [SupplierId] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Address] NVARCHAR(200) NOT NULL,
    [Phone] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED ([SupplierId] ASC)
);
GO

CREATE TABLE [dbo].[ProductCategory] (
    [ProductCategoryId] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED ([ProductCategoryId] ASC)
);
GO

CREATE TABLE [dbo].[Product] (
    [ProductId] BIGINT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Sort] NVARCHAR(100) NOT NULL,
    [ProductCategoryId] BIGINT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_ProductCategory]
        FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory]([ProductCategoryId])
);
GO

CREATE TABLE [dbo].[DepartmentProduct] (
    [DepartmentProductId] BIGINT IDENTITY(1,1) NOT NULL,
    [DepartmentId] BIGINT NULL,
    [ProductId] BIGINT NULL,
    [Price] INT NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT [PK_DepartmentProduct] PRIMARY KEY CLUSTERED ([DepartmentProductId] ASC),
    CONSTRAINT [FK_DepartmentProduct_Department]
        FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department]([DepartmentId]),
    CONSTRAINT [FK_DepartmentProduct_Product]
        FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId])
);
GO

CREATE TABLE [dbo].[SupplierProduct] (
    [SupplierProductId] BIGINT IDENTITY(1,1) NOT NULL,
    [SupplierId] BIGINT NULL,
    [ProductId] BIGINT NULL,
    [Price] INT NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT [PK_SupplierProduct] PRIMARY KEY CLUSTERED ([SupplierProductId] ASC),
    CONSTRAINT [FK_SupplierProduct_Supplier]
        FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId]),
    CONSTRAINT [FK_SupplierProduct_Product]
        FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId])
);
GO

CREATE TABLE [dbo].[Purchase] (
    [PurchaseId] BIGINT IDENTITY(1,1) NOT NULL,
    [PurchaseDate] DATETIME NOT NULL,
    [StoreId] BIGINT NULL,
    [SupplierId] BIGINT NULL,
    CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED ([PurchaseId] ASC),
    CONSTRAINT [FK_Purchase_Store]
        FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store]([StoreId]),
    CONSTRAINT [FK_Purchase_Supplier]
        FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId])
);
GO

CREATE TABLE [dbo].[PurchaseItem] (
    [PurchaseItemId] BIGINT IDENTITY(1,1) NOT NULL,
    [PurchaseId] BIGINT NULL,
    [ProductId] BIGINT NULL,
    [Price] INT NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT [PK_PurchaseItem] PRIMARY KEY CLUSTERED ([PurchaseItemId] ASC),
    CONSTRAINT [FK_PurchaseItem_Purchase]
        FOREIGN KEY ([PurchaseId]) REFERENCES [dbo].[Purchase]([PurchaseId]),
    CONSTRAINT [FK_PurchaseItem_Product]
        FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId])
);
GO

CREATE TABLE [dbo].[Sale] (
    [SaleId] BIGINT IDENTITY(1,1) NOT NULL,
    [SaleDate] DATETIME NOT NULL,
    [StoreId] BIGINT NULL,
    [DepartmentId] BIGINT NULL,
    CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED ([SaleId] ASC),
    CONSTRAINT [FK_Sale_Store]
        FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store]([StoreId]),
    CONSTRAINT [FK_Sale_Department]
        FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department]([DepartmentId])
);
GO

CREATE TABLE [dbo].[SaleItem] (
    [SaleItemId] BIGINT IDENTITY(1,1) NOT NULL,
    [SaleId] BIGINT NULL,
    [ProductId] BIGINT NULL,
    [Price] INT NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT [PK_SaleItem] PRIMARY KEY CLUSTERED ([SaleItemId] ASC),
    CONSTRAINT [FK_SaleItem_Sale]
        FOREIGN KEY ([SaleId]) REFERENCES [dbo].[Sale]([SaleId]),
    CONSTRAINT [FK_SaleItem_Product]
        FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId])
);
GO