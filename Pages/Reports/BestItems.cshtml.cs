using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Data;
using OrderManagement.RazorWeb.Models;

namespace OrderManagement.RazorWeb.Pages.Reports
{
    public class BestItemsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BestItemsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public class BestItemViewModel
        {
            public Item Item { get; set; }
            public int TotalQuantity { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        public List<BestItemViewModel> BestItems { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Check if user is authenticated
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToPage("/Login");
            }

            // Get best selling items
            BestItems = await _context.OrderDetails
                .GroupBy(od => od.ItemID)
                .Select(g => new BestItemViewModel
                {
                    Item = g.First().Item,
                    TotalQuantity = g.Sum(od => od.Quantity),
                    TotalRevenue = g.Sum(od => od.TotalAmount)
                })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(10)
                .ToListAsync();

            return Page();
        }
    }
}