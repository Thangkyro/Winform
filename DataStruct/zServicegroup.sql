USE [qidjefjs_ausNail]
GO

/****** Object:  Table [dbo].[zService]    Script Date: 12/6/2021 9:57:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[zServicegroup](
	[ServiceGroupID] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NOT NULL,
	[ServiceGroupName] [varchar](300) NOT NULL,
	[GroupStt] [int] NOT NULL,
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit] NULL,
	[created_by] [int] NULL,
	[created_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_at] [datetime] NULL,
 CONSTRAINT [PK_zServicegroup] PRIMARY KEY CLUSTERED 
(
	[ServiceGroupID] ASC,
	[branchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[zServicegroup] ADD  CONSTRAINT [DF__zServicegroup__Decrip__05A3D694]  DEFAULT ('') FOR [Decriptions]
GO

ALTER TABLE [dbo].[zServicegroup] ADD  CONSTRAINT [DF__zServicegroup__is_ina__0697FACD]  DEFAULT ((0)) FOR [is_inactive]
GO

ALTER TABLE [dbo].[zServicegroup] ADD  CONSTRAINT [DF__zServicegroup__create__078C1F06]  DEFAULT ((0)) FOR [created_by]
GO

ALTER TABLE [dbo].[zServicegroup] ADD  CONSTRAINT [DF__zServicegroup__create__0880433F]  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[zServicegroup] ADD  CONSTRAINT [DF__zServicegroup__modifi__09746778]  DEFAULT ((0)) FOR [modified_by]
GO

ALTER TABLE [dbo].[zServicegroup] ADD  CONSTRAINT [DF__zServicegroup__modifi__0A688BB1]  DEFAULT (getdate()) FOR [modified_at]
GO

ALTER TABLE [dbo].[zServicegroup] ADD  CONSTRAINT [DF__zServicegroup__modifi__0A699BC1]  DEFAULT ((0))  FOR [GroupStt]
GO


