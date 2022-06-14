namespace EmployeeManagement.Data
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public String CompanyName { get; set; } = null!;
        public String CompanyAddress { get; set; } = null!;
        public String CompanyPhone { get; set; } = null!;
    }
}
