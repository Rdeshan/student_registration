using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRegistration.Domain.Entities;
using System.Net.Http.Json;

namespace student_registration.Pages.Students;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public List<Student> students { get; set; } = new();

    public async Task OnGetAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("http://localhost:5224/api/Student/GetAll");

        if (response.IsSuccessStatusCode)
        {
            students = await response.Content.ReadFromJsonAsync<List<Student>>() ?? new List<Student>();
        }
        else
        {
            students = new List<Student>(); // empty if API fails
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5224/api/Student/{id}");

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, $"Failed to delete student id {id}");
            return Page();
        }

        return RedirectToPage();
    }

}
