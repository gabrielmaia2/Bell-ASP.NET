using Bell.Core.Domain.Exceptions;
using Bell.Seller.Controllers;
using Bell.Web.Seller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bell.Web.Pages.Seller.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductController controller;

        [BindProperty]
        public Product Product { get; set; } = new();

        public EditModel(ProductController controller)
        {
            this.controller = controller;
        }

        public async Task<IActionResult> OnGetAsync(ulong id, CancellationToken ct)
        {
            var product = await controller.GetOwnProduct(id, ct);
            if (product == null)
                return NotFound();

            Product = new Product(product);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken ct)
        {
            try
            {
                await controller.Edit(Product.AsUpdateProduct(), ct);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return RedirectToPagePermanent("View", new { id = Product.Id });
        }

        public IActionResult OnPostCancel(CancellationToken ct)
        {
            return RedirectToPagePermanent("View", new { id = Product.Id });
        }
    }
}
