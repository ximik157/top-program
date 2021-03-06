USE [18ip17]
GO
/****** Object:  Table [dbo].[messages]    Script Date: 08.11.2021 14:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[messages](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[text] [nchar](1000) NOT NULL,
	[owner_id] [bigint] NOT NULL,
	[receiver_id] [bigint] NOT NULL,
	[attachment] [nchar](100) NULL,
 CONSTRAINT [PK_messages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 08.11.2021 14:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[login] [nchar](30) NOT NULL,
	[bio] [nchar](100) NULL,
	[password] [nchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_posts]    Script Date: 08.11.2021 14:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_posts](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[text] [nchar](1000) NOT NULL,
	[attachment] [nchar](100) NULL,
	[owner_id] [bigint] NOT NULL,
 CONSTRAINT [PK_user_posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_posts_like]    Script Date: 08.11.2021 14:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_posts_like](
	[user_id] [bigint] NOT NULL,
	[post_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_subscibers]    Script Date: 08.11.2021 14:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_subscibers](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[owner_id] [bigint] NOT NULL,
	[subscriber_id] [bigint] NOT NULL,
 CONSTRAINT [PK_user_subscibers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[messages]  WITH CHECK ADD  CONSTRAINT [FK_messages_user] FOREIGN KEY([owner_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[messages] CHECK CONSTRAINT [FK_messages_user]
GO
ALTER TABLE [dbo].[messages]  WITH CHECK ADD  CONSTRAINT [FK_messages_user1] FOREIGN KEY([receiver_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[messages] CHECK CONSTRAINT [FK_messages_user1]
GO
ALTER TABLE [dbo].[user_posts]  WITH CHECK ADD  CONSTRAINT [FK_user_posts_user] FOREIGN KEY([owner_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[user_posts] CHECK CONSTRAINT [FK_user_posts_user]
GO
ALTER TABLE [dbo].[user_posts_like]  WITH CHECK ADD  CONSTRAINT [FK_user_posts_like_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[user_posts_like] CHECK CONSTRAINT [FK_user_posts_like_user]
GO
ALTER TABLE [dbo].[user_posts_like]  WITH CHECK ADD  CONSTRAINT [FK_user_posts_like_user_posts] FOREIGN KEY([post_id])
REFERENCES [dbo].[user_posts] ([id])
GO
ALTER TABLE [dbo].[user_posts_like] CHECK CONSTRAINT [FK_user_posts_like_user_posts]
GO
ALTER TABLE [dbo].[user_subscibers]  WITH CHECK ADD  CONSTRAINT [FK_user_subscibers_user] FOREIGN KEY([owner_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[user_subscibers] CHECK CONSTRAINT [FK_user_subscibers_user]
GO
ALTER TABLE [dbo].[user_subscibers]  WITH CHECK ADD  CONSTRAINT [FK_user_subscibers_user1] FOREIGN KEY([subscriber_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[user_subscibers] CHECK CONSTRAINT [FK_user_subscibers_user1]
GO
