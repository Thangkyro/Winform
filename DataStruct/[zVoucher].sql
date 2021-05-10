USE [THANH]
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zVoucher](
	[VoucherID] [INT] IDENTITY(1,1) NOT NULL,
	[VoucherCode] [varchar](30)  NOT NULL,
	[Amount] [decimal](19,4) NOT NULL, 
	[AvailableAmount] [varchar](50)  NULL,
	[IssueDate]  [datetime] NULL,
	[IssueBy] [int],
	[VoucherFrom] [datetime],
	[VoucherTo] [datetime],
	[zPrintname] [varchar](50) NULL,
	[Decriptions] [varchar](2000) NULL,
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zVoucher] ADD  CONSTRAINT [DF_zVoucher_Amount]  DEFAULT ((0)) FOR [Amount]
GO
