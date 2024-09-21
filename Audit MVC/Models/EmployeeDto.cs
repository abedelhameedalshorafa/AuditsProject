using System.ComponentModel.DataAnnotations.Schema;

namespace Audit_MVC.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public int DepartmentID { get; set; }
        public DepartmentDto Department { get; set; }=new DepartmentDto();
        
    }
}
