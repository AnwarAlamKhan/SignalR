CREATE TABLE [dbo].[HubConnection] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [ConnectionId] VARCHAR (50) NOT NULL,
    [Username]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_HubConnection] PRIMARY KEY CLUSTERED ([Id] ASC)
);

