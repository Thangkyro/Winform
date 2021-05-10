USE [THANH]
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zCustomer](
	[CustId] [INT] IDENTITY(1,1) NOT NULL,
	[branchId] [INT] NOT NULL,
	[CustomerCode]  [varchar](30) NOT NULL,
	[Name]  [varchar](50) NULL,
	[Gender]  [varchar](10) NULL,
	[PhoneNumber1]  [varchar](100) NULL,
	[PhoneSimple1]  [varchar](100) NULL,
	[PhoneNumber2]  [varchar](100) NULL,
	[PhoneSimple2]  [varchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[PostCode] [varchar](50) NULL,
	[IsMerge] [bit],
	[CustIdMerge] [int],
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

