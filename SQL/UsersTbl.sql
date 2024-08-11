CREATE TABLE [dbo].[Users] (
    [UserID]      INT           IDENTITY (1, 1) NOT NULL,
    [UserName]    VARCHAR (100) NOT NULL,
    [UserAddress] VARCHAR (200) NOT NULL,
    [UserEmail]   VARCHAR (100) NOT NULL,
    [Active]      BIT           CONSTRAINT [DEFAULT_Users_Active] DEFAULT 1 NOT NULL,
    CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED ([UserID] ASC)
);