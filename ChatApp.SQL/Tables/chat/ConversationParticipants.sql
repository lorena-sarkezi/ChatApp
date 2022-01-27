CREATE TABLE [chat].[ConversationParticipants]
(
	[UserId] INT NOT NULL,
	[ConversationId] INT NOT NULL,

	CONSTRAINT conversation_participants_pk PRIMARY KEY (UserId, ConversationId),

	CONSTRAINT participant_user_fk FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId),
	CONSTRAINT participant_conversation_fk FOREIGN KEY (ConversationId) REFERENCES chat.Conversations(ConversationId)

)
