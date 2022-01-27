CREATE TABLE [chat].[Messages]
(
	[MessageId] INT NOT NULL,
	[SenderUserId] INT NOT NULL,
	[ConversationId] INT NOT NULL,
	[MessageContent] NVARCHAR(MAX),
	[TimestampCreated] DATETIME2,

	CONSTRAINT message_pk PRIMARY KEY ([MessageId]),
	CONSTRAINT user_fk FOREIGN KEY ([SenderUserId]) REFERENCES dbo.Users([UserId]),
	CONSTRAINT convarsation_fk FOREIGN KEY ([ConversationId]) REFERENCES chat.Conversations([Id])
)
