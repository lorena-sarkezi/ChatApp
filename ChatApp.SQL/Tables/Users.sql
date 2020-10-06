CREATE TABLE [chat].[Users]
(
	[ID] INT NOT NULL IDENTITY,
	[RoleId] INT NULL,
	[PersonId] INT NOT NULL,
	[Username] NVARCHAR(64) NOT NULL,
	[Password] NVARCHAR(64) NOT NULL,
	[PasswordSalt] NVARCHAR(64) NOT NULL,
	[TimestampCreated] DATETIME2(3) NOT NULL,
	[TimestampModified] DATETIME2(3) NULL,

	CONSTRAINT users_pk PRIMARY KEY (id),
	CONSTRAINT roles_fk FOREIGN KEY (RoleId) REFERENCES [chat].[roles](id),
	CONSTRAINT persons_fk FOREIGN KEY (PersonId) REFERENCES [chat].[persons](id)
)
