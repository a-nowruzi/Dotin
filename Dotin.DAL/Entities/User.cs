using System.ComponentModel.DataAnnotations;

namespace Dotin.DAL.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
