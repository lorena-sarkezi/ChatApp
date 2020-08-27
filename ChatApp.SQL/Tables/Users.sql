CREATE TABLE [chat].[Users]
(
	[ID] INT NOT NULL IDENTITY,
	[role_id] INT NULL,
	[person_id] INT NOT NULL,
	[username] NVARCHAR(64) NOT NULL,
	[password] NVARCHAR(64) NOT NULL,
	[password_salt] NVARCHAR(64) NOT NULL,
	[timestamp_created] DATETIME2(3) NOT NULL,
	[timestamp_modified] DATETIME2(3) NULL,

	CONSTRAINT users_pk PRIMARY KEY (id),
	CONSTRAINT roles_fk FOREIGN KEY (role_id) REFERENCES [chat].[roles](id),
	CONSTRAINT persons_fk FOREIGN KEY (person_id) REFERENCES [chat].[persons](id)
)
