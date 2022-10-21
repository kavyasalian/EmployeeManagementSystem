namespace EmployeeManagement.Data
{
    public class UserUpdateModel
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public string UserPhone { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public int RoleId { get; set; }


    }
}
