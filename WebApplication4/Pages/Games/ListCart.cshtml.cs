using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Pages.Games
{
    public class ListCartModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Cart Cart { get; set; }

        public ListCartModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // erreurs
            }
            Cart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == Cart.CartId);
            if (Cart == null)
            {
                return NotFound();
            }
            return RedirectToPage("CartDetails", new { cartId = Cart.CartId });
        }
    }
}