﻿CREATE TABLE [chat].[Conversations]
(
	[Id] INT IDENTITY NOT NULL,
	[ConversationTypeId] INT NOT NULL, -- Group or Normal conversation
	[LatestMessage] DATETIME2 NOT NULL DEFAULT(GETDATE()),
	[TimestampCreated] DATETIME2 NOT NULL,

	CONSTRAINT conversation_pk PRIMARY KEY ([Id])
)
