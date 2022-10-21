namespace EmployeeManagement.Data
{
    public class EmployeeCreateModel
    {

        public String FirstName { get; set; } = null!;
        public String LastName { get; set; } = null!;
        public String Gender { get; set; } = null!;
        public String Email { get; set; } = null!;
        public String Phone { get; set; } = null!;
        public String? DateCreated { get; set; }
        public String? DateModified { get; set; }
        public int CompanyId { get; set; }
    }
}
