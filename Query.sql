/*
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. 
Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
*/

CREATE TABLE Categories (
	[Id] int PRIMARY KEY,
	[Name] nvarchar(256) NOT NULL
)

CREATE TABLE Products (
	[Id] int PRIMARY KEY,
	[Name] nvarchar(256) NOT NULL
)

CREATE TABLE ProductCategoryRelations (
	[ProductId] int NOT NULL,
	[CategoryId] int NOT NULL,
	FOREIGN KEY (ProductId) REFERENCES Products(Id),
	FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

INSERT INTO Categories
VALUES
	(1, 'Motherboard'),
	(2, 'Processor'),
	(3, 'Videocard'),
	(4, 'Intel'),
	(5, 'Nvidia');

INSERT INTO Products
VALUES
	(1, 'Intel Core i7-13700K OEM'),
	(2, 'MSI MAG Z790 TOMAHAWK WIFI'),
	(3, 'MSI GeForce RTX 4090 SUPRIM X'),
	(4, 'SSD Samsung 980 PRO NVMe M.2 1Tb');
	
INSERT INTO ProductCategoryRelations
VALUES
	(2, 1),
	(1, 2),
	(1, 4),
	(3, 3),
	(3, 5);
	
SELECT p.[Name] AS [ProductName],
       ISNULL(c.[Name], '') AS [CategoryName]
FROM Products AS p (NOLOCK)
LEFT JOIN ProductCategoryRelations AS pcr
  ON pcr.[ProductId] = p.[Id]
LEFT JOIN Categories AS c
  ON c.[Id] = pcr.[CategoryId]