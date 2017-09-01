USE [XJBC]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 11/02/2016 19:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[ContentText] [text] NOT NULL,
	[ContentHtml] [text] NOT NULL,
 CONSTRAINT [PK__Articles__3214EC0703317E3D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON
INSERT [dbo].[Articles] ([Id], [Title], [ContentText], [ContentHtml]) VALUES (1, N'瞎JB扯 搭建完毕', N'项目：瞎JB扯时间：2016年11月2日', N'&lt;p&gt;项目：瞎JB扯&lt;/p&gt;&lt;p&gt;时间：2016年11月2日&lt;/p&gt;')
SET IDENTITY_INSERT [dbo].[Articles] OFF
/****** Object:  Table [dbo].[Users]    Script Date: 11/02/2016 19:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ChineseName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [Name], [Password], [ChineseName]) VALUES (1, N'admin', N'202cb962ac59075b964b07152d234b70', N'阿星Plus')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  StoredProcedure [dbo].[proc_GetArticles]    Script Date: 11/02/2016 19:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_GetArticles]
@currentIndex int,--当前页码
@pageSize int,--每页容量
@totalCount int output--总共数据
as
begin
set nocount on
select @totalCount=COUNT(0) from Articles

select * from 
(
select *,ROW_NUMBER() over(order by Id desc) as rowIndex from Articles
)as t
where rowIndex between (@currentIndex-1)*@pageSize+1 and @currentIndex*@pageSize
end
GO
