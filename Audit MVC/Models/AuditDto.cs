namespace Audit_MVC.Models
{
    public class AuditDto
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int EmployeeID { get; set; }

        public EmployeeDto Employee { get; set; }
        public int UserID { get; set; }

        public UserDto User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
