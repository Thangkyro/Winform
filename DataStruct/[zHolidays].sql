USE [THANH]
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zHolidays](
	[HolidaysID] [INT] IDENTITY(1,1) NOT NULL,
	[branchId] [INT] NOT NULL,
	[Names] [varchar](100) NULL,
	[HolidaysFrom] [datetime] NULL,
	[HolidaysTo] [datetime] NULL,
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO


