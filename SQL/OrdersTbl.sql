CREATE TABLE [dbo].[Orders] (
    [GUID]       UNIQUEIDENTIFIER NOT NULL,
    [OrderID]    INT              IDENTITY (1, 1) NOT NULL,
    [UserID]     INT              NOT NULL,
    [ProviderID] INT              NOT NULL,
    [VoucherID]  INT              NOT NULL,
    [Quantity]   INT              NOT NULL,
    [Total]      MONEY            NOT NULL,
    [TimeStamp]  DATETIME         NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([GUID] ASC)
);

