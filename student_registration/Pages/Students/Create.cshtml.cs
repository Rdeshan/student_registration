using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRegistration.Domain.Entities;
using System.Net.Http.Json;

namespace student_registration.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // BindProperty allows the form to fill this Student object
        [BindProperty]
        public Student Student { get; set; } = new();

   
        public void OnGet()
        {
        }

        // Handle form submission
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var client = _httpClientFactory.CreateClient();

              
                var response = await client.PostAsJsonAsync(
                    "http://localhost:5224/api/Student/Register",
                    Student
                );

                if (response.IsSuccessStatusCode)
                {
                   
                    return RedirectToPage("/Students/Index");
                }
                else
                {
                   
                    ModelState.AddModelError(string.Empty, "Failed to create student.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Page();
            }
        }
    }
}
