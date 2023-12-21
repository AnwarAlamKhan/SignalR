CREATE TABLE [dbo].[TblUser] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (50)   NOT NULL,
    [Password] VARCHAR (50)   NOT NULL,
    [Dept]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_TblUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);

