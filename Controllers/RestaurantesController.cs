using DriveXpress.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DriveXpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RestaurantesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Restaurantes.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Restaurante model)
        {
            _context.Restaurantes.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
           var model = await _context.Restaurantes
                .Include(t => t.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id); 

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Restaurante model)
        {
            if(id != model.Id) return BadRequest();
            var modeloDb = await _context.Restaurantes.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if(modeloDb == null)return NotFound();

            _context.Restaurantes.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Restaurantes.FindAsync(id);

            if(model == null) return NotFound();   

            _context.Restaurantes.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

    }
}
