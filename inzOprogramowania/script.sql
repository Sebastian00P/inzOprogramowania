Build started...
Build succeeded.
The Entity Framework tools version '6.0.1' is older than that of the runtime '7.0.5'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [UserId] bigint NOT NULL IDENTITY,
    [UserName] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Role] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230412165324_userTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Ads] (
    [AdId] bigint NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Image] varbinary(max) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [ExpiredTime] datetime2 NOT NULL,
    [UserId] bigint NOT NULL,
    CONSTRAINT [PK_Ads] PRIMARY KEY ([AdId]),
    CONSTRAINT [FK_Ads_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Comments] (
    [CommentId] bigint NOT NULL IDENTITY,
    [Content] nvarchar(max) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [AdsAdId] bigint NOT NULL,
    [AdId] bigint NOT NULL,
    [UserId] bigint NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentId]),
    CONSTRAINT [FK_Comments_Ads_AdsAdId] FOREIGN KEY ([AdsAdId]) REFERENCES [Ads] ([AdId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId])
);
GO

CREATE INDEX [IX_Ads_UserId] ON [Ads] ([UserId]);
GO

CREATE INDEX [IX_Comments_AdsAdId] ON [Comments] ([AdsAdId]);
GO

CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230413095649_UserCommentCascadeDelete', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [UserId] bigint NOT NULL IDENTITY,
    [UserName] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Role] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Ads] (
    [AdId] bigint NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Image] varbinary(max) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [ExpiredTime] datetime2 NOT NULL,
    [UserId] bigint NOT NULL,
    CONSTRAINT [PK_Ads] PRIMARY KEY ([AdId]),
    CONSTRAINT [FK_Ads_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Comments] (
    [CommentId] bigint NOT NULL IDENTITY,
    [Content] nvarchar(max) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [AdsAdId] bigint NULL,
    [AdId] bigint NOT NULL,
    [UserId] bigint NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentId]),
    CONSTRAINT [FK_Comments_Ads_AdsAdId] FOREIGN KEY ([AdsAdId]) REFERENCES [Ads] ([AdId]),
    CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId])
);
GO

CREATE INDEX [IX_Ads_UserId] ON [Ads] ([UserId]);
GO

CREATE INDEX [IX_Comments_AdsAdId] ON [Comments] ([AdsAdId]);
GO

CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230413102453_UserNullable', N'7.0.5');
GO

COMMIT;
GO


