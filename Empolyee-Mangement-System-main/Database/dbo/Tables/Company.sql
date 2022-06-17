CREATE TABLE [dbo].[Company] (
    [CompanyId]      INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName]    VARCHAR (50)  NOT NULL,
    [CompanyAddress] VARCHAR (100) NOT NULL,
    [CompanyPhone]   VARCHAR (12)  NOT NULL,
    CONSTRAINT [PK_CompanyDetails] PRIMARY KEY CLUSTERED ([CompanyId] ASC),
    CONSTRAINT [FK_Company_Employee] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId])
);



