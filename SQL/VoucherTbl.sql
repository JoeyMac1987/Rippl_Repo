CREATE TABLE [dbo].[Voucher] (
    [VoucherID]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (100) NOT NULL,
    [Value]      INT           NOT NULL,
    [ProviderID] INT           NOT NULL,
    CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED ([VoucherID] ASC)
);

