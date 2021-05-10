USE [THANH]
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zStaffHistory](
	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[StaffId] [INT]  NOT NULL,
	[branchId] [INT], 
	[Date] [datetime]  NULL,
	[Salary]  [decimal](19,2) NOT NULL,
	[LayOff] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zStaffHistory] ADD  CONSTRAINT [DF_zStaffHistory_Salary]  DEFAULT ((0)) FOR [Salary]
GO
