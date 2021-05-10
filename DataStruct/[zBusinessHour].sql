USE [THANH]
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zBusinessHour](
	[BusinessID] [INT] IDENTITY(1,1) NOT NULL,
	[branchId] [INT] NOT NULL,
	[DayOfWeek] [int],
	[BusinessFrom] [datetime] NULL,
	[BusinessTo] [datetime] NULL,
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO


