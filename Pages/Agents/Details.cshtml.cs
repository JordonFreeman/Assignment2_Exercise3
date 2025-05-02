using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Data;
using OrderManagement.RazorWeb.Models;

namespace OrderManagement.RazorWeb.Pages.Agents
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Agent Agent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Check if user is authenticated
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToPage("/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            Agent = await _context.Agents.FirstOrDefaultAsync(m => m.AgentID == id);

            if (Agent == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}