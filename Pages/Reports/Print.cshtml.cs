using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Data;
using OrderManagement.RazorWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagement.RazorWeb.Pages.Reports
{
    [Authorize]
    public class PrintModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PrintModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order = await _context.Orders
                .Include(o => o.Agent)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (Order == null)
            {
                return NotFound();
            }

            OrderDetails = await _context.OrderDetails
                .Include(od => od.Item)
                .Where(od => od.OrderID == id)
                .ToListAsync();

            return Page();
        }
    }
}