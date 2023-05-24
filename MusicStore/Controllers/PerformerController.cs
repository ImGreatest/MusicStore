using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class PerformerController : ControllerBase
{
    
    //Вывод существующих записей в таблице
    [Route("Show/[controller]")]
    [HttpGet]
    public IActionResult ShowPerformers()
    {
        using ContextDB db = new ContextDB();
        var performersList = db.Performer.ToList();
        return Ok(performersList);
    }
    
    
    // Добавление новой записи в таблицу
    [Route("Adding/[controller]")]
    [HttpPost]
    public IActionResult AddingPerfomer([FromBody] Performer newPerformer)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        using (ContextDB db = new ContextDB())
        {
            db.Add(newPerformer);
            db.SaveChanges();
        }

        return Ok();
    }
    
    // Удаление записи из таблицы
    [Route("Delete/[controller]")]
    [HttpDelete]
    public IActionResult DeletePerformer(int idPerformer)
    {
        using ContextDB db = new ContextDB();
        Performer inputData = db.Performer.Find(idPerformer);

        db.Performer.Remove(inputData);
        db.SaveChanges();

        return Ok();
    }
    
    
    // Обновление записи таблицы
    [Route("Update/[controller]")]
    [HttpPut]
    public IActionResult UpdatingPerformer(int identifierPerformer, Performer newPerformer)
    {
        using ContextDB db = new ContextDB();
        Performer context = db.Performer.Find(identifierPerformer)!;

        db.Performer.Remove(context);
        db.Add(newPerformer);
        db.SaveChanges();

        return Ok();
    }
}