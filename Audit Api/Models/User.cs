namespace Audit_Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Audit>? Audits { get; set; } 
    }
}
