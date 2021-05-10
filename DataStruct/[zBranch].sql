USE [THANH]
GO

/****** Object:  Table [dbo].[tblAUS_Service]    Script Date: 09/05/2021 5:30:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zBranch](
	[branchId] [INT] IDENTITY(1,1) NOT NULL,
	[BranchCode] [varchar](30) NOT NULL,
	[BranchName] [varchar](30) NOT NULL,
	[Located] [varchar](300) NULL,
	[PhoneNumber] [varchar](100) NULL,
	[Facebook] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[website] [varchar](100) NULL,
	[SMSText] [varchar](1000) NULL,
	[NumberBill] [Decimal](19, 6) NOT NULL,
	[Noontime] [Decimal](19, 6) NOT NULL,
	[Decriptions] [varchar](1000) NULL,
	[is_inactive] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zBranch] ADD  CONSTRAINT [DF_zBranch_NumberBill]  DEFAULT ((0)) FOR [NumberBill]
GO

ALTER TABLE [dbo].[zBranch] ADD  CONSTRAINT [DF_zBranch_Noontime]  DEFAULT ((0)) FOR [Noontime]
GO


