
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2024 07:31:36
-- Generated from EDMX file: C:\Users\Administrador\source\repos\WPFyEFC\EFC\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Dapper];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_usuariosBox_sucursalesBox]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuariosBox] DROP CONSTRAINT [FK_usuariosBox_sucursalesBox];
GO
IF OBJECT_ID(N'[dbo].[FK_rolesBoxusuariosBox]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuariosBox] DROP CONSTRAINT [FK_rolesBoxusuariosBox];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sucursalesBox]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sucursalesBox];
GO
IF OBJECT_ID(N'[dbo].[usuariosBox]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usuariosBox];
GO
IF OBJECT_ID(N'[dbo].[rolesBoxSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rolesBoxSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sucursalesBox'
CREATE TABLE [dbo].[sucursalesBox] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NULL
);
GO

-- Creating table 'usuariosBox'
CREATE TABLE [dbo].[usuariosBox] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NULL,
    [Pass] nvarchar(50)  NULL,
    [Activo] bit  NULL,
    [UsuarioBloqueado] bit  NULL,
    [IdSucursal] int  NULL,
    [rolesBoxId] int  NULL
);
GO

-- Creating table 'rolesBox'
CREATE TABLE [dbo].[rolesBox] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'sucursalesBox'
ALTER TABLE [dbo].[sucursalesBox]
ADD CONSTRAINT [PK_sucursalesBox]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'usuariosBox'
ALTER TABLE [dbo].[usuariosBox]
ADD CONSTRAINT [PK_usuariosBox]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'rolesBox'
ALTER TABLE [dbo].[rolesBox]
ADD CONSTRAINT [PK_rolesBox]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdSucursal] in table 'usuariosBox'
ALTER TABLE [dbo].[usuariosBox]
ADD CONSTRAINT [FK_usuariosBox_sucursalesBox]
    FOREIGN KEY ([IdSucursal])
    REFERENCES [dbo].[sucursalesBox]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_usuariosBox_sucursalesBox'
CREATE INDEX [IX_FK_usuariosBox_sucursalesBox]
ON [dbo].[usuariosBox]
    ([IdSucursal]);
GO

-- Creating foreign key on [rolesBoxId] in table 'usuariosBox'
ALTER TABLE [dbo].[usuariosBox]
ADD CONSTRAINT [FK_rolesBoxusuariosBox]
    FOREIGN KEY ([rolesBoxId])
    REFERENCES [dbo].[rolesBox]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_rolesBoxusuariosBox'
CREATE INDEX [IX_FK_rolesBoxusuariosBox]
ON [dbo].[usuariosBox]
    ([rolesBoxId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------