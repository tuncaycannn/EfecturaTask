USE [efectura]
GO
/****** Object:  Table [dbo].[Tbl_Users]    Script Date: 9.04.2021 12:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Users](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Surname] [nvarchar](100) NULL,
	[Birthday] [date] NULL,
	[Address] [nvarchar](max) NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Tbl_Users] ([ID], [Name], [Surname], [Birthday], [Address], [UpdatedDate], [CreatedDate]) VALUES (N'20834681046', N'Osman', N'Can', CAST(N'1997-05-01' AS Date), N'Beşiktaş', CAST(N'2021-09-04T02:24:29.000' AS DateTime), CAST(N'2021-04-09T02:14:55.123' AS DateTime))
GO
ALTER TABLE [dbo].[Tbl_Users] ADD  CONSTRAINT [DF_Tbl_Users_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[Tbl_Users] ADD  CONSTRAINT [DF_Tbl_Users_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
