CREATE TABLE Cars (
    CarID int IDENTITY(1,1) PRIMARY KEY,
    Brand int,
    Model nvarchar(50),
    Price Int,
	[In Stock] nchar(10)
);