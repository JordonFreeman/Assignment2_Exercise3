using System;
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

namespace OrderManagement.RazorWeb.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList AgentList { get; set; }
        public SelectList ItemList { get; set; }

        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public List<int> ItemIDs { get; set; }

        [BindProperty]
        public List<int> Quantities { get; set; }

        public IActionResult OnGet()
        {
            // Check if user is authenticated
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToPage("/Login");
            }

            // Initialize new order
            Order = new Order
            {
                OrderDate = DateTime.Now
            };

            // Prepare agent and item lists
            AgentList = new SelectList(_context.Agents, "AgentID", "AgentName");

            // For items, include price in the text
            var items = _context.Items.Select(i => new
            {
                i.ItemID,
                DisplayText = $"{i.ItemName}|{i.UnitPrice}"
            }).ToList();

            ItemList = new SelectList(items, "ItemID", "DisplayText");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Re-populate lists on validation failure
                AgentList = new SelectList(_context.Agents, "AgentID", "AgentName");
                var items = _context.Items.Select(i => new
                {
                    i.ItemID,
                    DisplayText = $"{i.ItemName}|{i.UnitPrice}"
                }).ToList();
                ItemList = new SelectList(items, "ItemID", "DisplayText");

                return Page();
            }

            // Set order status
            Order.Status = "Pending";

            // Create order in database to get ID
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            // Add order details
            if (ItemIDs != null && Quantities != null)
            {
                decimal totalAmount = 0;

                for (int i = 0; i < ItemIDs.Count; i++)
                {
                    if (ItemIDs[i] > 0 && i < Quantities.Count && Quantities[i] > 0)
                    {
                        var item = await _context.Items.FindAsync(ItemIDs[i]);
                        if (item != null)
                        {
                            var detail = new OrderDetail
                            {
                                OrderID = Order.OrderID,
                                ItemID = ItemIDs[i],
                                Quantity = Quantities[i],
                                UnitAmount = item.UnitPrice,
                                TotalAmount = item.UnitPrice * Quantities[i]
                            };

                            _context.OrderDetails.Add(detail);
                            totalAmount += detail.TotalAmount;
                        }
                    }
                }

                // Update order total
                Order.TotalAmount = totalAmount;
                _context.Entry(Order).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}