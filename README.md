# url-shortner

DB commands
dotnet ef migrations add InitialCreate
dotnet ef database update


drop table [dbo].[Urls]

CREATE TABLE [Urls] (
          [UrlId] varchar(8000) NOT NULL,
          [UserId] int NOT NULL,
          [OriginalUrl] varchar(8000) NOT NULL,
          [ShortenedUrl] varchar(4000) NOT NULL,
          CONSTRAINT [PK_Urls] PRIMARY KEY ([UrlId])
      );