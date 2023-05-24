using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers;


[ApiController]
[Route("[controller]")]
public class TypeProductController : ControllerBase
{
    // Вывод существующих записей в таблице
    [Route("Show/[controller]")]
    [HttpGet]
    public IActionResult ShowTypeProduct()
    {
        using ContextDB db = new ContextDB();
        var typeProductsList = db.TypeProduct.ToList();
        
        return Ok(typeProductsList);
    }
        
        
    // Добавление новой записи в таблицу
    [Route("Adding/[controller]")]
    [HttpPost]
    public IActionResult AddingTypeProduct([FromBody] TypeProduct newTypeProduct)
    { 
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
            

        using (ContextDB db = new ContextDB())
        {
                
            db.Add(newTypeProduct);
            db.SaveChanges();
                
        }

        return Ok();
    }
        
        
    // Удаление записи из таблицы
    [Route("Delete/[controller]")]
    [HttpDelete]
    public IActionResult DeleteTypeProduct(string nominationTypeProduct)
    {
        using ContextDB db = new ContextDB();
        TypeProduct inputData = db.TypeProduct.Find(nominationTypeProduct)!;

        db.TypeProduct.Remove(inputData);
        db.SaveChanges();
                    
        return Ok();
    }
        
        
    // Обновление записи таблицы
    [Route("Update/[controller]")]
    [HttpPut]
    public IActionResult UpdatingTypeProduct(string nominationTypeProduct, TypeProduct newNominationTypeProduct)
    {
        using ContextDB db = new ContextDB();
        TypeProduct context = db.TypeProduct.Find(nominationTypeProduct)!;

        db.TypeProduct.Remove(context);
        db.Add(newNominationTypeProduct);
        db.SaveChanges();
        
        return Ok();
    }
}