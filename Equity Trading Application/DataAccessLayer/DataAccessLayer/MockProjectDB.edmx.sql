
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/05/2014 18:43:56
-- Generated from EDMX file: C:\Users\Mavez  S Dabas\Desktop\MockProject\New folder (2)\DataAccessLayer\DataAccessLayer\MockProjectDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MockProjectDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Client_Portfolio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_Client_Portfolio];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Block]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Order_Block];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Order_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Stock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Order_Stock];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Blocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blocks];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Portfolios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Portfolios];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Stocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stocks];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Blocks'
CREATE TABLE [dbo].[Blocks] (
    [BlockID] int  NOT NULL,
    [Side] nvarchar(50)  NULL,
    [TotalQuantity] int  NULL,
    [OpenQuantity] int  NULL,
    [AllocatedQuantity] int  NULL,
    [StopPrice] decimal(18,2)  NULL,
    [LimitPrice] decimal(18,2)  NULL,
    [Orders] varchar(max)  NULL,
    [StatusId] int  NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Client_ID] int  NOT NULL,
    [ClientName] nvarchar(50)  NULL,
    [P_ID] int  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int  NOT NULL,
    [Side] nvarchar(50)  NULL,
    [BlockID] int  NULL,
    [StockID] int  NULL,
    [StatusID] int  NULL,
    [Qualifier] nvarchar(50)  NULL,
    [Type] nvarchar(50)  NULL,
    [OwnedQuantity] int  NULL,
    [Quantity] int  NULL,
    [Notes] nvarchar(50)  NULL,
    [LimitPrice] decimal(18,2)  NULL,
    [StopPrice] decimal(18,2)  NULL
);
GO

-- Creating table 'Portfolios'
CREATE TABLE [dbo].[Portfolios] (
    [P_ID] int  NOT NULL,
    [P_Name] nvarchar(50)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int  NOT NULL,
    [RoleName] nvarchar(50)  NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [StatusID] int  NOT NULL,
    [StatusName] varchar(50)  NULL
);
GO

-- Creating table 'Stocks'
CREATE TABLE [dbo].[Stocks] (
    [StockID] int  NOT NULL,
    [StockSymbol] varchar(50)  NOT NULL,
    [MarketPrice] decimal(18,2)  NULL,
    [High] decimal(18,2)  NULL,
    [Low] decimal(18,2)  NULL,
    [EPS] decimal(18,2)  NULL,
    [PERatio] decimal(18,2)  NULL,
    [Exchange] varchar(50)  NULL,
    [PreviousClose] decimal(18,2)  NULL,
    [Change] decimal(18,2)  NULL,
    [ChangePercent] decimal(18,2)  NULL,
    [StockName] nvarchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int  NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [RoleID] int  NULL,
    [VerificationKey] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BlockID] in table 'Blocks'
ALTER TABLE [dbo].[Blocks]
ADD CONSTRAINT [PK_Blocks]
    PRIMARY KEY CLUSTERED ([BlockID] ASC);
GO

-- Creating primary key on [Client_ID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Client_ID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [P_ID] in table 'Portfolios'
ALTER TABLE [dbo].[Portfolios]
ADD CONSTRAINT [PK_Portfolios]
    PRIMARY KEY CLUSTERED ([P_ID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [StatusID] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([StatusID] ASC);
GO

-- Creating primary key on [StockID] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [PK_Stocks]
    PRIMARY KEY CLUSTERED ([StockID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BlockID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Block]
    FOREIGN KEY ([BlockID])
    REFERENCES [dbo].[Blocks]
        ([BlockID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Block'
CREATE INDEX [IX_FK_Order_Block]
ON [dbo].[Orders]
    ([BlockID]);
GO

-- Creating foreign key on [P_ID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_Client_Portfolio]
    FOREIGN KEY ([P_ID])
    REFERENCES [dbo].[Portfolios]
        ([P_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Client_Portfolio'
CREATE INDEX [IX_FK_Client_Portfolio]
ON [dbo].[Clients]
    ([P_ID]);
GO

-- Creating foreign key on [StatusID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Status]
    FOREIGN KEY ([StatusID])
    REFERENCES [dbo].[Status]
        ([StatusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Status'
CREATE INDEX [IX_FK_Order_Status]
ON [dbo].[Orders]
    ([StatusID]);
GO

-- Creating foreign key on [StockID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Stock]
    FOREIGN KEY ([StockID])
    REFERENCES [dbo].[Stocks]
        ([StockID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Stock'
CREATE INDEX [IX_FK_Order_Stock]
ON [dbo].[Orders]
    ([StockID]);
GO

-- Creating foreign key on [RoleID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Role]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role'
CREATE INDEX [IX_FK_User_Role]
ON [dbo].[Users]
    ([RoleID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------