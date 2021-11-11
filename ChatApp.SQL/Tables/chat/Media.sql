CREATE TABLE [chat].[Media]
(
	[MediaId] INT NOT NULL,
	[MessageId] INT NOT NULL,
	[AzureBlobId] INT NULL,
	[FilePath] NVARCHAR(256) NOT NULL,
	[TimestampCreated] DATETIME2 NOT NULL

	CONSTRAINT media_pk PRIMARY KEY ([MediaId]),
	CONSTRAINT message_fk FOREIGN KEY (MessageId) REFERENCES chat.Messages(MessageId)

)
