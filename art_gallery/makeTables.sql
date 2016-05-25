CREATE TABLE [dbo].[Agent] (
    [AgentId]     INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (50)  NOT NULL,
    [LasName]     VARCHAR (50)  NOT NULL,
    [Location]    VARCHAR (50)  NULL,
    [PhoneNumber] VARCHAR (12)  NULL,
    [Address]     VARCHAR (100) NULL,
    [Active]      BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([AgentId] ASC)
);

CREATE TABLE [dbo].[Artist] (
    [ArtistId]  INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [BirthYear] VARCHAR (4)  NOT NULL,
    [DeathYear] VARCHAR (4)  NULL,
    PRIMARY KEY CLUSTERED ([ArtistId] ASC)
);

CREATE TABLE [dbo].[ArtShow] (
    [ArtShowId]    INT           IDENTITY (1, 1) NOT NULL,
    [ArtWorkId]    INT           NULL,
    [ShowLocation] VARCHAR (50)  NULL,
    [Agents]       VARCHAR (100) NULL,
    [Overhead]     VARCHAR (100) NULL,
    [ShowDate]     DATE          NULL,
    [ShowName]     VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ArtShowId] ASC),
    CONSTRAINT [FK_ArtShow_ArtWork] FOREIGN KEY ([ArtWorkId]) REFERENCES [dbo].[ArtWork] ([ArtWorkId])
);

CREATE TABLE [dbo].[ArtWork] (
    [ArtWorkId]           INT          IDENTITY (1, 1) NOT NULL,
    [ArtistId]            INT          NOT NULL,
    [Title]               VARCHAR (50) NOT NULL,
    [YearOriginalCreated] VARCHAR (4)  NULL,
    [Category]            VARCHAR (50) NULL,
    [Medium]              VARCHAR (50) NULL,
    [Dimensions]          VARCHAR (50) NULL,
    [NumberMade]          INT          NULL,
    [NumberInInventory]   INT          NULL,
    [NumberSold]          INT          NULL,
    PRIMARY KEY CLUSTERED ([ArtWorkId] ASC),
    CONSTRAINT [FK_ArtWork_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId])
);

CREATE TABLE [dbo].[Customer] (
    [CustomerId]  INT           IDENTITY (1, 1) NOT NULL,
    [AgentId]     INT           NOT NULL,
    [FirstName]   VARCHAR (50)  NULL,
    [LastName]    VARCHAR (50)  NULL,
    [Address]     VARCHAR (100) NOT NULL,
    [PhoneNumber] VARCHAR (12)  NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_Customer_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[Agent] ([AgentId])
);

CREATE TABLE [dbo].[IndividualPiece] (
    [IndividualPieceId] INT           IDENTITY (1, 1) NOT NULL,
    [ArtWorkId]         INT           NOT NULL,
    [Image]             VARCHAR (500) NULL,
    [DateCreated]       VARCHAR (50)  NULL,
    [Cost]              MONEY         NULL,
    [Price]             MONEY         NULL,
    [Sold]              BIT           NULL,
    [Location]          VARCHAR (50)  NULL,
    [EditionNumber]     VARCHAR (10)  NULL,
    [PurchaseURL]       VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([IndividualPieceId] ASC),
    CONSTRAINT [FK_IndividualPiece_ArtWork] FOREIGN KEY ([ArtWorkId]) REFERENCES [dbo].[ArtWork] ([ArtWorkId])
);

CREATE TABLE [dbo].[Invoice] (
    [InvoiceId]         INT           IDENTITY (1, 1) NOT NULL,
    [CustomerId]        INT           NOT NULL,
    [AgentId]           INT           NOT NULL,
    [IndividualPieceId] INT           NOT NULL,
    [PaymentMethod]     VARCHAR (55)  NULL,
    [ShippingAddress]   VARCHAR (100) NULL,
    [PieceSold]         VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([InvoiceId] ASC),
    CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId]),
    CONSTRAINT [FK_Invoice_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[Agent] ([AgentId]),
    CONSTRAINT [FK_Invoice_IndividualPiece] FOREIGN KEY ([IndividualPieceId]) REFERENCES [dbo].[IndividualPiece] ([IndividualPieceId])
);
