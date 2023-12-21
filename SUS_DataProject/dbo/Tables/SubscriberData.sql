CREATE TABLE [dbo].[SubscriberData] (
    [Id]             INT         IDENTITY (1, 1) NOT NULL,
    [SubscriberName] NCHAR (100) NULL,
    [RecievedData]   NCHAR (100) NULL,
    CONSTRAINT [PK_SubscriberData] PRIMARY KEY CLUSTERED ([Id] ASC)
);

