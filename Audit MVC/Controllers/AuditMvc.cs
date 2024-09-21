using Audit_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Audit_MVC.Controllers
{
    public class AuditMvc : Controller
    {
        private readonly HttpClient _httpClient;

        public AuditMvc(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        ////////////////// Get ////////////////////////
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7018/api/auditapi");
            if (response.IsSuccessStatusCode)
            {
                var audits = await response.Content.ReadFromJsonAsync<IEnumerable<AuditDto>>();
                return View(audits);
            }

            return View(new List<AuditDto>());
        }

        // GET: AuditMvc/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7018/api/auditapi/{id}");
            if (response.IsSuccessStatusCode)
            {
                var audit = await response.Content.ReadFromJsonAsync<AuditDto>();
                return View(audit);
            }

            return NotFound(); // If not found, return a 404 view
        }



        ////////////////// Post ////////////////////////


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var response1 = await _httpClient.GetAsync("https://localhost:7018/api/auditapi/Users");
            if (response1.IsSuccessStatusCode)
            {
                var users = await response1.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
                ViewBag.Users = users;
            }
            var response2 = await _httpClient.GetAsync("https://localhost:7018/api/auditapi/Employees");
            if (response2.IsSuccessStatusCode)
            {
                var Employees = await response2.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
                ViewBag.Employees = Employees;
            }

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuditDto audit)
        {
            audit.Action = "Create";
            audit.Timestamp = DateTime.Now;
            var response1 = await _httpClient.GetAsync($"https://localhost:7018/api/auditapi/Users/{audit.UserID}");
            if (response1.IsSuccessStatusCode)
            {
                var user = await response1.Content.ReadFromJsonAsync<UserDto>();
                audit.User = user;
            }
            var response2 = await _httpClient.GetAsync($"https://localhost:7018/api/auditapi/Employees/{audit.EmployeeID}");
            if (response2.IsSuccessStatusCode)
            {
                var employee = await response2.Content.ReadFromJsonAsync<EmployeeDto>();
                audit.Employee = employee;
            }
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7018/api/auditapi", audit);
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Audit Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                // Log the response details
                var errorContent = await response.Content.ReadAsStringAsync();
                // Display the error for debugging
                ModelState.AddModelError(string.Empty, $"API Error: {response.StatusCode} - {errorContent}");
            }

            return View(audit);
        }


        ////////////////// Put ////////////////////////


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response1 = await _httpClient.GetAsync("https://localhost:7018/api/auditapi/Users");
            if (response1.IsSuccessStatusCode)
            {
                var users = await response1.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
                ViewBag.Users = users;
            }
            var response2 = await _httpClient.GetAsync("https://localhost:7018/api/auditapi/Employees");
            if (response2.IsSuccessStatusCode)
            {
                var Employees = await response2.Content.ReadFromJsonAsync<IEnumerable<EmployeeDto>>();
                ViewBag.Employees = Employees;
            }

            var response = await _httpClient.GetAsync($"https://localhost:7018/api/auditapi/{id}");
            if (response.IsSuccessStatusCode)
            {
                var audit = await response.Content.ReadFromJsonAsync<AuditDto>();
                return View(audit);  // Return the current audit data in the edit form
            }

            return NotFound(); // If the audit is not found, show a 404 error page
        }

        // POST: AuditMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AuditDto audit)
        {
            if (id != audit.Id)
            {
                return BadRequest();  // Return an error if the ID doesn't match
            }

            audit.Action = "Update";
            audit.Timestamp = DateTime.Now;
            var response1 = await _httpClient.GetAsync($"https://localhost:7018/api/auditapi/Users/{audit.UserID}");
            if (response1.IsSuccessStatusCode)
            {
                var user = await response1.Content.ReadFromJsonAsync<UserDto>();
                audit.User = user;
            }
            var response2 = await _httpClient.GetAsync($"https://localhost:7018/api/auditapi/Employees/{audit.EmployeeID}");
            if (response2.IsSuccessStatusCode)
            {
                var employee = await response2.Content.ReadFromJsonAsync<EmployeeDto>();
                audit.Employee = employee;
            }
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7018/api/auditapi/{id}", audit);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                // Log or inspect the errorContent to understand the issue
            }
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Audit Updated Sccessfully";
                return RedirectToAction(nameof(Index)); // Redirect to the audit list if editing is successful
            }

            return View(audit);  // If validation or API call fails, return the same view with the model data
        }


        ////////////////// Delete ////////////////////////

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7018/api/auditapi/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Audit Deleted Sccessfully";
                return RedirectToAction(nameof(Index));
            }

            return View(); // If delete fails, show the delete view again
        }
    }
}
