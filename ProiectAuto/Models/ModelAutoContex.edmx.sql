
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2019 21:15:45
-- Generated from EDMX file: F:\Faculta2\TSP.NET\ProiectPrimaParte\ProiectAuto\ProiectAuto\Models\ModelAutoContex.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Auto];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientAuto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autoes] DROP CONSTRAINT [FK_ClientAuto];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoSasiu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autoes] DROP CONSTRAINT [FK_AutoSasiu];
GO
IF OBJECT_ID(N'[dbo].[FK_DetaliuComandaMecanic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mecanics] DROP CONSTRAINT [FK_DetaliuComandaMecanic];
GO
IF OBJECT_ID(N'[dbo].[FK_MecanicOperatie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operaties] DROP CONSTRAINT [FK_MecanicOperatie];
GO
IF OBJECT_ID(N'[dbo].[FK_OperatieMaterial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_OperatieMaterial];
GO
IF OBJECT_ID(N'[dbo].[FK_DetaliuComandaImagine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Imagines] DROP CONSTRAINT [FK_DetaliuComandaImagine];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comandas] DROP CONSTRAINT [FK_AutoComanda];
GO
IF OBJECT_ID(N'[dbo].[FK_ComandaDetaliuComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comandas] DROP CONSTRAINT [FK_ComandaDetaliuComanda];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Autoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autoes];
GO
IF OBJECT_ID(N'[dbo].[Sasius]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sasius];
GO
IF OBJECT_ID(N'[dbo].[Mecanics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mecanics];
GO
IF OBJECT_ID(N'[dbo].[Materials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materials];
GO
IF OBJECT_ID(N'[dbo].[Imagines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Imagines];
GO
IF OBJECT_ID(N'[dbo].[Operaties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operaties];
GO
IF OBJECT_ID(N'[dbo].[Comandas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comandas];
GO
IF OBJECT_ID(N'[dbo].[DetaliuComandas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetaliuComandas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ClientId] int IDENTITY(1,1) NOT NULL,
    [Nume] nvarchar(15)  NOT NULL,
    [Prenume] nvarchar(15)  NOT NULL,
    [Adresa] nvarchar(50)  NOT NULL,
    [Localitate] nvarchar(10)  NOT NULL,
    [Judet] nvarchar(10)  NOT NULL,
    [Telefon] nvarchar(10)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Autoes'
CREATE TABLE [dbo].[Autoes] (
    [AutoId] int IDENTITY(1,1) NOT NULL,
    [NumarAuto] nvarchar(max)  NOT NULL,
    [SerieSasiu] nvarchar(25)  NOT NULL,
    [ClientClientId] int  NOT NULL,
    [Client_ClientId] int  NOT NULL,
    [Sasiu_SasiuId] int  NOT NULL
);
GO

-- Creating table 'Sasius'
CREATE TABLE [dbo].[Sasius] (
    [SasiuId] int IDENTITY(1,1) NOT NULL,
    [CodSasiu] nvarchar(2)  NOT NULL,
    [Denumire] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Mecanics'
CREATE TABLE [dbo].[Mecanics] (
    [MecanicId] int IDENTITY(1,1) NOT NULL,
    [Nume] nvarchar(15)  NOT NULL,
    [Prenume] nvarchar(15)  NOT NULL,
    [esteDisponibil] bit  NOT NULL,
    [DetaliuComanda_DetaliuComandaId] int  NOT NULL
);
GO

-- Creating table 'Materials'
CREATE TABLE [dbo].[Materials] (
    [MaterialId] int IDENTITY(1,1) NOT NULL,
    [Denumire] nvarchar(50)  NOT NULL,
    [Cantitate] decimal(10,2)  NOT NULL,
    [Pret] decimal(18,0)  NOT NULL,
    [DataAprovizonare] datetime  NOT NULL,
    [Operatie_OperatieId] int  NOT NULL
);
GO

-- Creating table 'Imagines'
CREATE TABLE [dbo].[Imagines] (
    [ImagineId] int IDENTITY(1,1) NOT NULL,
    [Titlu] nvarchar(15)  NOT NULL,
    [Descriere] nvarchar(256)  NOT NULL,
    [Data] datetime  NOT NULL,
    [Foto] varbinary(max)  NOT NULL,
    [DetaliuComanda_DetaliuComandaId] int  NOT NULL
);
GO

-- Creating table 'Operaties'
CREATE TABLE [dbo].[Operaties] (
    [OperatieId] int IDENTITY(1,1) NOT NULL,
    [Denumire] nvarchar(256)  NOT NULL,
    [TimpExecutie] decimal(6,2)  NOT NULL,
    [Mecanic_MecanicId] int  NOT NULL
);
GO

-- Creating table 'Comandas'
CREATE TABLE [dbo].[Comandas] (
    [ComandaId] int IDENTITY(1,1) NOT NULL,
    [StareComanda] nvarchar(30)  NOT NULL,
    [DataSystem] datetime  NOT NULL,
    [DataProgramare] datetime  NOT NULL,
    [DataFinalizare] datetime  NOT NULL,
    [KmBord] int  NOT NULL,
    [Descriere] nvarchar(1024)  NOT NULL,
    [ValoarePiese] decimal(18,0)  NOT NULL,
    [Auto_AutoId] int  NOT NULL,
    [DetaliuComanda_DetaliuComandaId] int  NOT NULL
);
GO

-- Creating table 'DetaliuComandas'
CREATE TABLE [dbo].[DetaliuComandas] (
    [DetaliuComandaId] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClientId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ClientId] ASC);
GO

-- Creating primary key on [AutoId] in table 'Autoes'
ALTER TABLE [dbo].[Autoes]
ADD CONSTRAINT [PK_Autoes]
    PRIMARY KEY CLUSTERED ([AutoId] ASC);
GO

-- Creating primary key on [SasiuId] in table 'Sasius'
ALTER TABLE [dbo].[Sasius]
ADD CONSTRAINT [PK_Sasius]
    PRIMARY KEY CLUSTERED ([SasiuId] ASC);
GO

-- Creating primary key on [MecanicId] in table 'Mecanics'
ALTER TABLE [dbo].[Mecanics]
ADD CONSTRAINT [PK_Mecanics]
    PRIMARY KEY CLUSTERED ([MecanicId] ASC);
GO

-- Creating primary key on [MaterialId] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [PK_Materials]
    PRIMARY KEY CLUSTERED ([MaterialId] ASC);
GO

-- Creating primary key on [ImagineId] in table 'Imagines'
ALTER TABLE [dbo].[Imagines]
ADD CONSTRAINT [PK_Imagines]
    PRIMARY KEY CLUSTERED ([ImagineId] ASC);
GO

-- Creating primary key on [OperatieId] in table 'Operaties'
ALTER TABLE [dbo].[Operaties]
ADD CONSTRAINT [PK_Operaties]
    PRIMARY KEY CLUSTERED ([OperatieId] ASC);
GO

-- Creating primary key on [ComandaId] in table 'Comandas'
ALTER TABLE [dbo].[Comandas]
ADD CONSTRAINT [PK_Comandas]
    PRIMARY KEY CLUSTERED ([ComandaId] ASC);
GO

-- Creating primary key on [DetaliuComandaId] in table 'DetaliuComandas'
ALTER TABLE [dbo].[DetaliuComandas]
ADD CONSTRAINT [PK_DetaliuComandas]
    PRIMARY KEY CLUSTERED ([DetaliuComandaId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Client_ClientId] in table 'Autoes'
ALTER TABLE [dbo].[Autoes]
ADD CONSTRAINT [FK_ClientAuto]
    FOREIGN KEY ([Client_ClientId])
    REFERENCES [dbo].[Clients]
        ([ClientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientAuto'
CREATE INDEX [IX_FK_ClientAuto]
ON [dbo].[Autoes]
    ([Client_ClientId]);
GO

-- Creating foreign key on [Sasiu_SasiuId] in table 'Autoes'
ALTER TABLE [dbo].[Autoes]
ADD CONSTRAINT [FK_AutoSasiu]
    FOREIGN KEY ([Sasiu_SasiuId])
    REFERENCES [dbo].[Sasius]
        ([SasiuId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoSasiu'
CREATE INDEX [IX_FK_AutoSasiu]
ON [dbo].[Autoes]
    ([Sasiu_SasiuId]);
GO

-- Creating foreign key on [DetaliuComanda_DetaliuComandaId] in table 'Mecanics'
ALTER TABLE [dbo].[Mecanics]
ADD CONSTRAINT [FK_DetaliuComandaMecanic]
    FOREIGN KEY ([DetaliuComanda_DetaliuComandaId])
    REFERENCES [dbo].[DetaliuComandas]
        ([DetaliuComandaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetaliuComandaMecanic'
CREATE INDEX [IX_FK_DetaliuComandaMecanic]
ON [dbo].[Mecanics]
    ([DetaliuComanda_DetaliuComandaId]);
GO

-- Creating foreign key on [Mecanic_MecanicId] in table 'Operaties'
ALTER TABLE [dbo].[Operaties]
ADD CONSTRAINT [FK_MecanicOperatie]
    FOREIGN KEY ([Mecanic_MecanicId])
    REFERENCES [dbo].[Mecanics]
        ([MecanicId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MecanicOperatie'
CREATE INDEX [IX_FK_MecanicOperatie]
ON [dbo].[Operaties]
    ([Mecanic_MecanicId]);
GO

-- Creating foreign key on [Operatie_OperatieId] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [FK_OperatieMaterial]
    FOREIGN KEY ([Operatie_OperatieId])
    REFERENCES [dbo].[Operaties]
        ([OperatieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperatieMaterial'
CREATE INDEX [IX_FK_OperatieMaterial]
ON [dbo].[Materials]
    ([Operatie_OperatieId]);
GO

-- Creating foreign key on [DetaliuComanda_DetaliuComandaId] in table 'Imagines'
ALTER TABLE [dbo].[Imagines]
ADD CONSTRAINT [FK_DetaliuComandaImagine]
    FOREIGN KEY ([DetaliuComanda_DetaliuComandaId])
    REFERENCES [dbo].[DetaliuComandas]
        ([DetaliuComandaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetaliuComandaImagine'
CREATE INDEX [IX_FK_DetaliuComandaImagine]
ON [dbo].[Imagines]
    ([DetaliuComanda_DetaliuComandaId]);
GO

-- Creating foreign key on [Auto_AutoId] in table 'Comandas'
ALTER TABLE [dbo].[Comandas]
ADD CONSTRAINT [FK_AutoComanda]
    FOREIGN KEY ([Auto_AutoId])
    REFERENCES [dbo].[Autoes]
        ([AutoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoComanda'
CREATE INDEX [IX_FK_AutoComanda]
ON [dbo].[Comandas]
    ([Auto_AutoId]);
GO

-- Creating foreign key on [DetaliuComanda_DetaliuComandaId] in table 'Comandas'
ALTER TABLE [dbo].[Comandas]
ADD CONSTRAINT [FK_ComandaDetaliuComanda]
    FOREIGN KEY ([DetaliuComanda_DetaliuComandaId])
    REFERENCES [dbo].[DetaliuComandas]
        ([DetaliuComandaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComandaDetaliuComanda'
CREATE INDEX [IX_FK_ComandaDetaliuComanda]
ON [dbo].[Comandas]
    ([DetaliuComanda_DetaliuComandaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------