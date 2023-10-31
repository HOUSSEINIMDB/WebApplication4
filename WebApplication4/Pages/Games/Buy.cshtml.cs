using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Pages.Games
{
    public class BuyModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<GameItem> items { get; set; }
        // public GameItems items { get; set; }

        public BuyModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            GameItem gameitem = _context.Items.First(g=>g.GameId==id && g.CartId == null);
            
            if (gameitem != null)
            {
                return Page();
            }
            return RedirectToPage("./NoItemAvailable");
            
        }

        public async Task<IActionResult> OnPostAsync(int id, int CartId)
        {
            var cart = _context.Carts.Find(CartId);
            GameItem gameitem = _context.Items.First(g=>g.GameId==id && g.CartId == null);
            if (cart != null)
            {
                cart.CartItems.Add(gameitem);
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./GameNotFound");
        }
    }
}