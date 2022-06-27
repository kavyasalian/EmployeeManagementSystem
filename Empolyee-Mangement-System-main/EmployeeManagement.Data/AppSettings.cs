namespace EmployeeManagement.Data
{
    public class AppSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string Secret { get; set; } = null!;
        public TokenSettings TokenSettings { get; set; }
        public LoginSettings LoginSettings { get; set; }

    }
    public class TokenSettings
    {
        public int SessionExpiryInMinutes { get; set; }
        public int ShortExpiryInMinutes { get; set; }
        public int LongExpiryInMinutes { get; set; }
    }
    public class LoginSettings
    {
        public int MaxRetryCount { get; set; }

    }
}
