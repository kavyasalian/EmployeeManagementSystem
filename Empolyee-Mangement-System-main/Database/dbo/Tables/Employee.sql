CREATE TABLE [dbo].[Employee] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50) NOT NULL,
    [LastName]     VARCHAR (50) NOT NULL,
    [Gender]       VARCHAR (50) NOT NULL,
    [Email]        VARCHAR (50) NOT NULL,
    [Phone]        VARCHAR (50) NOT NULL,
    [DateCreated]  VARCHAR (50) NOT NULL,
    [DateModified] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC)
);

