USE [THANH]
GO

/****** Object:  Table [dbo].[tblAUS_Service]    Script Date: 09/05/2021 5:30:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zBookingDetail](
	[BookDTID] [INT] IDENTITY(1,1) NOT NULL,
	[BookID] [INT] NOT NULL,
	[OrderNumber] [INT] NOT NULL,
	[branchId] [INT] NOT NULL,
	[ServiceID] [INT] NOT NULL,	
	[Quantity] [Decimal](19, 4) NOT NULL,
	[EstimatePrice] [Decimal](19, 4) NOT NULL,
	[EstimateTime] [Decimal](19, 4) NOT NULL,
	[Note] [varchar](1000) NULL,
	[StaffId] [int] NULL,	
	[created_by] [int],
	[created_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zBookingDetail] ADD  CONSTRAINT [DF_zBookingDetail_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO

ALTER TABLE [dbo].[zBookingDetail] ADD  CONSTRAINT [DF_zBookingDetail_EstimatePrice]  DEFAULT ((0)) FOR [EstimatePrice]
GO

ALTER TABLE [dbo].[zBookingDetail] ADD  CONSTRAINT [DF_zBookingDetail_EstimateTime]  DEFAULT ((0)) FOR [EstimateTime]
GO

