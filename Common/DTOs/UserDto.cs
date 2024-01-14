using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public record UserDto
    {
        public int? UserID { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(11)]
        [Phone]
        public required string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }


        //public class UserValidator : AbstractValidator<UserDto>
        //{
        //    public UserValidator()
        //    {
        //        RuleFor(l => l.FirstName).NotNull().MinimumLength(2).MaximumLength(50);
        //        RuleFor(l => l.LastName).NotNull().MinimumLength(2).MaximumLength(50);
        //        RuleFor(l => l.MobileNumber).NotNull().MinimumLength(11).MaximumLength(11);
        //        RuleFor(l => l.Email).NotNull().NotEmpty().EmailAddress();
        //    }
        //}
    }
}
