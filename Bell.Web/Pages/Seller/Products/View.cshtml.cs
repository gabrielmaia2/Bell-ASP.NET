using Bell.Core.Domain.Exceptions;
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
        public Product Product { get; set; } = new();

        public ViewModel(ProductController controller)
        {
            this.controller = controller;
        }

        public async Task<IActionResult> OnGetAsync(ulong id, CancellationToken ct)
        {
            var product = await controller.GetOwnProductAsync(id, ct);
            if (product == null)
                return NotFound();

            Product = new Product(product);
            return Page();
        }

        public IActionResult OnPostEdit(ulong id, CancellationToken ct)
        {
            return RedirectToPage("Edit", new { id = Product.Id });
        }

        public async Task<IActionResult> OnPostDeleteAsync(ulong id, CancellationToken ct)
        {
            try
            {
                await controller.DeleteAsync(id, ct);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return RedirectToPagePermanent("Index");
        }
    }
}
