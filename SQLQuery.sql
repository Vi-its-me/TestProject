USE [C:\CODE PROJECTS\DATABASE_PROJECT\DATABASE_PROJECT\DATABASE.MDF] 
-- Запрос создания таблиц
CREATE TABLE [Recipes] -- Основная таблица отпуска
(
	[id] INT PRIMARY KEY NOT NULL, -- Идентификатор записи
	[personid] INT, -- Идентификатор человека
	[sn_lr] INT, -- Номер рецепта
	[date] DATE, -- Дата отпуска
	[nomk_ls] INT FOREIGN KEY REFERENCES [drug]([numk_ls]), -- Идентификатор лекарства
	[ko_all] INT, -- Количество
	[sl_all] INT, -- Цена
	[period] DATE, -- Период отпуска (год + месяц)
	[Owner] INT FOREIGN KEY REFERENCES [Owner]([owner]) -- Направление
)
CREATE TABLE [drug] 
(
	[name_med] NVARCHAR(MAX), -- Наименование лекарства
	[nomk_ls] INT PRIMARY KEY IDENTITY NOT NULL, -- Идентификатор лекарства
	[flag_mi] TINYINT, -- Флаг мед изделия
	[flag_in] TINYINT -- Флаг вхождения в список ПКУ
)
CREATE TABLE [Owner]
(
	[owner] INT PRIMARY KEY IDENTITY NOT NULL, -- Идентификатор направления
	[Name] NVARCHAR(MAX) -- Наименование направления
)
-- Запрос создания представления для выборки данных
CREATE VIEW [queryView1] 
AS SELECT 
FORMAT([date], 'yyyy') AS [год], 
[Owner].[Name] AS [направление], 
SUM([Recipes].[ko_all]) AS [количество человек],
COUNT([drug].[name_med]) AS [количество упаковок], -- ? Не уверен
[Recipes].[sl_all] AS [сумма отпуска]
FROM [Recipes]
INNER JOIN [Owner]
	ON [Recipes].[owner] = [Owner].[owner] 
INNER JOIN [drug]
	ON [Recipes].[nomk_ls] = [drug].[nomk_ls]
WHERE [Owner].[owner] <= 8 AND [Owner].[owner] >= 3
GROUP BY [Owner].[Name], [Recipes].[date], [Recipes].[sl_all]
-- Запрос на показ представления
SELECT * FROM [queryView1]
-- Запрос на выборку данных из представления
SELECT 
N'Итого', 
N'', 
SUM([queryView1].[количество человек]), 
SUM([queryView1].[количество упаковок]),
SUM([queryView1].[сумма отпуска])
FROM [queryView1]
