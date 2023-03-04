using Bell.Seller.Controllers;
using Bell.Web.Seller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bell.Web.Pages.Seller.Products
{
    public class PublishModel : PageModel
    {
        private readonly ProductController controller;

        [BindProperty]
        public NewProduct NewProduct { get; set; } = new();

        public PublishModel(ProductController controller)
        {
            this.controller = controller;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = await controller.PublishAsync(NewProduct.AsModel(), ct);

            return RedirectToPage("View", new { id = product.Id });
        }
    }
}
