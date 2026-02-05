using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRegistration.Domain.Entities;

namespace student_registration.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Student Student { get; set; } = new();

     
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"http://localhost:5224/api/Student/GetStudent/{id}");

            if (response.IsSuccessStatusCode)
            {
                Student = await response.Content.ReadFromJsonAsync<Student>();

              
                return Page();
            }
            return RedirectToPage("/Students/Index");
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }
            */

            var client = _httpClientFactory.CreateClient();

            
            var response = await client.PutAsJsonAsync(
                $"http://localhost:5224/api/Student/UpdateStudent/{id}",
                this.Student
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "User updated successfully";
                return RedirectToPage("/Students/Index");
            }

            // If it fails, catch the error message for debugging
            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, $"Server error: {error}");
            return Page();
        }
    }
}
