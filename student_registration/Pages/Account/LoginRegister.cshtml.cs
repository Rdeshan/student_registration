using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRegistration.Domain.Entities;
using System.Net.Http;

namespace student_registration.Pages.Account
{
    public class LoginRegisterModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginRegisterModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty(SupportsGet =true)]
        public bool IsLogIn { get; set; } = false;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var client = _httpClientFactory.CreateClient();

                if (IsLogIn)
                {
                    var response = await client.PostAsJsonAsync(
                        "http://localhost:5224/api/Auth/Login", User);

                    if (response.IsSuccessStatusCode)
                    {
                        return Redirect("/Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid email or password");
                        return Page();
                    }
                }
                else
                {
                    var response = await client.PostAsJsonAsync(
                        "http://localhost:5224/api/Auth/Create",
                        User);

                    if(response.IsSuccessStatusCode)
                    {
                        return RedirectToPage("/Account/LoginRegister", new { IsLogIn = true });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid email or password");
                        return Page();
                    }
                    

                }


            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
             

        }
    }
}
