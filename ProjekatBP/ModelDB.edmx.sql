
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/31/2021 20:59:51
-- Generated from EDMX file: C:\Users\KORISNIK\Desktop\ProjekatBP\ProjekatBP\ModelDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjekatBP2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Gradovi'
CREATE TABLE [dbo].[Gradovi] (
    [ImeGrada] nvarchar(max)  NOT NULL,
    [PostanskiBroj] int  NOT NULL
);
GO

-- Creating table 'Ucenici'
CREATE TABLE [dbo].[Ucenici] (
    [JMBG_U] nvarchar(max)  NOT NULL,
    [Ime_U] nvarchar(max)  NOT NULL,
    [Prezime_U] nvarchar(max)  NOT NULL,
    [Godine] nvarchar(max)  NOT NULL,
    [RoditeljJMBG_Rod] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Zivis'
CREATE TABLE [dbo].[Zivis] (
    [GradPostanskiBroj] int  NOT NULL,
    [UcenikJMBG_U] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roditelji'
CREATE TABLE [dbo].[Roditelji] (
    [JMBG_Rod] nvarchar(max)  NOT NULL,
    [Ime_Rod] nvarchar(max)  NOT NULL,
    [Prezime_Rod] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PrivatneSkole'
CREATE TABLE [dbo].[PrivatneSkole] (
    [RegBroj] int IDENTITY(1,1) NOT NULL,
    [BrojTelefon] nvarchar(max)  NOT NULL,
    [ImeSkole] nvarchar(max)  NOT NULL,
    [GradPostanskiBroj] int  NOT NULL
);
GO

-- Creating table 'Pohadjas'
CREATE TABLE [dbo].[Pohadjas] (
    [UcenikJMBG_U] nvarchar(max)  NOT NULL,
    [PrivatnaSkolaRegBroj] int  NOT NULL
);
GO

-- Creating table 'Zaposlenis'
CREATE TABLE [dbo].[Zaposlenis] (
    [JMBG_R] nvarchar(max)  NOT NULL,
    [Godine] nvarchar(max)  NOT NULL,
    [Ime_R] nvarchar(max)  NOT NULL,
    [Prezime_R] nvarchar(max)  NOT NULL,
    [PrivatnaSkolaRegBroj] int  NOT NULL
);
GO

-- Creating table 'Predmeti'
CREATE TABLE [dbo].[Predmeti] (
    [ImePredmet] nvarchar(max)  NOT NULL,
    [BrojCasova] int  NOT NULL,
    [KabinetBroj] int  NOT NULL
);
GO

-- Creating table 'Kabineti'
CREATE TABLE [dbo].[Kabineti] (
    [Broj] int IDENTITY(1,1) NOT NULL,
    [Sprat] int  NOT NULL,
    [PrivatnaSkolaRegBroj] int  NOT NULL
);
GO

-- Creating table 'Cistis'
CREATE TABLE [dbo].[Cistis] (
    [SpremacicaJMBG_R] nvarchar(max)  NOT NULL,
    [KabinetBroj] int  NOT NULL
);
GO

-- Creating table 'Cuvas'
CREATE TABLE [dbo].[Cuvas] (
    [ObezbedjenjeJMBG_R] nvarchar(max)  NOT NULL,
    [KabinetBroj] int  NOT NULL
);
GO

-- Creating table 'Vlasnici'
CREATE TABLE [dbo].[Vlasnici] (
    [JMBG_V] nvarchar(max)  NOT NULL,
    [Ime_V] nvarchar(max)  NOT NULL,
    [Prezime_V] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Drzis'
CREATE TABLE [dbo].[Drzis] (
    [VlasnikJMBG_V] nvarchar(max)  NOT NULL,
    [DirektorJMBG_R] nvarchar(max)  NOT NULL,
    [PrivatnaSkolaRegBroj] int  NOT NULL
);
GO

-- Creating table 'PraviUgovors'
CREATE TABLE [dbo].[PraviUgovors] (
    [Nacin_Placanja] nvarchar(max)  NOT NULL,
    [UgovorBrojUgovora] int  NOT NULL,
    [DirektorJMBG_R] nvarchar(max)  NOT NULL,
    [RoditeljJMBG_Rod] nvarchar(max)  NULL
);
GO

-- Creating table 'Ugovori'
CREATE TABLE [dbo].[Ugovori] (
    [BrojUgovora] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Zaposlenis_Profesor'
CREATE TABLE [dbo].[Zaposlenis_Profesor] (
    [PredmetImePredmet] nvarchar(max)  NULL,
    [JMBG_R] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Zaposlenis_Spremacica'
CREATE TABLE [dbo].[Zaposlenis_Spremacica] (
    [JMBG_R] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Zaposlenis_Obezbedjenje'
CREATE TABLE [dbo].[Zaposlenis_Obezbedjenje] (
    [JMBG_R] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Zaposlenis_Direktor'
CREATE TABLE [dbo].[Zaposlenis_Direktor] (
    [JMBG_R] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PostanskiBroj] in table 'Gradovi'
ALTER TABLE [dbo].[Gradovi]
ADD CONSTRAINT [PK_Gradovi]
    PRIMARY KEY CLUSTERED ([PostanskiBroj] ASC);
GO

-- Creating primary key on [JMBG_U] in table 'Ucenici'
ALTER TABLE [dbo].[Ucenici]
ADD CONSTRAINT [PK_Ucenici]
    PRIMARY KEY CLUSTERED ([JMBG_U] ASC);
GO

-- Creating primary key on [GradPostanskiBroj], [UcenikJMBG_U] in table 'Zivis'
ALTER TABLE [dbo].[Zivis]
ADD CONSTRAINT [PK_Zivis]
    PRIMARY KEY CLUSTERED ([GradPostanskiBroj], [UcenikJMBG_U] ASC);
GO

-- Creating primary key on [JMBG_Rod] in table 'Roditelji'
ALTER TABLE [dbo].[Roditelji]
ADD CONSTRAINT [PK_Roditelji]
    PRIMARY KEY CLUSTERED ([JMBG_Rod] ASC);
GO

-- Creating primary key on [RegBroj] in table 'PrivatneSkole'
ALTER TABLE [dbo].[PrivatneSkole]
ADD CONSTRAINT [PK_PrivatneSkole]
    PRIMARY KEY CLUSTERED ([RegBroj] ASC);
GO

-- Creating primary key on [UcenikJMBG_U], [PrivatnaSkolaRegBroj] in table 'Pohadjas'
ALTER TABLE [dbo].[Pohadjas]
ADD CONSTRAINT [PK_Pohadjas]
    PRIMARY KEY CLUSTERED ([UcenikJMBG_U], [PrivatnaSkolaRegBroj] ASC);
GO

-- Creating primary key on [JMBG_R] in table 'Zaposlenis'
ALTER TABLE [dbo].[Zaposlenis]
ADD CONSTRAINT [PK_Zaposlenis]
    PRIMARY KEY CLUSTERED ([JMBG_R] ASC);
GO

-- Creating primary key on [ImePredmet] in table 'Predmeti'
ALTER TABLE [dbo].[Predmeti]
ADD CONSTRAINT [PK_Predmeti]
    PRIMARY KEY CLUSTERED ([ImePredmet] ASC);
GO

-- Creating primary key on [Broj] in table 'Kabineti'
ALTER TABLE [dbo].[Kabineti]
ADD CONSTRAINT [PK_Kabineti]
    PRIMARY KEY CLUSTERED ([Broj] ASC);
GO

-- Creating primary key on [SpremacicaJMBG_R], [KabinetBroj] in table 'Cistis'
ALTER TABLE [dbo].[Cistis]
ADD CONSTRAINT [PK_Cistis]
    PRIMARY KEY CLUSTERED ([SpremacicaJMBG_R], [KabinetBroj] ASC);
GO

-- Creating primary key on [KabinetBroj], [ObezbedjenjeJMBG_R] in table 'Cuvas'
ALTER TABLE [dbo].[Cuvas]
ADD CONSTRAINT [PK_Cuvas]
    PRIMARY KEY CLUSTERED ([KabinetBroj], [ObezbedjenjeJMBG_R] ASC);
GO

-- Creating primary key on [JMBG_V] in table 'Vlasnici'
ALTER TABLE [dbo].[Vlasnici]
ADD CONSTRAINT [PK_Vlasnici]
    PRIMARY KEY CLUSTERED ([JMBG_V] ASC);
GO

-- Creating primary key on [VlasnikJMBG_V], [PrivatnaSkolaRegBroj] in table 'Drzis'
ALTER TABLE [dbo].[Drzis]
ADD CONSTRAINT [PK_Drzis]
    PRIMARY KEY CLUSTERED ([VlasnikJMBG_V], [PrivatnaSkolaRegBroj] ASC);
GO

-- Creating primary key on [DirektorJMBG_R], [UgovorBrojUgovora] in table 'PraviUgovors'
ALTER TABLE [dbo].[PraviUgovors]
ADD CONSTRAINT [PK_PraviUgovors]
    PRIMARY KEY CLUSTERED ([DirektorJMBG_R], [UgovorBrojUgovora] ASC);
GO

-- Creating primary key on [BrojUgovora] in table 'Ugovori'
ALTER TABLE [dbo].[Ugovori]
ADD CONSTRAINT [PK_Ugovori]
    PRIMARY KEY CLUSTERED ([BrojUgovora] ASC);
GO

-- Creating primary key on [JMBG_R] in table 'Zaposlenis_Profesor'
ALTER TABLE [dbo].[Zaposlenis_Profesor]
ADD CONSTRAINT [PK_Zaposlenis_Profesor]
    PRIMARY KEY CLUSTERED ([JMBG_R] ASC);
GO

-- Creating primary key on [JMBG_R] in table 'Zaposlenis_Spremacica'
ALTER TABLE [dbo].[Zaposlenis_Spremacica]
ADD CONSTRAINT [PK_Zaposlenis_Spremacica]
    PRIMARY KEY CLUSTERED ([JMBG_R] ASC);
GO

-- Creating primary key on [JMBG_R] in table 'Zaposlenis_Obezbedjenje'
ALTER TABLE [dbo].[Zaposlenis_Obezbedjenje]
ADD CONSTRAINT [PK_Zaposlenis_Obezbedjenje]
    PRIMARY KEY CLUSTERED ([JMBG_R] ASC);
GO

-- Creating primary key on [JMBG_R] in table 'Zaposlenis_Direktor'
ALTER TABLE [dbo].[Zaposlenis_Direktor]
ADD CONSTRAINT [PK_Zaposlenis_Direktor]
    PRIMARY KEY CLUSTERED ([JMBG_R] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GradPostanskiBroj] in table 'Zivis'
ALTER TABLE [dbo].[Zivis]
ADD CONSTRAINT [FK_GradZivi]
    FOREIGN KEY ([GradPostanskiBroj])
    REFERENCES [dbo].[Gradovi]
        ([PostanskiBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UcenikJMBG_U] in table 'Zivis'
ALTER TABLE [dbo].[Zivis]
ADD CONSTRAINT [FK_UcenikZivi]
    FOREIGN KEY ([UcenikJMBG_U])
    REFERENCES [dbo].[Ucenici]
        ([JMBG_U])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UcenikZivi'
CREATE INDEX [IX_FK_UcenikZivi]
ON [dbo].[Zivis]
    ([UcenikJMBG_U]);
GO

-- Creating foreign key on [RoditeljJMBG_Rod] in table 'Ucenici'
ALTER TABLE [dbo].[Ucenici]
ADD CONSTRAINT [FK_RoditeljUcenik]
    FOREIGN KEY ([RoditeljJMBG_Rod])
    REFERENCES [dbo].[Roditelji]
        ([JMBG_Rod])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoditeljUcenik'
CREATE INDEX [IX_FK_RoditeljUcenik]
ON [dbo].[Ucenici]
    ([RoditeljJMBG_Rod]);
GO

-- Creating foreign key on [GradPostanskiBroj] in table 'PrivatneSkole'
ALTER TABLE [dbo].[PrivatneSkole]
ADD CONSTRAINT [FK_GradPrivatnaSkola]
    FOREIGN KEY ([GradPostanskiBroj])
    REFERENCES [dbo].[Gradovi]
        ([PostanskiBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradPrivatnaSkola'
CREATE INDEX [IX_FK_GradPrivatnaSkola]
ON [dbo].[PrivatneSkole]
    ([GradPostanskiBroj]);
GO

-- Creating foreign key on [UcenikJMBG_U] in table 'Pohadjas'
ALTER TABLE [dbo].[Pohadjas]
ADD CONSTRAINT [FK_PohadjaUcenik]
    FOREIGN KEY ([UcenikJMBG_U])
    REFERENCES [dbo].[Ucenici]
        ([JMBG_U])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PrivatnaSkolaRegBroj] in table 'Pohadjas'
ALTER TABLE [dbo].[Pohadjas]
ADD CONSTRAINT [FK_PohadjaPrivatnaSkola]
    FOREIGN KEY ([PrivatnaSkolaRegBroj])
    REFERENCES [dbo].[PrivatneSkole]
        ([RegBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PohadjaPrivatnaSkola'
CREATE INDEX [IX_FK_PohadjaPrivatnaSkola]
ON [dbo].[Pohadjas]
    ([PrivatnaSkolaRegBroj]);
GO

-- Creating foreign key on [PrivatnaSkolaRegBroj] in table 'Zaposlenis'
ALTER TABLE [dbo].[Zaposlenis]
ADD CONSTRAINT [FK_ZaposleniPrivatnaSkola]
    FOREIGN KEY ([PrivatnaSkolaRegBroj])
    REFERENCES [dbo].[PrivatneSkole]
        ([RegBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZaposleniPrivatnaSkola'
CREATE INDEX [IX_FK_ZaposleniPrivatnaSkola]
ON [dbo].[Zaposlenis]
    ([PrivatnaSkolaRegBroj]);
GO

-- Creating foreign key on [PredmetImePredmet] in table 'Zaposlenis_Profesor'
ALTER TABLE [dbo].[Zaposlenis_Profesor]
ADD CONSTRAINT [FK_PredmetProfesor]
    FOREIGN KEY ([PredmetImePredmet])
    REFERENCES [dbo].[Predmeti]
        ([ImePredmet])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PredmetProfesor'
CREATE INDEX [IX_FK_PredmetProfesor]
ON [dbo].[Zaposlenis_Profesor]
    ([PredmetImePredmet]);
GO

-- Creating foreign key on [KabinetBroj] in table 'Predmeti'
ALTER TABLE [dbo].[Predmeti]
ADD CONSTRAINT [FK_KabinetPredmet]
    FOREIGN KEY ([KabinetBroj])
    REFERENCES [dbo].[Kabineti]
        ([Broj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KabinetPredmet'
CREATE INDEX [IX_FK_KabinetPredmet]
ON [dbo].[Predmeti]
    ([KabinetBroj]);
GO

-- Creating foreign key on [PrivatnaSkolaRegBroj] in table 'Kabineti'
ALTER TABLE [dbo].[Kabineti]
ADD CONSTRAINT [FK_PrivatnaSkolaKabinet]
    FOREIGN KEY ([PrivatnaSkolaRegBroj])
    REFERENCES [dbo].[PrivatneSkole]
        ([RegBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrivatnaSkolaKabinet'
CREATE INDEX [IX_FK_PrivatnaSkolaKabinet]
ON [dbo].[Kabineti]
    ([PrivatnaSkolaRegBroj]);
GO

-- Creating foreign key on [SpremacicaJMBG_R] in table 'Cistis'
ALTER TABLE [dbo].[Cistis]
ADD CONSTRAINT [FK_SpremacicaCisti]
    FOREIGN KEY ([SpremacicaJMBG_R])
    REFERENCES [dbo].[Zaposlenis_Spremacica]
        ([JMBG_R])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KabinetBroj] in table 'Cistis'
ALTER TABLE [dbo].[Cistis]
ADD CONSTRAINT [FK_CistiKabinet]
    FOREIGN KEY ([KabinetBroj])
    REFERENCES [dbo].[Kabineti]
        ([Broj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CistiKabinet'
CREATE INDEX [IX_FK_CistiKabinet]
ON [dbo].[Cistis]
    ([KabinetBroj]);
GO

-- Creating foreign key on [ObezbedjenjeJMBG_R] in table 'Cuvas'
ALTER TABLE [dbo].[Cuvas]
ADD CONSTRAINT [FK_CuvaObezbedjenje]
    FOREIGN KEY ([ObezbedjenjeJMBG_R])
    REFERENCES [dbo].[Zaposlenis_Obezbedjenje]
        ([JMBG_R])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuvaObezbedjenje'
CREATE INDEX [IX_FK_CuvaObezbedjenje]
ON [dbo].[Cuvas]
    ([ObezbedjenjeJMBG_R]);
GO

-- Creating foreign key on [KabinetBroj] in table 'Cuvas'
ALTER TABLE [dbo].[Cuvas]
ADD CONSTRAINT [FK_CuvaKabinet]
    FOREIGN KEY ([KabinetBroj])
    REFERENCES [dbo].[Kabineti]
        ([Broj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VlasnikJMBG_V] in table 'Drzis'
ALTER TABLE [dbo].[Drzis]
ADD CONSTRAINT [FK_DrziVlasnik]
    FOREIGN KEY ([VlasnikJMBG_V])
    REFERENCES [dbo].[Vlasnici]
        ([JMBG_V])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DirektorJMBG_R] in table 'Drzis'
ALTER TABLE [dbo].[Drzis]
ADD CONSTRAINT [FK_DrziDirektor]
    FOREIGN KEY ([DirektorJMBG_R])
    REFERENCES [dbo].[Zaposlenis_Direktor]
        ([JMBG_R])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrziDirektor'
CREATE INDEX [IX_FK_DrziDirektor]
ON [dbo].[Drzis]
    ([DirektorJMBG_R]);
GO

-- Creating foreign key on [PrivatnaSkolaRegBroj] in table 'Drzis'
ALTER TABLE [dbo].[Drzis]
ADD CONSTRAINT [FK_PrivatnaSkolaDrzi]
    FOREIGN KEY ([PrivatnaSkolaRegBroj])
    REFERENCES [dbo].[PrivatneSkole]
        ([RegBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrivatnaSkolaDrzi'
CREATE INDEX [IX_FK_PrivatnaSkolaDrzi]
ON [dbo].[Drzis]
    ([PrivatnaSkolaRegBroj]);
GO

-- Creating foreign key on [UgovorBrojUgovora] in table 'PraviUgovors'
ALTER TABLE [dbo].[PraviUgovors]
ADD CONSTRAINT [FK_PraviUgovorUgovor]
    FOREIGN KEY ([UgovorBrojUgovora])
    REFERENCES [dbo].[Ugovori]
        ([BrojUgovora])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PraviUgovorUgovor'
CREATE INDEX [IX_FK_PraviUgovorUgovor]
ON [dbo].[PraviUgovors]
    ([UgovorBrojUgovora]);
GO

-- Creating foreign key on [DirektorJMBG_R] in table 'PraviUgovors'
ALTER TABLE [dbo].[PraviUgovors]
ADD CONSTRAINT [FK_PraviUgovorDirektor]
    FOREIGN KEY ([DirektorJMBG_R])
    REFERENCES [dbo].[Zaposlenis_Direktor]
        ([JMBG_R])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoditeljJMBG_Rod] in table 'PraviUgovors'
ALTER TABLE [dbo].[PraviUgovors]
ADD CONSTRAINT [FK_PraviUgovorRoditelj]
    FOREIGN KEY ([RoditeljJMBG_Rod])
    REFERENCES [dbo].[Roditelji]
        ([JMBG_Rod])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PraviUgovorRoditelj'
CREATE INDEX [IX_FK_PraviUgovorRoditelj]
ON [dbo].[PraviUgovors]
    ([RoditeljJMBG_Rod]);
GO

-- Creating foreign key on [JMBG_R] in table 'Zaposlenis_Profesor'
ALTER TABLE [dbo].[Zaposlenis_Profesor]
ADD CONSTRAINT [FK_Profesor_inherits_Zaposleni]
    FOREIGN KEY ([JMBG_R])
    REFERENCES [dbo].[Zaposlenis]
        ([JMBG_R])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG_R] in table 'Zaposlenis_Spremacica'
ALTER TABLE [dbo].[Zaposlenis_Spremacica]
ADD CONSTRAINT [FK_Spremacica_inherits_Zaposleni]
    FOREIGN KEY ([JMBG_R])
    REFERENCES [dbo].[Zaposlenis]
        ([JMBG_R])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG_R] in table 'Zaposlenis_Obezbedjenje'
ALTER TABLE [dbo].[Zaposlenis_Obezbedjenje]
ADD CONSTRAINT [FK_Obezbedjenje_inherits_Zaposleni]
    FOREIGN KEY ([JMBG_R])
    REFERENCES [dbo].[Zaposlenis]
        ([JMBG_R])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG_R] in table 'Zaposlenis_Direktor'
ALTER TABLE [dbo].[Zaposlenis_Direktor]
ADD CONSTRAINT [FK_Direktor_inherits_Zaposleni]
    FOREIGN KEY ([JMBG_R])
    REFERENCES [dbo].[Zaposlenis]
        ([JMBG_R])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------