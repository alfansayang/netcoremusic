USE [dbmusic]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 14/04/2019 21:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [nvarchar](200) NOT NULL,
	[AlbumName] [nvarchar](200) NOT NULL,
	[ImageURL] [nvarchar](200) NULL,
	[ReleaseDate] [date] NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[SampleURL] [nvarchar](200) NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([ArtistID], [ArtistName], [AlbumName], [ImageURL], [ReleaseDate], [Price], [SampleURL]) VALUES (6, N'ari test alfan', N'asdas', N'https://d33wubrfki0l68.cloudfront.net/aea2faf51cc69a1e10bb434aa92f7c3821f16787/e4922/images/smashing-cat/singing-barista.svg', CAST(N'2019-04-04' AS Date), CAST(23423.00 AS Numeric(10, 2)), N'https://raw.githubusercontent.com/kolber/audiojs/master/mp3/bensound-dubstep.mp3')
INSERT [dbo].[Artists] ([ArtistID], [ArtistName], [AlbumName], [ImageURL], [ReleaseDate], [Price], [SampleURL]) VALUES (7, N'asd', N'asd', N'https://d33wubrfki0l68.cloudfront.net/aea2faf51cc69a1e10bb434aa92f7c3821f16787/e4922/images/smashing-cat/singing-barista.svg', CAST(N'2019-04-05' AS Date), CAST(2.00 AS Numeric(10, 2)), N'https://raw.githubusercontent.com/kolber/audiojs/master/mp3/bensound-dubstep.mp3')
INSERT [dbo].[Artists] ([ArtistID], [ArtistName], [AlbumName], [ImageURL], [ReleaseDate], [Price], [SampleURL]) VALUES (8, N'eqw', N'ew', N'https://d33wubrfki0l68.cloudfront.net/aea2faf51cc69a1e10bb434aa92f7c3821f16787/e4922/images/smashing-cat/singing-barista.svg', CAST(N'2019-04-05' AS Date), CAST(4.00 AS Numeric(10, 2)), N'https://raw.githubusercontent.com/kolber/audiojs/master/mp3/bensound-dubstep.mp3')
INSERT [dbo].[Artists] ([ArtistID], [ArtistName], [AlbumName], [ImageURL], [ReleaseDate], [Price], [SampleURL]) VALUES (10, N'acong', N'acong', N'https://d33wubrfki0l68.cloudfront.net/aea2faf51cc69a1e10bb434aa92f7c3821f16787/e4922/images/smashing-cat/singing-barista.svg', CAST(N'2019-04-05' AS Date), CAST(4324.00 AS Numeric(10, 2)), N'https://raw.githubusercontent.com/kolber/audiojs/master/mp3/bensound-dubstep.mp3')
SET IDENTITY_INSERT [dbo].[Artists] OFF
