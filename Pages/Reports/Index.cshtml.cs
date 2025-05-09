using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderManagement.RazorWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagement.RazorWeb.Pages.Reports
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // This page just displays links to other reports
        }
    }
}