using Bell.Seller.Controllers;
using Bell.Web.Seller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bell.Web.Pages.Seller.Products
{
    public class ViewModel : PageModel
    {
        private readonly ProductController controller;

        [BindProperty]
        public Product? Product { get; set; }

        public ViewModel(ProductController controller)
        {
            this.controller = controller;
        }

        public async Task<IActionResult> OnGetAsync(ulong id = 0)
        {
            var product = controller.GetOwnProduct(id);
            if (product == null)
                return NotFound();

            Product = new Product(product);
            return Page();
        }
    }
}
