CREATE TABLE [chat].[Persons]
(
	[Id] INT NOT NULL IDENTITY,
	[GenderId] INT NULL,
	[FirstName] NVARCHAR(64) NULL,
	[LastName] NVARCHAR(64) NULL,

	CONSTRAINT persons_pk PRIMARY KEY (id),
	CONSTRAINT gender_fk FOREIGN KEY (GenderId) REFERENCES [chat].[genders](id)

)
