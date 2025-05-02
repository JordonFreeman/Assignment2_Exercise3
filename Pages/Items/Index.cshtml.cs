using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Data;
using OrderManagement.RazorWeb.Models;

namespace OrderManagement.RazorWeb.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Items { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }

        public string CurrentSort { get; set; }
        public string NameSort { get; set; }
        public string SizeSort { get; set; }
        public string PriceSort { get; set; }
        public string StockSort { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Check if user is authenticated
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                return RedirectToPage("/Login");
            }

            // Set up sorting parameters
            CurrentSort = SortOrder;
            NameSort = SortOrder == "name_asc" ? "name_desc" : "name_asc";
            SizeSort = SortOrder == "size_asc" ? "size_desc" : "size_asc";
            PriceSort = SortOrder == "price_asc" ? "price_desc" : "price_asc";
            StockSort = SortOrder == "stock_asc" ? "stock_desc" : "stock_asc";

            // Start with the base query
            IQueryable<Item> itemsQuery = _context.Items;

            // Apply search filter
            if (!string.IsNullOrEmpty(SearchString))
            {
                itemsQuery = itemsQuery.Where(i => i.ItemName.Contains(SearchString));
            }

            // Apply sorting
            switch (SortOrder)
            {
                case "name_asc":
                    itemsQuery = itemsQuery.OrderBy(i => i.ItemName);
                    break;
                case "name_desc":
                    itemsQuery = itemsQuery.OrderByDescending(i => i.ItemName);
                    break;
                case "size_asc":
                    itemsQuery = itemsQuery.OrderBy(i => i.Size);
                    break;
                case "size_desc":
                    itemsQuery = itemsQuery.OrderByDescending(i => i.Size);
                    break;
                case "price_asc":
                    itemsQuery = itemsQuery.OrderBy(i => i.UnitPrice);
                    break;
                case "price_desc":
                    itemsQuery = itemsQuery.OrderByDescending(i => i.UnitPrice);
                    break;
                case "stock_asc":
                    itemsQuery = itemsQuery.OrderBy(i => i.StockQuantity);
                    break;
                case "stock_desc":
                    itemsQuery = itemsQuery.OrderByDescending(i => i.StockQuantity);
                    break;
                default:
                    itemsQuery = itemsQuery.OrderBy(i => i.ItemID);
                    break;
            }

            Items = await itemsQuery.ToListAsync();
            return Page();
        }
    }
}