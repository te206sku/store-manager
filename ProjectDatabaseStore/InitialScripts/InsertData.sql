INSERT INTO Store ([Name], [StoreClass], [StoreNumber], [Address])
VALUES
(N'Продукты у дома', N'Первый класс', 101, N'ул. Ленина, 10'),
(N'Семейный магазин', N'Второй класс', 102, N'ул. Мира, 25');
GO

INSERT INTO Department ([Name], [ManagerName], [StoreId])
VALUES
(N'Молочный отдел', N'Иванова', 1),
(N'Мясной отдел', N'Петров', 1),
(N'Овощной отдел', N'Сидорова', 2);
GO

INSERT INTO Supplier ([Name], [Address], [Phone])
VALUES
(N'База Север', N'г. Москва, ул. Северная, 15', N'+7-900-111-22-33'),
(N'База Юг', N'г. Москва, ул. Южная, 21', N'+7-900-444-55-66');
GO

INSERT INTO ProductCategory ([Name])
VALUES
(N'Молочные продукты'),
(N'Мясные продукты'),
(N'Овощи'),
(N'Напитки');
GO

INSERT INTO Product ([Name], [Sort], [ProductCategoryId])
VALUES
(N'Молоко', N'Высший', 1),
(N'Сметана', N'Первый', 1),
(N'Свинина', N'Высший', 2),
(N'Картофель', N'Первый', 3),
(N'Кефир', N'Высший', 1),
(N'Сок яблочный', N'Первый', 4);
GO

INSERT INTO DepartmentProduct ([DepartmentId], [ProductId], [Price], [Quantity])
VALUES
(1, 1, 90, 30),
(1, 2, 120, 15),
(2, 3, 450, 12),
(3, 4, 50, 100),
(1, 5, 95, 8);
GO

INSERT INTO SupplierProduct ([SupplierId], [ProductId], [Price], [Quantity])
VALUES
(1, 1, 70, 200),
(1, 2, 95, 120),
(2, 3, 350, 80),
(2, 4, 30, 300),
(1, 5, 80, 50),
(2, 6, 60, 90);
GO

INSERT INTO Purchase ([PurchaseDate], [StoreId], [SupplierId])
VALUES
('2026-04-01', 1, 1),
('2026-04-10', 1, 2),
('2026-04-20', 2, 1);
GO

INSERT INTO PurchaseItem ([PurchaseId], [ProductId], [Price], [Quantity])
VALUES
(1, 1, 70, 40),
(1, 2, 95, 20),
(2, 3, 350, 15),
(2, 4, 30, 60),
(3, 5, 80, 25);
GO

INSERT INTO Sale ([SaleDate], [StoreId], [DepartmentId])
VALUES
('2026-04-05', 1, 1),
('2026-04-12', 1, 2),
('2026-04-18', 2, 3),
('2026-04-22', 1, 1);
GO

INSERT INTO SaleItem ([SaleId], [ProductId], [Price], [Quantity])
VALUES
(1, 1, 90, 15),
(1, 2, 120, 8),
(2, 3, 450, 5),
(3, 4, 50, 30),
(4, 5, 95, 6);
GO