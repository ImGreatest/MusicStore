using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers;


[ApiController]
[Route("[controller]")]
public class ConditionController : ControllerBase
{
    // Вывод существующих записей в таблице
    [Route("Show/[controller]")]
    [HttpGet]
    public IActionResult ShowConditions()
    {
        using ContextDB db = new ContextDB();
        var conditionsList = db.Condition.ToList();
        
        return Ok(conditionsList);
    }
        
        
    // Добавление новой записи в таблицу
    [Route("Adding/[controller]")]
    [HttpPost]
    public IActionResult AddingCondition([FromBody] Condition newCondition)
    { 
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
            

        using (ContextDB db = new ContextDB())
        {
                
            db.Add(newCondition);
            db.SaveChanges();
                
        }

        return Ok();
    }
        
        
    // Удаление записи из таблицы
    [Route("Delete/[controller]")]
    [HttpDelete]
    public IActionResult DeleteCondition(string nominationCondition)
    {
        using ContextDB db = new ContextDB();
        Condition inputData = db.Condition.Find(nominationCondition)!;

        db.Condition.Remove(inputData);
        db.SaveChanges();
                    
        return Ok();
    }
        
        
    // Обновлеие записи таблицы
    [Route("Update/[controller]")]
    [HttpPut]
    public IActionResult UpdatingCondition(string nominationCondition, Condition newNominationCondition)
    {
        using ContextDB db = new ContextDB();
        Condition context = db.Condition.Find(nominationCondition)!;

        db.Condition.Remove(context);
        db.Add(newNominationCondition);
        db.SaveChanges();
        
        return Ok();
    }
}