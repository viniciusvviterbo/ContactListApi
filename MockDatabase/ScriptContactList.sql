CREATE DATABASE ContactList;
-- GO

USE ContactList;
-- GO

CREATE TABLE dbo.Persons(
      Id int NOT NULL IDENTITY(1, 1),
      FirstName varchar(100) NOT NULL,
      LastName varchar(100),      
      CONSTRAINT PK_Persons PRIMARY KEY (Id)
);
-- GO

CREATE TABLE dbo.Contacts(
      Id int NOT NULL IDENTITY(1, 1),
      PersonId int NOT NULL,
      Type varchar(8) NOT NULL,
      Value varchar(100) NOT NULL,
      CONSTRAINT PK_Contacts PRIMARY KEY (Id),
      FOREIGN KEY (PersonId) REFERENCES Persons(Id)
);
-- GO

INSERT INTO dbo.Persons (FirstName ,LastName)
     VALUES ('John', 'Doe'),
            ('Jane', 'Doe'),
            ('Someone', 'Else Entirely');

INSERT INTO dbo.Contacts (PersonId, Type, Value)
     VALUES (1, 'Phone', '+55(00)3333-3333'),
            (1, 'Email', 'john@doe.com'),
            (1, 'Whatsapp', '+55(00)999-999-999'),
            (2, 'Phone', '+55(00)3333-3333'),
            (2, 'Email', 'jane@doe.com'),
            (2, 'Whatsapp', '+55(00)999-999-999'),
            (3, 'Phone', '+55(00)3333-3333'),
            (3, 'Email', 'someone@else.com'),
            (3, 'Whatsapp', '+55(00)999-999-999');
