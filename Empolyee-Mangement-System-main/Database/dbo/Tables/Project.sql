CREATE TABLE [dbo].[Project] (
    [ProjectId]   INT           IDENTITY (1, 1) NOT NULL,
    [ProjectName] VARCHAR (50)  NOT NULL,
    [ProjectDesc] VARCHAR (100) NOT NULL,
    [StartDate]   DATE          NOT NULL,
    [EndDate]     DATE          NOT NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([ProjectId] ASC)
);

