CREATE TABLE [dbo].[Notification] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Username]             VARCHAR (50)   NOT NULL,
    [Message]              VARCHAR (1000) NOT NULL,
    [MessageType]          VARCHAR (50)   NOT NULL,
    [NotificationDateTime] DATETIME       NOT NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([Id] ASC)
);

