CREATE TABLE [dbo].[Persons]
(
	[Id] INT NOT NULL IDENTITY,
	[FirstName] NVARCHAR(64) NULL,
	[LastName] NVARCHAR(64) NULL,

	CONSTRAINT persons_pk PRIMARY KEY (id)
	--CONSTRAINT gender_fk FOREIGN KEY (GenderId) REFERENCES [dbo].[genders](id)

)
