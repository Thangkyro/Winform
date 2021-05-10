USE [THANH]
GO

/****** Object:  Table [dbo].[tblAUS_Service]    Script Date: 09/05/2021 5:30:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zRevenueDetail](
	[branchId] [INT] NOT NULL,
	[BillDtID] [INT] NULL,
	[BillID] [INT]  NULL,
	[BookID] [INT] NULL,
	[BookDTID] [INT] NULL,
	[Code] [varchar](10) NULL,
	[OrderNumber] [INT] NULL,
	[Year] [INT] NULL,
	[Month] [INT] NULL,
	[BillDate] [datetime] NULL,
	[BillCode] [varchar](20) NULL,
	[CustId] [INT] NULL,
	[PaymentVoucher] [Decimal](19, 6) NOT NULL,
	[ServiceID] [INT] NULL,
	[Price] [Decimal](19, 6) NOT NULL,
	[Discount] [Decimal](19, 6) NOT NULL,
	[Payment] [Decimal](19, 6) NOT NULL,
	[VoucherID] [INT] NULL,
	[PaymentPreriod] [Decimal](19, 6) NOT NULL,
	[StaffId] [INT] NULL,
	[created_by] [int],
	[created_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zRevenueDetail] ADD  CONSTRAINT [DF_zRevenueDetail_PaymentVoucher]  DEFAULT ((0)) FOR [PaymentVoucher]
GO

ALTER TABLE [dbo].[zRevenueDetail] ADD  CONSTRAINT [DF_zRevenueDetail_Price]  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE [dbo].[zRevenueDetail] ADD  CONSTRAINT [DF_zRevenueDetail_Discount]  DEFAULT ((0)) FOR [Discount]
GO

ALTER TABLE [dbo].[zRevenueDetail] ADD  CONSTRAINT [DF_zRevenueDetail_Payment]  DEFAULT ((0)) FOR [Payment]
GO

ALTER TABLE [dbo].[zRevenueDetail] ADD  CONSTRAINT [DF_zRevenueDetail_PaymentPreriod]  DEFAULT ((0)) FOR [PaymentPreriod]
GO



