
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2014 17:58:21
-- Generated from EDMX file: D:\MockProject\trunk\Development\Code\ExecutionTraderMainWindow -v2.2\DummyDataCreator\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EquityTradingDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Blocks_Securities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blocks] DROP CONSTRAINT [FK_Blocks_Securities];
GO
IF OBJECT_ID(N'[dbo].[FK_ExecutedBlocks_Blocks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExecutedBlocks] DROP CONSTRAINT [FK_ExecutedBlocks_Blocks];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderAllocations_Blocks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderAllocations] DROP CONSTRAINT [FK_OrderAllocations_Blocks];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Blocks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Blocks];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Client];
GO
IF OBJECT_ID(N'[dbo].[FK_Portfolio_Client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Portfolios] DROP CONSTRAINT [FK_Portfolio_Client];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderAllocations_ExecutedBlocks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderAllocations] DROP CONSTRAINT [FK_OrderAllocations_ExecutedBlocks];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderAllocations_Orders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderAllocations] DROP CONSTRAINT [FK_OrderAllocations_Orders];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Portfolio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Portfolio];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Securities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Securities];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_User1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_User1];
GO
IF OBJECT_ID(N'[dbo].[FK_ProposedBlocks_Securities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProposedBlocks] DROP CONSTRAINT [FK_ProposedBlocks_Securities];
GO
IF OBJECT_ID(N'[dbo].[FK_SecurityConfigurationDetails_Securities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SecurityConfigurationDetails] DROP CONSTRAINT [FK_SecurityConfigurationDetails_Securities];
GO
IF OBJECT_ID(N'[dbo].[FK_User_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_UserRole];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AllocationMethods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AllocationMethods];
GO
IF OBJECT_ID(N'[dbo].[Blocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blocks];
GO
IF OBJECT_ID(N'[dbo].[BlocksForExecutions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlocksForExecutions];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[ExecutedBlocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExecutedBlocks];
GO
IF OBJECT_ID(N'[dbo].[OrderAllocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderAllocations];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Portfolios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Portfolios];
GO
IF OBJECT_ID(N'[dbo].[ProposedBlocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProposedBlocks];
GO
IF OBJECT_ID(N'[dbo].[Securities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Securities];
GO
IF OBJECT_ID(N'[dbo].[SecurityConfigurationDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecurityConfigurationDetails];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AllocationMethods'
CREATE TABLE [dbo].[AllocationMethods] (
    [MethodID] int  NOT NULL,
    [MethodName] nchar(100)  NOT NULL
);
GO

-- Creating table 'Blocks'
CREATE TABLE [dbo].[Blocks] (
    [BlockID] int IDENTITY(1,1) NOT NULL,
    [TraderID] int  NOT NULL,
    [SecurityID] int  NOT NULL,
    [BlockSide] nvarchar(50)  NOT NULL,
    [BlockStatus] int  NOT NULL,
    [LimitPrice] decimal(18,2)  NOT NULL,
    [StopPrice] decimal(18,2)  NOT NULL,
    [TotalQuantity] int  NOT NULL,
    [ExecutedQuantity] int  NOT NULL,
    [OpenQuantity] int  NOT NULL
);
GO

-- Creating table 'BlocksForExecutions'
CREATE TABLE [dbo].[BlocksForExecutions] (
    [BlockID] int  NOT NULL,
    [TraderID] int  NOT NULL,
    [SecurityID] int  NOT NULL,
    [BlockSide] nvarchar(50)  NOT NULL,
    [BlockStatus] int  NOT NULL,
    [LimitPrice] decimal(18,2)  NOT NULL,
    [StopPrice] decimal(18,2)  NOT NULL,
    [TotalQuantity] int  NOT NULL,
    [ExecutedQuantity] int  NOT NULL,
    [OpenQuantity] int  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ClientID] int IDENTITY(1,1) NOT NULL,
    [ClientName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ExecutedBlocks'
CREATE TABLE [dbo].[ExecutedBlocks] (
    [ExecutedBlockID] int IDENTITY(1,1) NOT NULL,
    [BlockID] int  NOT NULL,
    [ExecutedQuantity] int  NOT NULL,
    [TransactionPrice] decimal(18,2)  NOT NULL,
    [Status] int  NOT NULL,
    [TransactionTime] datetime  NOT NULL
);
GO

-- Creating table 'OrderAllocations'
CREATE TABLE [dbo].[OrderAllocations] (
    [AllocationID] int IDENTITY(1,1) NOT NULL,
    [ExecutionID] int  NOT NULL,
    [BlockID] int  NOT NULL,
    [Status] int  NOT NULL,
    [AllocatedQuantity] int  NOT NULL,
    [TransactionFee] decimal(18,2)  NOT NULL,
    [TransactionPrice] decimal(18,2)  NOT NULL,
    [OrderID] int  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [SecurityID] int  NOT NULL,
    [Side] nvarchar(50)  NOT NULL,
    [OrderType] nvarchar(50)  NOT NULL,
    [OrderQualifier] nvarchar(50)  NOT NULL,
    [TraderID] int  NULL,
    [ManagerID] int  NOT NULL,
    [TotalQuantity] int  NOT NULL,
    [OpenQuantity] int  NOT NULL,
    [AllocatedQuantity] int  NOT NULL,
    [StopPrice] decimal(18,2)  NULL,
    [LimitPrice] decimal(18,2)  NULL,
    [Notes] nvarchar(500)  NULL,
    [Notify] bit  NULL,
    [ClientID] int  NOT NULL,
    [PortfolioID] int  NOT NULL,
    [StatusID] int  NOT NULL,
    [BlockID] int  NULL,
    [BookTime] binary(8)  NULL,
    [TransactionPrice] decimal(18,2)  NULL,
    [TransactionTime] datetime  NULL,
    [AccountType] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Portfolios'
CREATE TABLE [dbo].[Portfolios] (
    [PortfolioID] int IDENTITY(1,1) NOT NULL,
    [PortfolioName] nvarchar(50)  NOT NULL,
    [ClientID] int  NULL
);
GO

-- Creating table 'ProposedBlocks'
CREATE TABLE [dbo].[ProposedBlocks] (
    [ProposedBlockID] int IDENTITY(1,1) NOT NULL,
    [SecurityID] int  NOT NULL,
    [BlockSide] nvarchar(50)  NOT NULL,
    [LimitPrice] decimal(18,2)  NOT NULL,
    [StopPrice] decimal(18,2)  NOT NULL,
    [TotalQuantity] int  NOT NULL
);
GO

-- Creating table 'Securities'
CREATE TABLE [dbo].[Securities] (
    [SecurityID] int IDENTITY(1,1) NOT NULL,
    [SecurityName] nvarchar(100)  NOT NULL,
    [SecuritySymbol] nvarchar(50)  NOT NULL,
    [LastTradedPrice] decimal(18,2)  NULL,
    [ExecutionQuantity] int  NOT NULL,
    [MarketPrice] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'SecurityConfigurationDetails'
CREATE TABLE [dbo].[SecurityConfigurationDetails] (
    [MaxPriceSpread] int  NOT NULL,
    [MaxExecutionNumber] int  NOT NULL,
    [MaxExecutionInterval] binary(8)  NOT NULL,
    [FullyExecutedOrderProbability] int  NOT NULL,
    [SecurityID] int  NOT NULL,
    [SecurityConfigurationID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [StatusID] int IDENTITY(1,1) NOT NULL,
    [StatusName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [RoleID] int  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MethodID] in table 'AllocationMethods'
ALTER TABLE [dbo].[AllocationMethods]
ADD CONSTRAINT [PK_AllocationMethods]
    PRIMARY KEY CLUSTERED ([MethodID] ASC);
GO

-- Creating primary key on [BlockID] in table 'Blocks'
ALTER TABLE [dbo].[Blocks]
ADD CONSTRAINT [PK_Blocks]
    PRIMARY KEY CLUSTERED ([BlockID] ASC);
GO

-- Creating primary key on [BlockID], [TraderID], [SecurityID], [BlockSide], [BlockStatus], [LimitPrice], [StopPrice], [TotalQuantity], [ExecutedQuantity], [OpenQuantity] in table 'BlocksForExecutions'
ALTER TABLE [dbo].[BlocksForExecutions]
ADD CONSTRAINT [PK_BlocksForExecutions]
    PRIMARY KEY CLUSTERED ([BlockID], [TraderID], [SecurityID], [BlockSide], [BlockStatus], [LimitPrice], [StopPrice], [TotalQuantity], [ExecutedQuantity], [OpenQuantity] ASC);
GO

-- Creating primary key on [ClientID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ClientID] ASC);
GO

-- Creating primary key on [ExecutedBlockID] in table 'ExecutedBlocks'
ALTER TABLE [dbo].[ExecutedBlocks]
ADD CONSTRAINT [PK_ExecutedBlocks]
    PRIMARY KEY CLUSTERED ([ExecutedBlockID] ASC);
GO

-- Creating primary key on [AllocationID] in table 'OrderAllocations'
ALTER TABLE [dbo].[OrderAllocations]
ADD CONSTRAINT [PK_OrderAllocations]
    PRIMARY KEY CLUSTERED ([AllocationID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [PortfolioID] in table 'Portfolios'
ALTER TABLE [dbo].[Portfolios]
ADD CONSTRAINT [PK_Portfolios]
    PRIMARY KEY CLUSTERED ([PortfolioID] ASC);
GO

-- Creating primary key on [ProposedBlockID] in table 'ProposedBlocks'
ALTER TABLE [dbo].[ProposedBlocks]
ADD CONSTRAINT [PK_ProposedBlocks]
    PRIMARY KEY CLUSTERED ([ProposedBlockID] ASC);
GO

-- Creating primary key on [SecurityID] in table 'Securities'
ALTER TABLE [dbo].[Securities]
ADD CONSTRAINT [PK_Securities]
    PRIMARY KEY CLUSTERED ([SecurityID] ASC);
GO

-- Creating primary key on [SecurityConfigurationID] in table 'SecurityConfigurationDetails'
ALTER TABLE [dbo].[SecurityConfigurationDetails]
ADD CONSTRAINT [PK_SecurityConfigurationDetails]
    PRIMARY KEY CLUSTERED ([SecurityConfigurationID] ASC);
GO

-- Creating primary key on [StatusID] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([StatusID] ASC);
GO

-- Creating primary key on [RoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SecurityID] in table 'Blocks'
ALTER TABLE [dbo].[Blocks]
ADD CONSTRAINT [FK_Blocks_Securities]
    FOREIGN KEY ([SecurityID])
    REFERENCES [dbo].[Securities]
        ([SecurityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Blocks_Securities'
CREATE INDEX [IX_FK_Blocks_Securities]
ON [dbo].[Blocks]
    ([SecurityID]);
GO

-- Creating foreign key on [BlockID] in table 'ExecutedBlocks'
ALTER TABLE [dbo].[ExecutedBlocks]
ADD CONSTRAINT [FK_ExecutedBlocks_Blocks]
    FOREIGN KEY ([BlockID])
    REFERENCES [dbo].[Blocks]
        ([BlockID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExecutedBlocks_Blocks'
CREATE INDEX [IX_FK_ExecutedBlocks_Blocks]
ON [dbo].[ExecutedBlocks]
    ([BlockID]);
GO

-- Creating foreign key on [BlockID] in table 'OrderAllocations'
ALTER TABLE [dbo].[OrderAllocations]
ADD CONSTRAINT [FK_OrderAllocations_Blocks]
    FOREIGN KEY ([BlockID])
    REFERENCES [dbo].[Blocks]
        ([BlockID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderAllocations_Blocks'
CREATE INDEX [IX_FK_OrderAllocations_Blocks]
ON [dbo].[OrderAllocations]
    ([BlockID]);
GO

-- Creating foreign key on [BlockID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Blocks]
    FOREIGN KEY ([BlockID])
    REFERENCES [dbo].[Blocks]
        ([BlockID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Blocks'
CREATE INDEX [IX_FK_Orders_Blocks]
ON [dbo].[Orders]
    ([BlockID]);
GO

-- Creating foreign key on [ClientID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Client]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ClientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Client'
CREATE INDEX [IX_FK_Orders_Client]
ON [dbo].[Orders]
    ([ClientID]);
GO

-- Creating foreign key on [ClientID] in table 'Portfolios'
ALTER TABLE [dbo].[Portfolios]
ADD CONSTRAINT [FK_Portfolio_Client]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ClientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Portfolio_Client'
CREATE INDEX [IX_FK_Portfolio_Client]
ON [dbo].[Portfolios]
    ([ClientID]);
GO

-- Creating foreign key on [ExecutionID] in table 'OrderAllocations'
ALTER TABLE [dbo].[OrderAllocations]
ADD CONSTRAINT [FK_OrderAllocations_ExecutedBlocks]
    FOREIGN KEY ([ExecutionID])
    REFERENCES [dbo].[ExecutedBlocks]
        ([ExecutedBlockID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderAllocations_ExecutedBlocks'
CREATE INDEX [IX_FK_OrderAllocations_ExecutedBlocks]
ON [dbo].[OrderAllocations]
    ([ExecutionID]);
GO

-- Creating foreign key on [AllocationID] in table 'OrderAllocations'
ALTER TABLE [dbo].[OrderAllocations]
ADD CONSTRAINT [FK_OrderAllocations_Orders]
    FOREIGN KEY ([AllocationID])
    REFERENCES [dbo].[Orders]
        ([OrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PortfolioID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Portfolio]
    FOREIGN KEY ([PortfolioID])
    REFERENCES [dbo].[Portfolios]
        ([PortfolioID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Portfolio'
CREATE INDEX [IX_FK_Orders_Portfolio]
ON [dbo].[Orders]
    ([PortfolioID]);
GO

-- Creating foreign key on [SecurityID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Securities]
    FOREIGN KEY ([SecurityID])
    REFERENCES [dbo].[Securities]
        ([SecurityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Securities'
CREATE INDEX [IX_FK_Orders_Securities]
ON [dbo].[Orders]
    ([SecurityID]);
GO

-- Creating foreign key on [StatusID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Status]
    FOREIGN KEY ([StatusID])
    REFERENCES [dbo].[Status]
        ([StatusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Status'
CREATE INDEX [IX_FK_Orders_Status]
ON [dbo].[Orders]
    ([StatusID]);
GO

-- Creating foreign key on [ManagerID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_User]
    FOREIGN KEY ([ManagerID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_User'
CREATE INDEX [IX_FK_Orders_User]
ON [dbo].[Orders]
    ([ManagerID]);
GO

-- Creating foreign key on [TraderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_User1]
    FOREIGN KEY ([TraderID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_User1'
CREATE INDEX [IX_FK_Orders_User1]
ON [dbo].[Orders]
    ([TraderID]);
GO

-- Creating foreign key on [SecurityID] in table 'ProposedBlocks'
ALTER TABLE [dbo].[ProposedBlocks]
ADD CONSTRAINT [FK_ProposedBlocks_Securities]
    FOREIGN KEY ([SecurityID])
    REFERENCES [dbo].[Securities]
        ([SecurityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProposedBlocks_Securities'
CREATE INDEX [IX_FK_ProposedBlocks_Securities]
ON [dbo].[ProposedBlocks]
    ([SecurityID]);
GO

-- Creating foreign key on [SecurityID] in table 'SecurityConfigurationDetails'
ALTER TABLE [dbo].[SecurityConfigurationDetails]
ADD CONSTRAINT [FK_SecurityConfigurationDetails_Securities]
    FOREIGN KEY ([SecurityID])
    REFERENCES [dbo].[Securities]
        ([SecurityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SecurityConfigurationDetails_Securities'
CREATE INDEX [IX_FK_SecurityConfigurationDetails_Securities]
ON [dbo].[SecurityConfigurationDetails]
    ([SecurityID]);
GO

-- Creating foreign key on [RoleID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_UserRole]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[UserRoles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_UserRole'
CREATE INDEX [IX_FK_User_UserRole]
ON [dbo].[Users]
    ([RoleID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------