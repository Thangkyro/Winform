USE [THANH]
GO

/****** Object:  Table [dbo].[tblAUS_Service]    Script Date: 09/05/2021 5:30:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zBillDetail](
	[BillDtID] [INT] IDENTITY(1,1) NOT NULL,
	[BillID] [INT] NOT NULL,
	[OrderNumber] [INT] NOT NULL,
	[branchId] [INT] NOT NULL,
	[ServiceID] [INT] NULL,
	[Price] [decimal](19,4) NOT NULL,
	[Discount] [decimal](19,4) NOT NULL,
	[Payment] [decimal](19,4) NOT NULL,
	[Note] [varchar](1000) NULL,
	[BookID] [INT] NULL,
	[BookDTID] [INT] NULL,
	[StaffId] [INT] NULL,
	[created_by] [int],
	[created_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zBillDetail] ADD  CONSTRAINT [DF_zBillDetail_Price]  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE [dbo].[zBillDetail] ADD  CONSTRAINT [DF_zBillDetail_Discount]  DEFAULT ((0)) FOR [Discount]
GO

ALTER TABLE [dbo].[zBillDetail] ADD  CONSTRAINT [DF_zBillDetail_Payment]  DEFAULT ((0)) FOR [Payment]
GO
