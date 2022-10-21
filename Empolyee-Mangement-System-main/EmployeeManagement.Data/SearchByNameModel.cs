namespace EmployeeManagement.Data
{
    public class SearchByNameModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string companyName { get; set; } = null!;
        public string companyAddress { get; set; } = null!;

    }
}
