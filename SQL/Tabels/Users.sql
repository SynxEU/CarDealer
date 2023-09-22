CREATE TABLE Users (
    Personid int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(50),
    LastName nvarchar(50),
    Balance Int,
	Type Int
);