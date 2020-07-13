CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC)
);


CREATE TABLE [dbo].[Cinemas] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    [Street] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Cinemas] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Sessions] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [FilmName]    NVARCHAR (MAX) NULL,
    [BeginTime]   DATETIME       NOT NULL,
    [Duration]    INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [LoungeNum]   FLOAT (53)     NOT NULL,
    [CinemaID]    INT            NOT NULL,
    [OnStock]     BIT            NOT NULL,
    [Cost]        FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_dbo.Sessions] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Tickets] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [OwnerID]        INT            NOT NULL,
    [FilmName]       NVARCHAR (MAX) NULL,
    [BeginTime]      DATETIME       NOT NULL,
    [LoungeNum]      FLOAT (53)     NOT NULL,
    [CinemaID]       INT            NOT NULL,
    [SessionID]      INT            NOT NULL,
    [Row]            INT            NOT NULL,
    [Place]          INT            NOT NULL,
    [Cost]           FLOAT (53)     NOT NULL,
    [StatusOfTicket] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Tickets] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[User] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Login]         NVARCHAR (MAX) NULL,
    [Password]      NVARCHAR (MAX) NULL,
    [PhoneNumber]   BIGINT         NOT NULL,
    [AmountSpent]   FLOAT (53)     NOT NULL,
    [TypeOfUser]    INT            NOT NULL,
    [LevelOfClient] INT            NOT NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([ID] ASC)
);

