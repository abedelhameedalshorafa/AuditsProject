using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Audit_Api.Models
{
    public class Audit
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
