USE [HomeTask]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 05.05.2021 20:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[User_id] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client_Sale]    Script Date: 05.05.2021 20:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client_Sale](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[id_sale] [int] NOT NULL,
 CONSTRAINT [PK_Client_Sale] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC,
	[id_sale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 05.05.2021 20:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [money] NULL,
	[Kol-vo] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 05.05.2021 20:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Sale_Item] [nvarchar](50) NULL,
	[id_client] [int] NOT NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sale_item]    Script Date: 05.05.2021 20:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale_item](
	[id_sale] [int] NOT NULL,
	[id_item] [int] NOT NULL,
 CONSTRAINT [PK_sale_item] PRIMARY KEY CLUSTERED 
(
	[id_sale] ASC,
	[id_item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05.05.2021 20:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([id], [Name], [Price], [Kol-vo]) VALUES (1, N'Tea', 1337.0000, 2)
INSERT [dbo].[Item] ([id], [Name], [Price], [Kol-vo]) VALUES (2, N'Chocolate', 42069.0000, 15)
INSERT [dbo].[Item] ([id], [Name], [Price], [Kol-vo]) VALUES (3, N'Apple', 1488.0000, NULL)
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [FirstName], [LastName], [Login], [Password]) VALUES (1, N'Путин ', N'Владимир', N'123', N'123')
INSERT [dbo].[Users] ([id], [FirstName], [LastName], [Login], [Password]) VALUES (2, N'Илеев', N'Данил', N'111', N'111')
INSERT [dbo].[Users] ([id], [FirstName], [LastName], [Login], [Password]) VALUES (3, N'Баранова', N'Анастасия', N'222', N'222')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Users]
GO
ALTER TABLE [dbo].[Client_Sale]  WITH CHECK ADD  CONSTRAINT [FK_Client_Sale_Client] FOREIGN KEY([id_client])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[Client_Sale] CHECK CONSTRAINT [FK_Client_Sale_Client]
GO
ALTER TABLE [dbo].[Client_Sale]  WITH CHECK ADD  CONSTRAINT [FK_Client_Sale_Sale] FOREIGN KEY([id_sale])
REFERENCES [dbo].[Sale] ([id])
GO
ALTER TABLE [dbo].[Client_Sale] CHECK CONSTRAINT [FK_Client_Sale_Sale]
GO
ALTER TABLE [dbo].[sale_item]  WITH CHECK ADD  CONSTRAINT [FK_sale_item_Item] FOREIGN KEY([id_item])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[sale_item] CHECK CONSTRAINT [FK_sale_item_Item]
GO
ALTER TABLE [dbo].[sale_item]  WITH CHECK ADD  CONSTRAINT [FK_sale_item_Sale] FOREIGN KEY([id_sale])
REFERENCES [dbo].[Sale] ([id])
GO
ALTER TABLE [dbo].[sale_item] CHECK CONSTRAINT [FK_sale_item_Sale]
GO
