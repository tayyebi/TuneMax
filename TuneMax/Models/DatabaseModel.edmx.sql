
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/13/2014 15:00:53
-- Generated from EDMX file: D:\REZA\Projects\TuneMax\TuneMax\TuneMax\Models\DatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_NewsGroupNews]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NewsSet] DROP CONSTRAINT [FK_NewsGroupNews];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountNews]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NewsSet] DROP CONSTRAINT [FK_AccountNews];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountProductGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductGroupSet] DROP CONSTRAINT [FK_AccountProductGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_AccountProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductGroupProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_ProductGroupProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersUsersBasket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersBaskets] DROP CONSTRAINT [FK_UsersUsersBasket];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductUsersBasket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersBaskets] DROP CONSTRAINT [FK_ProductUsersBasket];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountUploadGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UploadGroupSet] DROP CONSTRAINT [FK_AccountUploadGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_UploadGroupUpload]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UploadSet] DROP CONSTRAINT [FK_UploadGroupUpload];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountUpload]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UploadSet] DROP CONSTRAINT [FK_AccountUpload];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductShopList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopLists] DROP CONSTRAINT [FK_ProductShopList];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersShopList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopLists] DROP CONSTRAINT [FK_UsersShopList];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_ProductComment];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountSlider]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SliderSet] DROP CONSTRAINT [FK_AccountSlider];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountSet];
GO
IF OBJECT_ID(N'[dbo].[NewsGroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsGroupSet];
GO
IF OBJECT_ID(N'[dbo].[NewsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsSet];
GO
IF OBJECT_ID(N'[dbo].[ProductGroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductGroupSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[UsersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersSet];
GO
IF OBJECT_ID(N'[dbo].[UsersBaskets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersBaskets];
GO
IF OBJECT_ID(N'[dbo].[UploadGroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UploadGroupSet];
GO
IF OBJECT_ID(N'[dbo].[UploadSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UploadSet];
GO
IF OBJECT_ID(N'[dbo].[ShopLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShopLists];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[SliderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SliderSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountSet'
CREATE TABLE [dbo].[AccountSet] (
    [Username] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL
);
GO

-- Creating table 'NewsGroupSet'
CREATE TABLE [dbo].[NewsGroupSet] (
    [id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NewsSet'
CREATE TABLE [dbo].[NewsSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Abstract] nvarchar(max)  NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [NewsGroup_id] uniqueidentifier  NOT NULL,
    [AccountUsername] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductGroupSet'
CREATE TABLE [dbo].[ProductGroupSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AccountUsername] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [PriceInDollar] nvarchar(max)  NULL,
    [Image] nvarchar(max)  NULL,
    [Date] nvarchar(max)  NOT NULL,
    [AccountUsername] nvarchar(max)  NOT NULL,
    [ProductGroupId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Job] nvarchar(max)  NULL
);
GO

-- Creating table 'UsersBaskets'
CREATE TABLE [dbo].[UsersBaskets] (
    [Id] uniqueidentifier  NOT NULL,
    [UsersUsername] nvarchar(max)  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'UploadGroupSet'
CREATE TABLE [dbo].[UploadGroupSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AccountUsername] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UploadSet'
CREATE TABLE [dbo].[UploadSet] (
    [Id] uniqueidentifier  NOT NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [ContentType] nvarchar(max)  NOT NULL,
    [ContentLength] bigint  NOT NULL,
    [Bytes] varbinary(max)  NOT NULL,
    [UploadGroupId] uniqueidentifier  NOT NULL,
    [AccountUsername] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ShopLists'
CREATE TABLE [dbo].[ShopLists] (
    [Id] uniqueidentifier  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [UsersUsername] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Username] nvarchar(max)  NULL,
    [ProductId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'SliderSet'
CREATE TABLE [dbo].[SliderSet] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [ImageUrl] nvarchar(max)  NOT NULL,
    [Href] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [AccountUsername] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Username] in table 'AccountSet'
ALTER TABLE [dbo].[AccountSet]
ADD CONSTRAINT [PK_AccountSet]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [id] in table 'NewsGroupSet'
ALTER TABLE [dbo].[NewsGroupSet]
ADD CONSTRAINT [PK_NewsGroupSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'NewsSet'
ALTER TABLE [dbo].[NewsSet]
ADD CONSTRAINT [PK_NewsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductGroupSet'
ALTER TABLE [dbo].[ProductGroupSet]
ADD CONSTRAINT [PK_ProductGroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Username] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [Id] in table 'UsersBaskets'
ALTER TABLE [dbo].[UsersBaskets]
ADD CONSTRAINT [PK_UsersBaskets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UploadGroupSet'
ALTER TABLE [dbo].[UploadGroupSet]
ADD CONSTRAINT [PK_UploadGroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UploadSet'
ALTER TABLE [dbo].[UploadSet]
ADD CONSTRAINT [PK_UploadSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShopLists'
ALTER TABLE [dbo].[ShopLists]
ADD CONSTRAINT [PK_ShopLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SliderSet'
ALTER TABLE [dbo].[SliderSet]
ADD CONSTRAINT [PK_SliderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [NewsGroup_id] in table 'NewsSet'
ALTER TABLE [dbo].[NewsSet]
ADD CONSTRAINT [FK_NewsGroupNews]
    FOREIGN KEY ([NewsGroup_id])
    REFERENCES [dbo].[NewsGroupSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NewsGroupNews'
CREATE INDEX [IX_FK_NewsGroupNews]
ON [dbo].[NewsSet]
    ([NewsGroup_id]);
GO

-- Creating foreign key on [AccountUsername] in table 'NewsSet'
ALTER TABLE [dbo].[NewsSet]
ADD CONSTRAINT [FK_AccountNews]
    FOREIGN KEY ([AccountUsername])
    REFERENCES [dbo].[AccountSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountNews'
CREATE INDEX [IX_FK_AccountNews]
ON [dbo].[NewsSet]
    ([AccountUsername]);
GO

-- Creating foreign key on [AccountUsername] in table 'ProductGroupSet'
ALTER TABLE [dbo].[ProductGroupSet]
ADD CONSTRAINT [FK_AccountProductGroup]
    FOREIGN KEY ([AccountUsername])
    REFERENCES [dbo].[AccountSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountProductGroup'
CREATE INDEX [IX_FK_AccountProductGroup]
ON [dbo].[ProductGroupSet]
    ([AccountUsername]);
GO

-- Creating foreign key on [AccountUsername] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_AccountProduct]
    FOREIGN KEY ([AccountUsername])
    REFERENCES [dbo].[AccountSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountProduct'
CREATE INDEX [IX_FK_AccountProduct]
ON [dbo].[ProductSet]
    ([AccountUsername]);
GO

-- Creating foreign key on [ProductGroupId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_ProductGroupProduct]
    FOREIGN KEY ([ProductGroupId])
    REFERENCES [dbo].[ProductGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductGroupProduct'
CREATE INDEX [IX_FK_ProductGroupProduct]
ON [dbo].[ProductSet]
    ([ProductGroupId]);
GO

-- Creating foreign key on [UsersUsername] in table 'UsersBaskets'
ALTER TABLE [dbo].[UsersBaskets]
ADD CONSTRAINT [FK_UsersUsersBasket]
    FOREIGN KEY ([UsersUsername])
    REFERENCES [dbo].[UsersSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersUsersBasket'
CREATE INDEX [IX_FK_UsersUsersBasket]
ON [dbo].[UsersBaskets]
    ([UsersUsername]);
GO

-- Creating foreign key on [ProductId] in table 'UsersBaskets'
ALTER TABLE [dbo].[UsersBaskets]
ADD CONSTRAINT [FK_ProductUsersBasket]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductUsersBasket'
CREATE INDEX [IX_FK_ProductUsersBasket]
ON [dbo].[UsersBaskets]
    ([ProductId]);
GO

-- Creating foreign key on [AccountUsername] in table 'UploadGroupSet'
ALTER TABLE [dbo].[UploadGroupSet]
ADD CONSTRAINT [FK_AccountUploadGroup]
    FOREIGN KEY ([AccountUsername])
    REFERENCES [dbo].[AccountSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountUploadGroup'
CREATE INDEX [IX_FK_AccountUploadGroup]
ON [dbo].[UploadGroupSet]
    ([AccountUsername]);
GO

-- Creating foreign key on [UploadGroupId] in table 'UploadSet'
ALTER TABLE [dbo].[UploadSet]
ADD CONSTRAINT [FK_UploadGroupUpload]
    FOREIGN KEY ([UploadGroupId])
    REFERENCES [dbo].[UploadGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UploadGroupUpload'
CREATE INDEX [IX_FK_UploadGroupUpload]
ON [dbo].[UploadSet]
    ([UploadGroupId]);
GO

-- Creating foreign key on [AccountUsername] in table 'UploadSet'
ALTER TABLE [dbo].[UploadSet]
ADD CONSTRAINT [FK_AccountUpload]
    FOREIGN KEY ([AccountUsername])
    REFERENCES [dbo].[AccountSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountUpload'
CREATE INDEX [IX_FK_AccountUpload]
ON [dbo].[UploadSet]
    ([AccountUsername]);
GO

-- Creating foreign key on [ProductId] in table 'ShopLists'
ALTER TABLE [dbo].[ShopLists]
ADD CONSTRAINT [FK_ProductShopList]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductShopList'
CREATE INDEX [IX_FK_ProductShopList]
ON [dbo].[ShopLists]
    ([ProductId]);
GO

-- Creating foreign key on [UsersUsername] in table 'ShopLists'
ALTER TABLE [dbo].[ShopLists]
ADD CONSTRAINT [FK_UsersShopList]
    FOREIGN KEY ([UsersUsername])
    REFERENCES [dbo].[UsersSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersShopList'
CREATE INDEX [IX_FK_UsersShopList]
ON [dbo].[ShopLists]
    ([UsersUsername]);
GO

-- Creating foreign key on [ProductId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_ProductComment]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductComment'
CREATE INDEX [IX_FK_ProductComment]
ON [dbo].[CommentSet]
    ([ProductId]);
GO

-- Creating foreign key on [AccountUsername] in table 'SliderSet'
ALTER TABLE [dbo].[SliderSet]
ADD CONSTRAINT [FK_AccountSlider]
    FOREIGN KEY ([AccountUsername])
    REFERENCES [dbo].[AccountSet]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountSlider'
CREATE INDEX [IX_FK_AccountSlider]
ON [dbo].[SliderSet]
    ([AccountUsername]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------