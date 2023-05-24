using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        
        
        // Вывод существующих записей в таблице
        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult ShowCountries()
        {
            using ContextDB db = new ContextDB();
            var countryList = db.Country.ToList();
                
            return Ok(countryList);
        }
        
        
        // Добавление новой записи в таблицу
        [Route("Adding/[controller]")]
        [HttpPost]
        public IActionResult AddingCountries([FromBody] Country newCountry)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            

            using (ContextDB db = new ContextDB())
            {
                
                db.Add(newCountry);
                db.SaveChanges();
                
            }

            return Ok();
        }
        
        
        // Удаление записи из таблицы
        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCountry(string nominationCountry)
        {
            using ContextDB db = new ContextDB();
            Country inputData = db.Country.Find(nominationCountry)!;

            db.Country.Remove(inputData);
            db.SaveChanges();
                    
            return Ok();
        }
        
        
        // Обновлеие записи таблицы
        [Route("Update/[controller]")]
        [HttpPut]
        public IActionResult UpdatingCountry(string nominationCountry, Country newNominationCountry)
        {
            using ContextDB db = new ContextDB();
            Country context = db.Country.Find(nominationCountry)!;

            db.Country.Remove(context);
            db.Add(newNominationCountry);
            db.SaveChanges();

            return Ok();
        }
    }
}