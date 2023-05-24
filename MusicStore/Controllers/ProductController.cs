using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using MusicStore.Models;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    
    
    // Вывод существующих записей в таблице
    [Route("Show/[controller]")]
    [HttpGet]
    public IActionResult ShowProduct()
    {
        using ContextDB db = new ContextDB();
        var productsList = db.Product.ToList();
        return Ok(productsList);
    }
    
    
    // Добавление новой записи в таблицу
    [Route("Adding/[controller]")]
    [HttpPost]
    public IActionResult AddingProduct([FromBody] Product newProduct)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        using (ContextDB db = new ContextDB())
        {
            db.Add(newProduct);
            db.SaveChanges();
            
        }

        return Ok();
    }
    
    
    // Удаление записи из таблицы
    [Route("Delete/[controller]")]
    [HttpDelete]
    public IActionResult DeleteProduct(int identifyProduct)
    {
        using ContextDB db = new ContextDB();
        Product inputData = db.Product.Find(identifyProduct);

        db.Product.Remove(inputData);
        db.SaveChanges();

        return Ok();
    }
    
    
    // Обновление записи таблицы
    [Route("Update/[controller]")]
    [HttpPut]
    public IActionResult UpdatingProduct(int identifyProduct, Product newProduct)
    {
        using ContextDB db = new ContextDB();
        Product context = db.Product.Find(identifyProduct);

        db.Product.Remove(context);
        db.Add(newProduct);
        db.SaveChanges();

        return Ok();
    }
}