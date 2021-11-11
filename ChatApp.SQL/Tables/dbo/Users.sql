CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL IDENTITY,
	[RoleId] INT NULL,
	[PersonId] INT NOT NULL,
	[Username] NVARCHAR(64) NOT NULL,
	[Password] NVARCHAR(64) NOT NULL,
	[PasswordSalt] NVARCHAR(64) NOT NULL,
	[TimestampCreated] DATETIME2(3) NOT NULL,
	[TimestampModified] DATETIME2(3) NULL,

	CONSTRAINT users_pk PRIMARY KEY (UserId),
	CONSTRAINT roles_fk FOREIGN KEY (RoleId) REFERENCES [dbo].[roles](id),
	CONSTRAINT persons_fk FOREIGN KEY (PersonId) REFERENCES [dbo].[persons](id)
)
