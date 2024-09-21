using System.ComponentModel.DataAnnotations.Schema;

namespace Audit_Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department? Department { get; set; } 
        public virtual ICollection<Audit>? Audits { get; set; }
    }
}
