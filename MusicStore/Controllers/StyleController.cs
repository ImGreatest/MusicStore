using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers;


[ApiController]
[Route("[controller]")]
public class StyleController : ControllerBase
{
    // Вывод существующих записей в таблице
    [Route("Show/[controller]")]
    [HttpGet]
    public IActionResult ShowStyles()
    {
        using ContextDB db = new ContextDB();
        var stylesList = db.Style.ToList();
        
        return Ok(stylesList);
    }
        
        
    // Добавление новой записи в таблицу
    [Route("Adding/[controller]")]
    [HttpPost]
    public IActionResult AddingStyle([FromBody] Style newStyle)
    { 
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
            

        using (ContextDB db = new ContextDB())
        {
                
            db.Add(newStyle);
            db.SaveChanges();
                
        }

        return Ok();
    }
        
        
    // Удаление записи из таблицы
    [Route("Delete/[controller]")]
    [HttpDelete]
    public IActionResult DeleteStyle(string nominationStyle)
    {
        using ContextDB db = new ContextDB();
        Style inputData = db.Style.Find(nominationStyle)!;

        db.Style.Remove(inputData);
        db.SaveChanges();
                    
        return Ok();
    }
        
        
    // Обновлеие записи таблицы
    [Route("Update/[controller]")]
    [HttpPut]
    public IActionResult UpdatingStyle(string nominationStyle, Style newNominationStyle)
    {
        using ContextDB db = new ContextDB();
        Style context = db.Style.Find(nominationStyle)!;

        db.Style.Remove(context);
        db.Add(newNominationStyle);
        db.SaveChanges();
        
        return Ok();
    }
}