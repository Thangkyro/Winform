USE [qidjefjs_ausNail]
GO

/****** Object:  Table [dbo].[zConfig]    Script Date: 10/30/2021 10:55:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[zConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ConfigCode] [nvarchar](100) NOT NULL,
	[ConfigName] [nvarchar](250) NOT NULL,
	[Value] [nvarchar](200) NOT NULL,
	[Decriptions] [varchar](2000) NULL,
	[is_inactive] [bit] NULL,
	[created_by] [int] NULL,
	[created_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[ValuesForm] [varchar](50) NULL,
 CONSTRAINT [PK_zConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[zConfig] ADD  DEFAULT ('0') FOR [ValuesForm]
GO


