using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrderManagement.RazorWeb.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}