using JWTExample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JWTExample.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync("https://localhost:7070/api/filmservis").Result;
            List<Filmler> filmler=JsonConvert.DeserializeObject<List<Filmler>>(result);
            return View(filmler);
        }
    }
}
