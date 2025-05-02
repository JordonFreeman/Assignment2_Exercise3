using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderManagement.RazorWeb.Data;
using OrderManagement.RazorWeb.Models;

namespace OrderManagement.RazorWeb.Pages.Agents
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Check if user is authenticated
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }

        [BindProperty]
        public Agent Agent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Agents.Add(Agent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}