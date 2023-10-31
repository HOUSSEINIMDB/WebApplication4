using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication4.Data;
using WebApplication4.Model; 

namespace WebApplication4.Pages.Games;
public class PanierLibreModel : PageModel
{
    private readonly AppDbContext _context; 

    public PanierLibreModel(AppDbContext context)
    {
        _context = context;
    }

    public List<GameItem> CartItems { get; set; }

    public async Task OnGet()
    {
        var cartIds = ReadCartItemsFromCookie();
        CartItems = await FetchItemsFromDbContext(cartIds);
    }

    private List<string> ReadCartItemsFromCookie()
    {
        var cartItems = Request.Cookies["MonPanier"];
        return string.IsNullOrEmpty(cartItems) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(cartItems);
    }

    private async Task<List<GameItem>> FetchItemsFromDbContext(List<string> itemIds)
    {
        var items = new List<GameItem>();
        foreach (var itemIdString in itemIds)
        {
            // Console.WriteLine("ItemIdString"+itemIdString) ; //print debugging, tres important
            // On a serializé json avec de strings, il faut les reconvertir en Id integer avant de verifier que ce que
            // le client à dans ses cookies existe encore dans la base de données
            if (int.TryParse(itemIdString, out int itemIdInt))
                
            {
                // Console.WriteLine("ItemId"+itemIdInt);
                // On verifie dans la base de données on ne lui montre pas ce qui n'est plus dans le stock
                var item = await _context.Items.FirstOrDefaultAsync(i => i.GameId == itemIdInt);
                if (item != null)
                {
                    items.Add(item);
                }
            }
        }

        return items;
    }

}