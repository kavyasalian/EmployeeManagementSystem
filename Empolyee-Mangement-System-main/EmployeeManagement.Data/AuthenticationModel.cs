

namespace EmployeeManagement.Data
{
    public class AuthenticationModel
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Token { get; set; } = null!;

        public DateTime TokenExpiryDate { get; set; }

        public Guid RefreshToken { get; set; }
        public string Error { get; set; } = null!;
    }
}
