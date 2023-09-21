using DriveXpress.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                .FirstOrDefaultAsync(c => c.Id == id); 

            if (model == null) NotFound();

            return Ok(model);
        }
    }
}
