# Dotin Hiring Test

Users crud project.

## Technologies

This project has been developed on Blazor web assembly, using .net 7


## Database

Create database tables using the query below.

```sql
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
```

## Architecture

This project follows clean architecture standards.

## License

[Dotin](https://dotin.ir/)
