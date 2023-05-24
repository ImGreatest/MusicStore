using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    
    // Вывод существующих записей в таблице
    [Route("Show/[controller]")]
    [HttpGet]
    public IActionResult ShowAlbums()
    {
        using ContextDB db = new ContextDB();
        var albumsList = db.Album.ToList();

        return Ok(albumsList);
    }
    
    
    //Добавление новой записи в таблицу
    [Route("Adding/[controller]")]
    [HttpPost]
    public IActionResult AddingAlbum([FromBody] Album newAlbum)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        using ContextDB db = new ContextDB();
        db.Add(newAlbum);
        db.SaveChanges();

        return Ok();
    }
    
    
    //Удаление записи из таблицы
    [Route("Delete/[controller]")]
    [HttpDelete]
    public IActionResult DeleteAlbum(int identifyAlbum)
    {
        using ContextDB db = new ContextDB();
        Album inputData = db.Album.Find(identifyAlbum)!;

        db.Album.Remove(inputData);
        db.SaveChanges();

        return Ok();
    }
    
    
    //Обновление записи таблицы
    [Route("Update/[controller]")]
    [HttpPut]
    public IActionResult UpdatingAlbum(int identifyAlbum, Album newAlbum)
    {
        using ContextDB db = new ContextDB();
        Album context = db.Album.Find(identifyAlbum)!;

        db.Album.Remove(context);
        db.Add(newAlbum);
        db.SaveChanges();

        return Ok();
    }
}