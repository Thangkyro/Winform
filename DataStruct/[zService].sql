
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zService](
	[ServiceID] [INT] IDENTITY(1,1) NOT NULL,
	[branchId] [INT] NOT NULL,
	[Title]  [varchar](300) NULL,
	[Price] [decimal](19,6) NOT NULL,
	[EstimateTime] [decimal](19,6) NULL,
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit],
	[created_by] [int],
	[created_at] [datetime],
	[modified_by] [int],
	[modified_at] [datetime]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zService] ADD  CONSTRAINT [DF_zService_Price]  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE dbo.[zService] ADD GroupStt INT NOT NULL DEFAULT 0
GO