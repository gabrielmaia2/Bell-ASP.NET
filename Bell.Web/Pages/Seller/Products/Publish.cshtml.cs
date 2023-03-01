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
        public NewProduct NewProduct { get; set; }

        public PublishModel(ProductController controller)
        {
            this.controller = controller;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = controller.Publish(NewProduct.AsModel());

            return RedirectToAction("View", new { id = product.Id });
        }
    }
}
