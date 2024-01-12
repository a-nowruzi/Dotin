namespace Common.DTOs
{
    public record UserDto
    {
        public int? UserID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MobileNumber { get; set; }
        public required string Email { get; set; }
    }
}
