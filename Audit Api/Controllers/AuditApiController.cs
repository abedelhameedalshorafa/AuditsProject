using Audit_Api.Context;
using Audit_Api.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Audit_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditApiController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public AuditApiController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Audit>>> GetAudits()
        {
            return await _context.Audits.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Audit>> GetAudit(int id)
        {
            var audit = await _context.Audits.FirstOrDefaultAsync(a => a.Id == id);
            if (audit == null)
            {
                return NotFound();
            }
            return audit;
        }


        [HttpPost]
        public async Task<ActionResult<Audit>> PostAudit(Audit audit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }
            var Audit = new Audit
            {
                Action = "Create",
                EmployeeID = audit.EmployeeID, // This should be an already existing ID
                UserID = audit.UserID,         // This should be an already existing ID
                Timestamp = DateTime.Now
            };

            _context.Audits.Add(Audit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Audit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAudit(int id, Audit audit)
        {
            if (id != audit.Id)
            {
                return BadRequest();
            }

            _context.Entry(audit).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudit(int id)
        {
            var audit = await _context.Audits.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }

            audit.Action = "Delete";
            //_context.Audits.Remove(audit);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        ////////////Users///////////

        [HttpGet("Users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        ////////////Employees///////////


        [HttpGet("Employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("employees/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
    }
}
