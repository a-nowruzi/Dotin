You can create DataBase using this query:

CREATE TABLE [dbo].[Users](
    [UserID] [int] IDENTITY(1,1) NOT NULL,
    [FirstName] [nvarchar](50) NOT NULL,
    [LastName] [nvarchar](50) NOT NULL,
    [MobileNumber] [nvarchar](11) NOT NULL,
    [Email] [nvarchar](100) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
    (
        [UserID] ASC
    )
)
