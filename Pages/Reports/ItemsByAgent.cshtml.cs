using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Data;
using OrderManagement.RazorWeb.Models;

namespace OrderManagement.RazorWeb.Pages.Reports
{
    public class ItemsByAgentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ItemsByAgentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList Agents { get; set; }

        [BindProperty]
        public int? SelectedAgentID { get; set; }

        public Agent SelectedAgent { get; set; }

        public class ItemPurchaseSummary
        {
            public int ItemID { get; set; }
            public string ItemName { get; set; }
            public string Size { get; set; }
            public decimal UnitPrice { get; set; }
            public int TotalQuantity { get; set; }
            public decimal TotalAmount { get; set; }
        }

        public List<ItemPurchaseSummary> Items { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Check if user is authenticated
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToPage("/Login");
            }

            // Prepare agent dropdown
            Agents = new SelectList(await _context.Agents.ToListAsync(), "AgentID", "AgentName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Check if user is authenticated
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToPage("/Login");
            }

            // Prepare agent dropdown
            Agents = new SelectList(await _context.Agents.ToListAsync(), "AgentID", "AgentName", SelectedAgentID);

            if (SelectedAgentID.HasValue)
            {
                // Get selected agent
                SelectedAgent = await _context.Agents.FindAsync(SelectedAgentID.Value);

                if (SelectedAgent != null)
                {
                    // Get items purchased by this agent
                    Items = await _context.OrderDetails
                        .Include(od => od.Order)
                        .Include(od => od.Item)
                        .Where(od => od.Order.AgentID == SelectedAgentID.Value)
                        .GroupBy(od => new { od.ItemID, od.Item.ItemName, od.Item.Size, od.Item.UnitPrice })
                        .Select(g => new ItemPurchaseSummary
                        {
                            ItemID = g.Key.ItemID,
                            ItemName = g.Key.ItemName,
                            Size = g.Key.Size,
                            UnitPrice = g.Key.UnitPrice,
                            TotalQuantity = g.Sum(od => od.Quantity),
                            TotalAmount = g.Sum(od => od.TotalAmount)
                        })
                        .OrderByDescending(x => x.TotalQuantity)
                        .ToListAsync();
                }
            }

            return Page();
        }
    }
}