CREATE TRIGGER [trg_AfterMessageInsert]
	ON [chat].[Messages]
	FOR INSERT
	AS
	BEGIN
		SET NOCOUNT ON

		UPDATE c
		SET c.LatestMessage = ins.TimestampCreated
		FROM chat.Conversations c
			INNER JOIN inserted ins on ins.ConversationId = c.Id

	END
