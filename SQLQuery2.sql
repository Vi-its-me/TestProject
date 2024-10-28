CREATE TABLE [Product]
(
	[docNumber] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(MAX) 
)
GO
CREATE TABLE [Document]
(
	[store] INT IDENTITY PRIMARY KEY,
	[docNumber] INT FOREIGN KEY REFERENCES [Product]([docNumber]),
	[docDate] DATE
)
GO
SET IDENTITY_INSERT [Document] OFF
SET IDENTITY_INSERT [Product] ON
INSERT INTO [Product] ([docNumber], [Name]) VALUES
(1, N'продукт1'),
(2, N'продукт2'),
(3, N'продукт3'),
(4, N'продукт4')
GO
SET IDENTITY_INSERT [Product] OFF
SET IDENTITY_INSERT [Document] ON
INSERT INTO [Document] (store, docNumber, docDate) VALUES
(5, 3, '2024-01-05')
(1, 1, '2024-07-01'),
(2, 1, '2024-06-02'),
(3, 2, '2024-05-03'),
(4, 2, '2024-04-04')
GO
--1) Посчитать количество складов, количество документов
SELECT 
COUNT([Document].[store]) AS [количество складов],
COUNT([Document].[docNumber]) AS [количество документов]
FROM [Document]
-- 2) Вывести список кодов складов с количеством документов 
-- с разбивкой по месяцам
SELECT DATEPART(MONTH, [Document].[docDate]) AS [номер месяца], 
COUNT([Document].[store]) AS [код склада],
COUNT([Document].[docNumber]) AS [количество документов]
FROM [Document]
GROUP BY DATEPART(MONTH, [Document].[docDate])
-- 3) Из этого списка вывести только те склады, которые числились 
-- только в одном из месяцев(в первом месяце проводили документы, 
-- во втором перестали, или наоборот - в первом не проводили, 
-- со второго начали)
-- 4) Если список из пункта 3) формировался при помощи нескольких 
-- запросов, сформировать его одним запросом
SELECT DATEPART(MONTH, [Document].[docDate]) AS [номер месяца], 
COUNT([Document].[store]) AS [код склада],
COUNT([Document].[docNumber]) AS [количество документов в первом месяце]
FROM [Document]
WHERE DATEPART(MONTH, [Document].[docDate]) = 01
GROUP BY DATEPART(MONTH, [Document].[docDate])

нет акцента на условиях, словах, не таписано тз такое чувство
тест-полоски не выводит
отчет должен был выглядеть как в ТЗ
