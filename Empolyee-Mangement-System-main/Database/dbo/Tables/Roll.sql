CREATE TABLE [dbo].[Roll] (
    [roll_id]      INT        IDENTITY (1, 1) NOT NULL,
    [roll_name]    NCHAR (10) NOT NULL,
    [date_created] DATETIME   NOT NULL,
    CONSTRAINT [PK_Roll] PRIMARY KEY CLUSTERED ([roll_id] ASC)
);

