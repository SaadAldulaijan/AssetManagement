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

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Department] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [SubCategory] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_SubCategory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SubCategory_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Employee] (
    [BadgeNo] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [DepartmentId] int NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY ([BadgeNo]),
    CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Telephone] (
    [SerialNo] nvarchar(450) NOT NULL,
    [MAC] nvarchar(max) NULL,
    [Tag] nvarchar(max) NULL,
    [Remark] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [SubCategoryId] int NOT NULL,
    CONSTRAINT [PK_Telephone] PRIMARY KEY ([SerialNo]),
    CONSTRAINT [FK_Telephone_SubCategory_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategory] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Extension] (
    [Number] int NOT NULL IDENTITY,
    [Usage] int NOT NULL,
    [BadgeNo] int NULL,
    [EmployeeBadgeNo] int NULL,
    CONSTRAINT [PK_Extension] PRIMARY KEY ([Number]),
    CONSTRAINT [FK_Extension_Employee_EmployeeBadgeNo] FOREIGN KEY ([EmployeeBadgeNo]) REFERENCES [Employee] ([BadgeNo]) ON DELETE NO ACTION
);
GO

CREATE TABLE [OtherAsset] (
    [Id] int NOT NULL IDENTITY,
    [SerialNo] nvarchar(max) NULL,
    [DN] nvarchar(max) NULL,
    [Model] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [BadgeNo] int NULL,
    [EmployeeBadgeNo] int NULL,
    CONSTRAINT [PK_OtherAsset] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OtherAsset_Employee_EmployeeBadgeNo] FOREIGN KEY ([EmployeeBadgeNo]) REFERENCES [Employee] ([BadgeNo]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Pager] (
    [SerialNo] nvarchar(450) NOT NULL,
    [Number] int NOT NULL,
    [Status] int NOT NULL,
    [Capcode] nvarchar(max) NULL,
    [Comment] nvarchar(max) NULL,
    [Cust] nvarchar(max) NULL,
    [RateCode] nvarchar(max) NULL,
    [MailCode] nvarchar(max) NULL,
    [Facility] nvarchar(max) NULL,
    [BadgeNo] int NULL,
    [EmployeeBadgeNo] int NULL,
    CONSTRAINT [PK_Pager] PRIMARY KEY ([SerialNo]),
    CONSTRAINT [FK_Pager_Employee_EmployeeBadgeNo] FOREIGN KEY ([EmployeeBadgeNo]) REFERENCES [Employee] ([BadgeNo]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Asset] (
    [SerialNo] nvarchar(450) NOT NULL,
    [Number] int NOT NULL,
    [InstalledDate] datetime2 NOT NULL,
    [TelephoneSerialNo] nvarchar(450) NULL,
    [ExtensionNumber] int NULL,
    CONSTRAINT [PK_Asset] PRIMARY KEY ([SerialNo], [Number]),
    CONSTRAINT [FK_Asset_Extension_ExtensionNumber] FOREIGN KEY ([ExtensionNumber]) REFERENCES [Extension] ([Number]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Asset_Telephone_TelephoneSerialNo] FOREIGN KEY ([TelephoneSerialNo]) REFERENCES [Telephone] ([SerialNo]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Asset_ExtensionNumber] ON [Asset] ([ExtensionNumber]);
GO

CREATE INDEX [IX_Asset_TelephoneSerialNo] ON [Asset] ([TelephoneSerialNo]);
GO

CREATE INDEX [IX_Employee_DepartmentId] ON [Employee] ([DepartmentId]);
GO

CREATE INDEX [IX_Extension_EmployeeBadgeNo] ON [Extension] ([EmployeeBadgeNo]);
GO

CREATE INDEX [IX_OtherAsset_EmployeeBadgeNo] ON [OtherAsset] ([EmployeeBadgeNo]);
GO

CREATE INDEX [IX_Pager_EmployeeBadgeNo] ON [Pager] ([EmployeeBadgeNo]);
GO

CREATE INDEX [IX_SubCategory_CategoryId] ON [SubCategory] ([CategoryId]);
GO

CREATE INDEX [IX_Telephone_SubCategoryId] ON [Telephone] ([SubCategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210104114618_updatePrimaryKeys', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Asset] DROP CONSTRAINT [FK_Asset_Extension_ExtensionNumber];
GO

ALTER TABLE [Asset] DROP CONSTRAINT [FK_Asset_Telephone_TelephoneSerialNo];
GO

ALTER TABLE [Asset] DROP CONSTRAINT [PK_Asset];
GO

DROP INDEX [IX_Asset_TelephoneSerialNo] ON [Asset];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pager]') AND [c].[name] = N'BadgeNo');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Pager] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Pager] DROP COLUMN [BadgeNo];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Extension]') AND [c].[name] = N'BadgeNo');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Extension] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Extension] DROP COLUMN [BadgeNo];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Asset]') AND [c].[name] = N'SerialNo');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Asset] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Asset] DROP COLUMN [SerialNo];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Asset]') AND [c].[name] = N'Number');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Asset] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Asset] DROP COLUMN [Number];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Asset]') AND [c].[name] = N'TelephoneSerialNo');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Asset] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Asset] ALTER COLUMN [TelephoneSerialNo] nvarchar(450) NOT NULL;
ALTER TABLE [Asset] ADD DEFAULT N'' FOR [TelephoneSerialNo];
GO

DROP INDEX [IX_Asset_ExtensionNumber] ON [Asset];
DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Asset]') AND [c].[name] = N'ExtensionNumber');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Asset] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Asset] ALTER COLUMN [ExtensionNumber] int NOT NULL;
ALTER TABLE [Asset] ADD DEFAULT 0 FOR [ExtensionNumber];
CREATE INDEX [IX_Asset_ExtensionNumber] ON [Asset] ([ExtensionNumber]);
GO

ALTER TABLE [Asset] ADD CONSTRAINT [PK_Asset] PRIMARY KEY ([TelephoneSerialNo], [ExtensionNumber]);
GO

ALTER TABLE [Asset] ADD CONSTRAINT [FK_Asset_Extension_ExtensionNumber] FOREIGN KEY ([ExtensionNumber]) REFERENCES [Extension] ([Number]) ON DELETE CASCADE;
GO

ALTER TABLE [Asset] ADD CONSTRAINT [FK_Asset_Telephone_TelephoneSerialNo] FOREIGN KEY ([TelephoneSerialNo]) REFERENCES [Telephone] ([SerialNo]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210104120952_updateColumnNames', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OtherAsset]') AND [c].[name] = N'BadgeNo');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [OtherAsset] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [OtherAsset] DROP COLUMN [BadgeNo];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210104131826_updateOtherAssets', N'5.0.1');
GO

COMMIT;
GO

