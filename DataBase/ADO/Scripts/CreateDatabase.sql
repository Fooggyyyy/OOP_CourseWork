-- Create database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'OOP_CourseWork_ADO')
BEGIN
    CREATE DATABASE OOP_CourseWork_ADO;
END
GO

USE OOP_CourseWork_ADO;
GO

-- Create Products table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Products](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](100) NOT NULL,
        [Description] [nvarchar](500) NULL,
        [Price] [decimal](18, 2) NOT NULL,
        [TypeWear] [int] NOT NULL,
        [Image] [varbinary](max) NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- Create Categories table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Categories](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](50) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- Create ProductCategories table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategories]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ProductCategories](
        [ProductId] [int] NOT NULL,
        [CategoryId] [int] NOT NULL,
        CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED ([ProductId] ASC, [CategoryId] ASC),
        CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE
    );
END
GO

-- Create trigger for product price validation
IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TR_Products_PriceValidation]'))
    DROP TRIGGER [dbo].[TR_Products_PriceValidation];
GO

CREATE TRIGGER [dbo].[TR_Products_PriceValidation]
ON [dbo].[Products]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT 1 FROM inserted WHERE Price <= 0)
    BEGIN
        RAISERROR ('Product price must be greater than zero.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END
GO

-- Create stored procedure for product search
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SearchProducts')
    DROP PROCEDURE [dbo].[SearchProducts];
GO

CREATE PROCEDURE [dbo].[SearchProducts]
    @SearchTerm nvarchar(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT p.*
    FROM Products p
    WHERE p.Name LIKE '%' + @SearchTerm + '%'
       OR p.Description LIKE '%' + @SearchTerm + '%';
END
GO

-- Create stored procedure for getting products by type
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetProductsByType')
    DROP PROCEDURE [dbo].[GetProductsByType];
GO

CREATE PROCEDURE [dbo].[GetProductsByType]
    @TypeWear int
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT p.*
    FROM Products p
    WHERE p.TypeWear = @TypeWear;
END
GO

-- Create stored procedure for getting products by price range
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetProductsByPriceRange')
    DROP PROCEDURE [dbo].[GetProductsByPriceRange];
GO

CREATE PROCEDURE [dbo].[GetProductsByPriceRange]
    @MinPrice decimal(18,2),
    @MaxPrice decimal(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT p.*
    FROM Products p
    WHERE p.Price BETWEEN @MinPrice AND @MaxPrice;
END
GO

-- Insert some default categories
IF NOT EXISTS (SELECT 1 FROM Categories)
BEGIN
    INSERT INTO Categories (Name) VALUES 
    ('Men'),
    ('Women'),
    ('Kids'),
    ('Accessories'),
    ('Sport');
END
GO 