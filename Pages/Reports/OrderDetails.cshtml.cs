using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Data;
using OrderManagement.RazorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagement.RazorWeb.Pages.Reports
{
    [Authorize]
    public class OrderDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int? OrderID { get; set; }

        public SelectList OrdersList { get; set; }

        public Order Order { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public async Task OnGetAsync()
        {
            // Prepare orders dropdown
            await LoadOrders();

            // If an order is selected, get its details
            if (OrderID.HasValue)
            {
                Order = await _context.Orders
                    .Include(o => o.Agent)
                    .FirstOrDefaultAsync(o => o.OrderID == OrderID.Value);

                if (Order != null)
                {
                    OrderDetails = await _context.OrderDetails
                        .Include(od => od.Item)
                        .Where(od => od.OrderID == OrderID.Value)
                        .ToListAsync();
                }
            }
        }

        private async Task LoadOrders()
        {
            // Get orders for the dropdown
            var orders = await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new
                {
                    o.OrderID,
                    DisplayText = $"Order #{o.OrderID} - {o.OrderDate.ToString("MM/dd/yyyy")} - ${o.TotalAmount}"
                })
                .ToListAsync();

            OrdersList = new SelectList(orders, "OrderID", "DisplayText");
        }
    }
}