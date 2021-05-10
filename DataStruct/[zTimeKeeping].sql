USE [THANH]
GO

/****** Object:  Table [dbo].[tblAUS_Service]    Script Date: 09/05/2021 5:30:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zTimeKeeping](
	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[StaffId] [INT] NOT NULL,
	[branchId] [INT] NOT NULL,
	[Year] [INT] NOT NULL,
	[Month] [INT] NOT NULL,
	[Check] [INT] NOT NULL,
	[Day1] [varchar](10) NULL,
	[Day2] [varchar](10) NULL,
	[Day3] [varchar](10) NULL,
	[Day4] [varchar](10) NULL,
	[Day5] [varchar](10) NULL,
	[Day6] [varchar](10) NULL,
	[Day7] [varchar](10) NULL,
	[Day8] [varchar](10) NULL,
	[Day9] [varchar](10) NULL,
	[Day10] [varchar](10) NULL,
	[Day11] [varchar](10) NULL,
	[Day12] [varchar](10) NULL,
	[Day13] [varchar](10) NULL,
	[Day14] [varchar](10) NULL,
	[Day15] [varchar](10) NULL,
	[Day16] [varchar](10) NULL,
	[Day17] [varchar](10) NULL,
	[Day18] [varchar](10) NULL,
	[Day19] [varchar](10) NULL,
	[Day20] [varchar](10) NULL,
	[Day21] [varchar](10) NULL,
	[Day22] [varchar](10) NULL,
	[Day23] [varchar](10) NULL,
	[Day24] [varchar](10) NULL,
	[Day25] [varchar](10) NULL,
	[Day26] [varchar](10) NULL,
	[Day27] [varchar](10) NULL,
	[Day28] [varchar](10) NULL,
	[Day29] [varchar](10) NULL,
	[Day30] [varchar](10) NULL,
	[Day31] [varchar](10) NULL,
	[Total] [Decimal](19, 4) NOT NULL,
	[PayRoll] [Decimal](19, 4) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zTimeKeeping] ADD  CONSTRAINT [DF_zTimeKeeping_Total]  DEFAULT ((0)) FOR [Total]
GO

ALTER TABLE [dbo].[zTimeKeeping] ADD  CONSTRAINT [DF_zTimeKeeping_PayRoll]  DEFAULT ((0)) FOR [PayRoll]
GO


