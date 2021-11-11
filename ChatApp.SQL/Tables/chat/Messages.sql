CREATE TABLE [chat].[Messages]
(
	[MessageId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[MessageContent] NVARCHAR(MAX),
	[TimestampCreated] DATETIME2,

	CONSTRAINT message_pk PRIMARY KEY ([MessageId]),
	CONSTRAINT user_fk FOREIGN KEY ([UserId]) REFERENCES dbo.Users([UserId])
)
