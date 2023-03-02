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

        public IEnumerable<Product?[]> Rows { get; set; } = new List<Product?[]>();

        public IndexModel(ProductController controller)
        {
            this.controller = controller;
        }

        public async Task<IActionResult> OnGetAsync(CancellationToken ct)
        {
            return await DoSearchAsync(0, ct);
        }

        public async Task<IActionResult> OnPostAsync(uint pageIndex, CancellationToken ct)
        {
            return await DoSearchAsync(pageIndex, ct);
        }

        private async Task<IActionResult> DoSearchAsync(uint pageIndex, CancellationToken ct)
        {
            CurrentPage = (await controller.SearchOwnProducts(Search, pageIndex, 25, ct)).Clone(p => new Product(p));
            Rows = CurrentPage.Data.Chunk(RowSize);
            return Page();
        }
    }
}
