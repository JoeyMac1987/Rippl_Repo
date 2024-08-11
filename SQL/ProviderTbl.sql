CREATE TABLE [dbo].[Provider] (
    [ProviderID]    INT  IDENTITY(1, 1)   NOT NULL,
    [ProviderName]   VARCHAR (100) NOT NULL,
    [ProviderAddress]VARCHAR (200) NOT NULL,
    [ProviderEmail] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Provder] PRIMARY KEY CLUSTERED ([ProviderID] ASC)
);


