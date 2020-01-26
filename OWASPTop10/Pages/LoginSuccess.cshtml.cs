using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OWASPTop10.Pages
{
    public class LoginSuccessModel : PageModel
    {
        public string Username { get; set; }

        public void OnGet(string username)
        {
            Username = username;
        }
    }
}