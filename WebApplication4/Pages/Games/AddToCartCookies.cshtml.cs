using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApplication4.Pages.Games;
public class AddToCartCookies : PageModel
{
    public IActionResult OnGet(string id)
    {
        List<string> cartItemList;
        //Recuperer le Cookie
        var cartItems = Request.Cookies["MonPanier"];
        // Si le cookie null ou non existant on va travailler avec une nouvelle liste
        if (string.IsNullOrEmpty(cartItems))
        {
            cartItemList = new List<string>();
        }
        else
        
        {
            //Sinon on travaille avec notre liste actuelle
            cartItemList = JsonConvert.DeserializeObject<List<string>>(cartItems);
        }

        // Console.WriteLine("Item to Add "+id);
        cartItemList.Add(id);
        
        // Apres ajout on reserialize pour aller stocker
        var cartCookieValue = JsonConvert.SerializeObject(cartItemList);

        var options = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(1),
            IsEssential = true,
            Path = "/",
        };

        Response.Cookies.Append("MonPanier", cartCookieValue, options);

        return RedirectToPage("/Games/Index");
    }
}
