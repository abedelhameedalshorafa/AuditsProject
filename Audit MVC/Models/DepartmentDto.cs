namespace Audit_MVC.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; }
    }
}
