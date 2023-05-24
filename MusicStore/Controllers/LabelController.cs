using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class LabelController : ControllerBase
{
    
    
    // Вывод существующих записей в таблице
    [Route("Show/[controller]")]
    [HttpGet]
    public IActionResult ShowLabels()
    {
        using ContextDB db = new ContextDB();
        var ofLabels = db.Label.ToList();

        return Ok(ofLabels);
    }

    
    // Добавление новой записи в таблицу
    [Route("Adding/[controller]")]
    [HttpPost]
    public IActionResult AddingLabels([FromBody] Label newLabel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        using (ContextDB db = new ContextDB())
        {
            
            db.Add(newLabel);
            db.SaveChanges();
            
        }

        return Ok();
    }
    
    
    // Удаление записи из таблицы
    [Route("Delete/[controller]")]
    [HttpDelete]
    public IActionResult DeleteLabel(string nominationLabel)
    {
        using ContextDB db = new ContextDB();
        Label inputData = db.Label.Find(nominationLabel)!;

        db.Label.Remove(inputData);
        db.SaveChanges();
                    
        return Ok();
    }
    
    
    // Обновлеие записи таблицы
    [Route("Update/[controller]")]
    [HttpPut]
    public IActionResult UpdatingLabel(string nominationLabel, Label newNominationLabel)
    {
        using ContextDB db = new ContextDB();
        Label context = db.Label.Find(nominationLabel)!;

        db.Label.Remove(context);
        db.Add(newNominationLabel);
        db.SaveChanges();

        return Ok();
    }
}