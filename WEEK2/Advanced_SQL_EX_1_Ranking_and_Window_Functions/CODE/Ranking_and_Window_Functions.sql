-- Create Products Table (if not already exists)
IF OBJECT_ID('Products', 'U') IS NOT NULL
    DROP TABLE Products;
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);
GO

-- Insert Sample Data
INSERT INTO Products (ProductID, ProductName, Category, Price)
VALUES
(1, 'Laptop', 'Electronics', 85000),
(2, 'Smartphone', 'Electronics', 55000),
(3, 'Tablet', 'Electronics', 55000),
(4, 'Headphones', 'Electronics', 3000),
(5, 'Refrigerator', 'Appliances', 45000),
(6, 'Washing Machine', 'Appliances', 35000),
(7, 'Microwave', 'Appliances', 15000),
(8, 'Blender', 'Appliances', 5000),
(9, 'Novel', 'Books', 500),
(10, 'Encyclopedia', 'Books', 2500),
(11, 'Textbook', 'Books', 2500),
(12, 'Comics', 'Books', 300);
GO

-- Use ROW_NUMBER to assign a unique rank
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products;
GO

-- Use RANK to see how it handles ties
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS PriceRank
FROM Products;
GO

-- Use DENSE_RANK to compare with RANK
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DensePriceRank
FROM Products;
GO

-- Get Top 3 most expensive products in each category using ROW_NUMBER
WITH RankedProducts AS (
    SELECT *,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE RowNum <= 3;
GO
