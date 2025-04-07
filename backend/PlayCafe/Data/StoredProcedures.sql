-- Category Procedures
CREATE OR ALTER PROCEDURE sp_GetAllCategories
AS
BEGIN
    SELECT Id, Name, Description
    FROM Categories
END
GO

CREATE OR ALTER PROCEDURE sp_GetCategoryById
    @Id int
AS
BEGIN
    SELECT Id, Name, Description
    FROM Categories
    WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE sp_CreateCategory
    @Name nvarchar(100),
    @Description nvarchar(500),
    @Id int OUTPUT
AS
BEGIN
    INSERT INTO Categories (Name, Description)
    VALUES (@Name, @Description)
    
    SET @Id = SCOPE_IDENTITY()
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateCategory
    @Id int,
    @Name nvarchar(100),
    @Description nvarchar(500)
AS
BEGIN
    UPDATE Categories
    SET Name = @Name,
        Description = @Description
    WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteCategory
    @Id int
AS
BEGIN
    DELETE FROM Categories
    WHERE Id = @Id
END
GO

-- SubCategory Procedures
CREATE OR ALTER PROCEDURE sp_GetAllSubCategories
AS
BEGIN
    SELECT Id, Name, Description, CategoryId
    FROM SubCategories
END
GO

CREATE OR ALTER PROCEDURE sp_GetSubCategoriesByCategoryId
    @CategoryId int
AS
BEGIN
    SELECT Id, Name, Description, CategoryId
    FROM SubCategories
    WHERE CategoryId = @CategoryId
END
GO

CREATE OR ALTER PROCEDURE sp_GetSubCategoryById
    @Id int
AS
BEGIN
    SELECT Id, Name, Description, CategoryId
    FROM SubCategories
    WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE sp_CreateSubCategory
    @Name nvarchar(100),
    @Description nvarchar(500),
    @CategoryId int,
    @Id int OUTPUT
AS
BEGIN
    INSERT INTO SubCategories (Name, Description, CategoryId)
    VALUES (@Name, @Description, @CategoryId)
    
    SET @Id = SCOPE_IDENTITY()
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateSubCategory
    @Id int,
    @Name nvarchar(100),
    @Description nvarchar(500),
    @CategoryId int
AS
BEGIN
    UPDATE SubCategories
    SET Name = @Name,
        Description = @Description,
        CategoryId = @CategoryId
    WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteSubCategory
    @Id int
AS
BEGIN
    DELETE FROM SubCategories
    WHERE Id = @Id
END
GO

-- Product Procedures
CREATE OR ALTER PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT Id, Name, Description, Price, ImageUrl, IsAvailable, CreatedAt, SubCategoryId
    FROM Products
END
GO

CREATE OR ALTER PROCEDURE sp_GetProductsBySubCategoryId
    @SubCategoryId int
AS
BEGIN
    SELECT Id, Name, Description, Price, ImageUrl, IsAvailable, CreatedAt, SubCategoryId
    FROM Products
    WHERE SubCategoryId = @SubCategoryId
END
GO

CREATE OR ALTER PROCEDURE sp_GetProductById
    @Id int
AS
BEGIN
    SELECT Id, Name, Description, Price, ImageUrl, IsAvailable, CreatedAt, SubCategoryId
    FROM Products
    WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE sp_CreateProduct
    @Name nvarchar(200),
    @Description nvarchar(2000),
    @Price decimal(18,2),
    @ImageUrl nvarchar(max),
    @IsAvailable bit,
    @SubCategoryId int,
    @Id int OUTPUT
AS
BEGIN
    INSERT INTO Products (Name, Description, Price, ImageUrl, IsAvailable, CreatedAt, SubCategoryId)
    VALUES (@Name, @Description, @Price, @ImageUrl, @IsAvailable, GETUTCDATE(), @SubCategoryId)
    
    SET @Id = SCOPE_IDENTITY()
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateProduct
    @Id int,
    @Name nvarchar(200),
    @Description nvarchar(2000),
    @Price decimal(18,2),
    @ImageUrl nvarchar(max),
    @IsAvailable bit,
    @SubCategoryId int
AS
BEGIN
    UPDATE Products
    SET Name = @Name,
        Description = @Description,
        Price = @Price,
        ImageUrl = @ImageUrl,
        IsAvailable = @IsAvailable,
        SubCategoryId = @SubCategoryId
    WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteProduct
    @Id int
AS
BEGIN
    DELETE FROM Products
    WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateProductAvailability
    @Id int,
    @IsAvailable bit
AS
BEGIN
    UPDATE Products
    SET IsAvailable = @IsAvailable
    WHERE Id = @Id
END
GO 