USE [mtv-api]
GO
ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_Book_Auther]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 6/23/2020 4:04:15 PM ******/
DROP TABLE [dbo].[Books]
GO
/****** Object:  Table [dbo].[Auther]    Script Date: 6/23/2020 4:04:15 PM ******/
DROP TABLE [dbo].[Auther]
GO
/****** Object:  Table [dbo].[Auther]    Script Date: 6/23/2020 4:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auther](
	[AutherID] [bigint] IDENTITY(1,1) NOT NULL,
	[AutherName] [nvarchar](50) NOT NULL,
	[test] [nvarchar](50) NULL,
 CONSTRAINT [PK_Auther] PRIMARY KEY CLUSTERED 
(
	[AutherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 6/23/2020 4:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](max) NOT NULL,
	[Descrption] [nvarchar](max) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[AutherID] [bigint] NOT NULL,
	[TagID] [bigint] NOT NULL,
	[test] [nchar](10) NULL,
	[AddNew] [nvarchar](max) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Auther] ON 

INSERT [dbo].[Auther] ([AutherID], [AutherName], [test]) VALUES (1, N'Aut1', NULL)
INSERT [dbo].[Auther] ([AutherID], [AutherName], [test]) VALUES (2, N'Aut2', NULL)
INSERT [dbo].[Auther] ([AutherID], [AutherName], [test]) VALUES (3, N'Aut3', NULL)
INSERT [dbo].[Auther] ([AutherID], [AutherName], [test]) VALUES (4, N'hoa', NULL)
INSERT [dbo].[Auther] ([AutherID], [AutherName], [test]) VALUES (5, N'hoa', NULL)
INSERT [dbo].[Auther] ([AutherID], [AutherName], [test]) VALUES (6, N'hoa', NULL)
INSERT [dbo].[Auther] ([AutherID], [AutherName], [test]) VALUES (7, N'hoa', NULL)
SET IDENTITY_INSERT [dbo].[Auther] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookID], [BookName], [Descrption], [Price], [AutherID], [TagID], [test], [AddNew]) VALUES (1, N'book1', N'bool1', CAST(2.00 AS Decimal(10, 2)), 1, 1, N'hoa       ', N'3')
INSERT [dbo].[Books] ([BookID], [BookName], [Descrption], [Price], [AutherID], [TagID], [test], [AddNew]) VALUES (3, N'book2', N'bool2', CAST(3.00 AS Decimal(10, 2)), 1, 1, N'hoa       ', N'4')
SET IDENTITY_INSERT [dbo].[Books] OFF
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Book_Auther] FOREIGN KEY([AutherID])
REFERENCES [dbo].[Auther] ([AutherID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Book_Auther]
GO
