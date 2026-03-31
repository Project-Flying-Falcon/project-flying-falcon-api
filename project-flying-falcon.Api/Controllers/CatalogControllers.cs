using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flying.Falcon.Domain.Catalog;
using Flying.Falcon.Data;

namespace project_flying_falcon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        // _db is like a private instance variable in Java
        // ASP.NET automatically provides it via dependency injection
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        // GET /catalog - returns all items from the database
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_db.Items);
        }

        // GET /catalog/1234 - returns a single item by id
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST /catalog - adds a new item to the database
        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        // POST /catalog/1234/ratings - adds a rating to an item
        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.AddRating(rating);
            _db.SaveChanges();
            return Ok(item);
        }

        // PUT /catalog/1234 - updates an item by id
        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id, [FromBody] Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            if (_db.Items.Find(id) == null)
            {
                return NotFound();
            }
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return NoContent();
        }

        // DELETE /catalog/1234 - deletes an item by id
        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Items.Remove(item);
            _db.SaveChanges();
            return Ok();
        }
    }
}