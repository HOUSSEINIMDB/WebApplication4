using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Pages.Games;

public class CartDetailsModel : PageModel
{
    [BindProperty]
    public Cart Cart { get; set; }
    private readonly AppDbContext _context;

    public CartDetailsModel(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult OnGet(int cartId)
    {
        Cart =  _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.CartId == cartId);
        if (Cart == null)
        {
            return NotFound();
        }
        return Page();
    }
}