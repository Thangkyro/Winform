USE [THANH]
GO

/****** Object:  Table [dbo].[tblAUS_Service]    Script Date: 09/05/2021 5:30:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zBookingMaster](
	[BookID] [INT] IDENTITY(1,1) NOT NULL,
	[branchId] [INT] NOT NULL,
	[BookingDate] [datetime] NULL,
	[CustId] [INT] NOT NULL,
	[CustomerPhone] [varchar](100) NULL,
	[TotalEstimatePrice] [Decimal](19, 6) NOT NULL,
	[TotalEstimateTime] [Decimal](19, 6) NOT NULL,
	[StaffRequire] [Decimal](19, 6) NOT NULL,
	[Status] [varchar](100) NULL,
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zBookingMaster] ADD  CONSTRAINT [DF_zBookingMaster_TotalEstimatePrice]  DEFAULT ((0)) FOR [TotalEstimatePrice]
GO

ALTER TABLE [dbo].[zBookingMaster] ADD  CONSTRAINT [DF_zBookingMaster_TotalEstimateTime]  DEFAULT ((0)) FOR [TotalEstimateTime]
GO

ALTER TABLE [dbo].[zBookingMaster] ADD  CONSTRAINT [DF_zBookingMaster_StaffRequire]  DEFAULT ((0)) FOR [StaffRequire]
GO

