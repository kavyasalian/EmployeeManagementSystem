namespace EmployeeManagement.Data
{
    public class ProjectGetModel
    {
        public int ProjectId { get; set; }
        public String ProjectName { get; set; } = null!;
        public String ProjectDesc { get; set; } = null!;
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
    }
}
