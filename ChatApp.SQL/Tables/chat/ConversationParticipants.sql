CREATE TABLE [chat].[ConversationParticipants]
(
	[UserId] INT NOT NULL,
	[ConversationId] INT NOT NULL,

	CONSTRAINT conversation_participants_pk PRIMARY KEY (UserId, ConversationId)
)
