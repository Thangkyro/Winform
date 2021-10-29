

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
 CONSTRAINT [PK_zConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

--insert into [zConfig](ConfigCode, ConfigName, Value)
--values('TimeZoneUse','Time Zone Use','14')

--select * from [zConfig] 
--update [zConfig] set value = '0'