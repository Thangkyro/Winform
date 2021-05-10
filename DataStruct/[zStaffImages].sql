USE [THANH]
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zStaffImages](
	[StaffId] [INT]  NOT NULL PRIMARY KEY,
	[Image] [image]  NULL,
	[Image_small]  [binary] NULL,
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

