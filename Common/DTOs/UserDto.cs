namespace Common.DTOs
{
    public record UserDto(int? UserID,
                          string FirstName,
                          string LastName,
                          string MobileNumber,
                          string Email);
}
