/****** Object:  Table [dbo].[zHolidays]    Script Date: 05/14/2021 12:33:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[zBanner](
	[BannerID] [int] IDENTITY(1,1) NOT NULL,
	[branchId] [int] NOT NULL,
	[BannerText] [nvarchar](max) NOT NULL,
	[NumberOrder] INT NOT NULL,
	[Decriptions] [varchar](2000) NOT NULL,
	[is_inactive] [bit] NULL,
	[created_by] [int] NULL,
	[created_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_at] [datetime] NULL,
 CONSTRAINT [PK_zBanner] PRIMARY KEY CLUSTERED 
(
	[BannerID] ASC,
	[branchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


