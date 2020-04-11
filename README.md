# BookReadingEvent
It is a book Reading Event Management.
To use this
Create database named EventDB
create three table named as 
Event , Registration , RoleUser

****************
Event table

USE [EventDB]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 11-04-2020 11:19:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Event](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[EventDate] [date] NOT NULL,
	[EventLocation] [nvarchar](50) NOT NULL,
	[StartTime] [nvarchar](50) NOT NULL,
	[EventType] [nvarchar](50) NOT NULL,
	[Duration] [int] NOT NULL,
	[EventDescription] [nvarchar](50) NOT NULL,
	[OtherDetails] [nvarchar](200) NULL,
	[Invite] [nvarchar](50) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Registration] FOREIGN KEY([UserId])
REFERENCES [dbo].[Registration] ([UserId])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Registration]
GO

********************

Registration table
USE [EventDB]
GO

/****** Object:  Table [dbo].[Registration]    Script Date: 11-04-2020 11:20:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Registration](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

*************************
RoleUser

USE [EventDB]
GO

/****** Object:  Table [dbo].[RoleUser]    Script Date: 11-04-2020 11:21:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RoleUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleUser_Registration] FOREIGN KEY([UserId])
REFERENCES [dbo].[Registration] ([UserId])
GO

ALTER TABLE [dbo].[RoleUser] CHECK CONSTRAINT [FK_RoleUser_Registration]
GO

**************************

Now create procedure for opertion

spAddEvent  Procedure

USE [EventDB]
GO

/****** Object:  StoredProcedure [dbo].[spAddEvent]    Script Date: 11-04-2020 11:23:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE procedure [dbo].[spAddEvent]  
@Title nvarchar(50),  
@Date date,
@Location nvarchar(50),
@Starttime nvarchar(50),
@Type nvarchar(50),
@Duration int,
@Description nvarchar(50),
@Otherdetails nvarchar(200)=NULL,
@Invite nvarchar(50)=NULL,
@UserId int
as  
Begin  
 Insert into Event (Title,EventDate,EventLocation,StartTime,EventType,Duration,EventDescription,OtherDetails,Invite,UserId)  
 Values (@Title,  
@Date,
@Location,
@Starttime,
@Type,
@Duration,
@Description,
@Otherdetails,
@Invite,
@UserId)  
End
GO

**********************************

spAddRole Procedure

USE [EventDB]
GO

/****** Object:  StoredProcedure [dbo].[spAddRole]    Script Date: 11-04-2020 11:24:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 Create procedure [dbo].[spAddRole]  
@UserId int,  
@Name nvarchar(50)
as  
Begin  
 Insert into RoleUser(UserId,RoleName)  
 Values (@UserId,@Name 
)  
End
GO


***********************************

spAddUser  procedure
USE [EventDB]
GO

/****** Object:  StoredProcedure [dbo].[spAddUser]    Script Date: 11-04-2020 11:25:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE procedure [dbo].[spAddUser]  
@Name nvarchar(50),  
@Email nvarchar(50),
@Password nvarchar(50)
as  
Begin  
 Insert into Registration(Name,Email,Password)  
 Values (@Name,  
@Email,
@Password)  
End
GO

********************************

spUpdateEvent  procedure

USE [EventDB]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateEvent]    Script Date: 11-04-2020 11:25:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 Create procedure [dbo].[spUpdateEvent] 
 @id int,
@Title nvarchar(50),  
@Date date,
@Location nvarchar(50),
@Starttime nvarchar(50),
@Type nvarchar(50),
@Duration int,
@Description nvarchar(50),
@Otherdetails nvarchar(200)=NULL,
@Invite nvarchar(50)=NULL 
as  
Begin  
 Update Event set Title=@Title, EventDate=@Date, EventLocation=@Location , StartTime=@Starttime , EventType=@Type,
 Duration=@Duration , EventDescription=@Description , OtherDetails=@Otherdetails , Invite=@Invite
 where Id=@id

End
GO

**************************************
spUpdateUser  procedure

USE [EventDB]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateUser]    Script Date: 11-04-2020 11:26:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 create procedure [dbo].[spUpdateUser] 
 @UserId int,
@Name nvarchar(50),  
@Email nvarchar(50),
@Password nvarchar(50)
as  
Begin  
 Update Registration set Name=@Name,  Email=@Email , Password=@Password
 where UserId=@UserId

End
GO








