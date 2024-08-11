CREATE TABLE [dbo].[Providers] (
    [ProviderID]     INT            IDENTITY (1, 1) NOT NULL,
    [ProviderName]   VARCHAR (100)  NOT NULL,
    [ProviderAPIURL] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED ([ProviderID] ASC)
);

