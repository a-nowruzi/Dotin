using System.ComponentModel.DataAnnotations;

namespace Dotin.DAL.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(11)]
        [Phone]
        public string MobileNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = null!;
    }
}
