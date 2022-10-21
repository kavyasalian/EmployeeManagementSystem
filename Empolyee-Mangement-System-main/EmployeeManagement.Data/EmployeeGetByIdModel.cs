namespace EmployeeManagement.Data
{
    public class EmployeeGetByIdModel
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int CompanyId { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyName { get; set; }


    }
}
