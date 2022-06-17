CREATE TABLE [dbo].[Role] (
    [RoleId]      INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]    NCHAR (10)    NOT NULL,
    [dateCreated] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Roll] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);

