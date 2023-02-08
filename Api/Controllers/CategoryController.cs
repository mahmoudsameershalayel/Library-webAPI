using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await _context.categories.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var cat = await _context.categories.FirstOrDefaultAsync (c => c.Id == id);
            if(cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
            
        }
        [HttpPost]
        public IActionResult Post(Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id , Category category)
        {
            if(id == 0 || id == null)
            {
                return BadRequest();
            }
            var cat = _context.categories.FirstOrDefault(x => x.Id == id);
            if(cat == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                cat.Title = category.Title;
                _context.categories.Update(cat);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cat = _context.categories.Find(id);
            if(cat == null)
            {
                return NotFound();
            }
            _context.categories.Remove(cat);
            _context.SaveChanges();
            return Ok();
        }

    }
}
