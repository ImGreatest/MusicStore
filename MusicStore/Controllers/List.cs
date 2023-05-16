using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class List : Controller
{
    [HttpGet]
    public IActionResult Show()
    {
        ContextDB db = new ContextDB();
        Country newCountry = new Country();

        var country = db.Counties.ToList();

        return Ok(country);
    }
}