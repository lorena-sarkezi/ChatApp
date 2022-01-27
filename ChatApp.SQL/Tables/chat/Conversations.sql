CREATE TABLE [chat].[Conversations]
(
	[ConversationId] INT IDENTITY NOT NULL,
	[ConversationTypeId] INT NOT NULL, -- Group or Normal conversation
	[LatestMessageTimestamp] DATETIME2 NOT NULL DEFAULT(GETDATE()),
	[TimestampCreated] DATETIME2 NOT NULL,

	CONSTRAINT conversation_pk PRIMARY KEY ([ConversationId])
)
