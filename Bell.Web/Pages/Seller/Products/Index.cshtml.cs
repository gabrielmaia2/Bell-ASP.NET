using Bell.Core.Domain.Models;
using Bell.Seller.Controllers;
using Bell.Web.Seller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bell.Web.Pages.Seller.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductController controller;

        [BindProperty]
        public string Search { get; set; } = "";

        public Page<Product> CurrentPage { get; set; } = new();

        public int RowSize => 5;

        public IEnumerable<Product?[]> Rows { get; set; }

        public IndexModel(ProductController controller)
        {
            this.controller = controller;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return await DoSearchAsync(0);
        }

        public async Task<IActionResult> OnPostAsync(uint pageIndex)
        {
            return await DoSearchAsync(pageIndex);
        }

        private async Task<IActionResult> DoSearchAsync(uint pageIndex)
        {
            CurrentPage = controller.SearchOwnProducts(Search, pageIndex, 25).Clone(p => new Product(p));
            Rows = CurrentPage.Data.Chunk(RowSize);
            return Page();
        }
    }
}
