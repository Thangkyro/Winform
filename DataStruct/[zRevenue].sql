USE [THANH]
GO

/****** Object:  Table [dbo].[tblAUS_Service]    Script Date: 09/05/2021 5:30:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zRevenue](
	[branchId] [INT] NOT NULL,
	[BookID] [INT] NOT NULL,
	[BillID] [INT] NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Year] [INT] NULL,
	[Month] [INT] NULL,
	[BillDate] [datetime] NULL,
	[BillCode] [varchar](20) NULL,
	[CustId] [INT] NULL,
	[Status] [varchar](100) NULL,
	[TotalDiscount] [Decimal](19, 6) NOT NULL,
	[PaymentCash] [Decimal](19, 6) NOT NULL,
	[PaymentCard] [Decimal](19, 6) NOT NULL,
	[PaymentVoucher] [Decimal](19, 6) NOT NULL,
	[PaymentPreriod] [Decimal](19, 6) NOT NULL,
	[VoucherID] [INT] NULL,
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zRevenue] ADD  CONSTRAINT [DF_zRevenue_TotalDiscount]  DEFAULT ((0)) FOR [TotalDiscount]
GO

ALTER TABLE [dbo].[zRevenue] ADD  CONSTRAINT [DF_zRevenue_PaymentCash]  DEFAULT ((0)) FOR [PaymentCash]
GO

ALTER TABLE [dbo].[zRevenue] ADD  CONSTRAINT [DF_zRevenue_PaymentCard]  DEFAULT ((0)) FOR [PaymentCard]
GO

ALTER TABLE [dbo].[zRevenue] ADD  CONSTRAINT [DF_zRevenue_PaymentVoucher]  DEFAULT ((0)) FOR [PaymentVoucher]
GO

ALTER TABLE [dbo].[zRevenue] ADD  CONSTRAINT [DF_zRevenue_PaymentPreriod]  DEFAULT ((0)) FOR [PaymentPreriod]
GO



