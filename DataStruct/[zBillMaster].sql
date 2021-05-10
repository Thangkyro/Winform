USE [THANH]
GO

/****** Object:  Table [dbo].[tblAUS_Service]    Script Date: 09/05/2021 5:30:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zBillMaster](
	[BillID] [INT] IDENTITY(1,1) NOT NULL,
	[branchId] [INT] NOT NULL,
	[BillDate] [datetime] NULL,
	[BillCode] [varchar](20) NULL,
	[CustId] [INT] NULL,
	[CustomerPhone] [varchar](100) NULL,
	[TotalEstimatePrice] [decimal](19,4) NOT NULL,
	[TotalEstimateTime] [decimal](19,4) NOT NULL,
	[StaffRequire] [decimal](19,4) NOT NULL,
	[Status] [varchar](100) NULL,
	[Timefinish] [datetime] NULL,
	[TotalDiscount] [Decimal](19, 4) NOT NULL,
	[PaymentCash] [Decimal](19, 4) NOT NULL,
	[PaymentCard] [Decimal](19, 4) NOT NULL,
	[PaymentVoucher] [Decimal](19, 4) NOT NULL,
	[BookID] [INT] NOT NULL,
	[VoucherID] [INT] NOT NULL,
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zBillMaster] ADD  CONSTRAINT [DF_zBillMaster_TotalEstimatePrice]  DEFAULT ((0)) FOR [TotalEstimatePrice]
GO

ALTER TABLE [dbo].[zBillMaster] ADD  CONSTRAINT [DF_zBillMaster_TotalEstimateTime]  DEFAULT ((0)) FOR [TotalEstimateTime]
GO

ALTER TABLE [dbo].[zBillMaster] ADD  CONSTRAINT [DF_zBillMaster_StaffRequire]  DEFAULT ((0)) FOR [StaffRequire]
GO

ALTER TABLE [dbo].[zBillMaster] ADD  CONSTRAINT [DF_zBillMaster_TotalDiscount]  DEFAULT ((0)) FOR [TotalDiscount]
GO

ALTER TABLE [dbo].[zBillMaster] ADD  CONSTRAINT [DF_zBillMaster_PaymentCash]  DEFAULT ((0)) FOR [PaymentCash]
GO

ALTER TABLE [dbo].[zBillMaster] ADD  CONSTRAINT [DF_zBillMaster_PaymentCard]  DEFAULT ((0)) FOR [PaymentCard]
GO

ALTER TABLE [dbo].[zBillMaster] ADD  CONSTRAINT [DF_zBillMaster_PaymentVoucher]  DEFAULT ((0)) FOR [PaymentVoucher]
GO


