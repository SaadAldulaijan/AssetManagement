IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Asset] (
    [Id] int NOT NULL IDENTITY,
    [TelephoneId] int NOT NULL,
    [EmployeeId] int NOT NULL,
    [ExtensionId] int NOT NULL,
    CONSTRAINT [PK_Asset] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Asset_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Asset_Extension_ExtensionId] FOREIGN KEY ([ExtensionId]) REFERENCES [Extension] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Asset_Telephone_TelephoneId] FOREIGN KEY ([TelephoneId]) REFERENCES [Telephone] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Asset_EmployeeId] ON [Asset] ([EmployeeId]);
GO

CREATE INDEX [IX_Asset_ExtensionId] ON [Asset] ([ExtensionId]);
GO

CREATE INDEX [IX_Asset_TelephoneId] ON [Asset] ([TelephoneId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201207055812_initi', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TelephoneExtension]') AND [c].[name] = N'InstalledDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TelephoneExtension] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TelephoneExtension] DROP COLUMN [InstalledDate];
GO

ALTER TABLE [Asset] ADD [InstalledDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201207060955_addinstalledDate', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [TelephoneEmployee];
GO

DROP TABLE [TelephoneExtension];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201207070024_majorChange', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Telephone] ADD [InStock] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201210063719_addInStock', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Extension]') AND [c].[name] = N'Usage');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Extension] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Extension] ALTER COLUMN [Usage] nvarchar(max) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201215125435_addenums', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Pager] ADD [InStock] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Pager] ADD [IsDefective] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201216120633_inheritance', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Pager] DROP CONSTRAINT [FK_Pager_Employee_EmployeeId];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pager]') AND [c].[name] = N'EmployeeId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Pager] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Pager] ALTER COLUMN [EmployeeId] int NULL;
GO

ALTER TABLE [Pager] ADD CONSTRAINT [FK_Pager_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201216130834_nullableEmpId', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Asset] DROP CONSTRAINT [FK_Asset_Employee_EmployeeId];
GO

ALTER TABLE [OtherAsset] DROP CONSTRAINT [FK_OtherAsset_Employee_EmployeeId];
GO

ALTER TABLE [Asset] DROP CONSTRAINT [PK_Asset];
GO

DROP INDEX [IX_Asset_EmployeeId] ON [Asset];
GO

DROP INDEX [IX_Asset_TelephoneId] ON [Asset];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Telephone]') AND [c].[name] = N'InStock');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Telephone] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Telephone] DROP COLUMN [InStock];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Telephone]') AND [c].[name] = N'IsDefective');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Telephone] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Telephone] DROP COLUMN [IsDefective];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pager]') AND [c].[name] = N'InStock');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Pager] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Pager] DROP COLUMN [InStock];
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pager]') AND [c].[name] = N'IsDefective');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Pager] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Pager] DROP COLUMN [IsDefective];
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Asset]') AND [c].[name] = N'Id');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Asset] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Asset] DROP COLUMN [Id];
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Asset]') AND [c].[name] = N'EmployeeId');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Asset] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Asset] DROP COLUMN [EmployeeId];
GO

ALTER TABLE [Telephone] ADD [Status] int NOT NULL DEFAULT 0;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pager]') AND [c].[name] = N'Status');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Pager] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Pager] ALTER COLUMN [Status] int NOT NULL;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OtherAsset]') AND [c].[name] = N'EmployeeId');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [OtherAsset] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [OtherAsset] ALTER COLUMN [EmployeeId] int NULL;
GO

ALTER TABLE [OtherAsset] ADD [Status] int NOT NULL DEFAULT 0;
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Extension]') AND [c].[name] = N'Usage');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Extension] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Extension] ALTER COLUMN [Usage] int NOT NULL;
GO

ALTER TABLE [Extension] ADD [EmployeeId] int NULL;
GO

ALTER TABLE [Asset] ADD CONSTRAINT [PK_Asset] PRIMARY KEY ([TelephoneId], [ExtensionId]);
GO

CREATE INDEX [IX_Extension_EmployeeId] ON [Extension] ([EmployeeId]);
GO

ALTER TABLE [Extension] ADD CONSTRAINT [FK_Extension_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [OtherAsset] ADD CONSTRAINT [FK_OtherAsset_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201228162938_khaterStructure', N'5.0.1');
GO

COMMIT;
GO

