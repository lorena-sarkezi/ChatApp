CREATE TABLE [chat].[Persons]
(
	[Id] INT NOT NULL IDENTITY,
	[gender_id] INT NULL,
	[first_name] NVARCHAR(64) NULL,
	[last_name] NVARCHAR(64) NULL,

	CONSTRAINT persons_pk PRIMARY KEY (id),
	CONSTRAINT gender_fk FOREIGN KEY (gender_id) REFERENCES [chat].[genders](id)

)
