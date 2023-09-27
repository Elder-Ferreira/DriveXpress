using DriveXpress.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
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

        [Authorize(Roles = "Gerente,Funcionario,Cliente")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Restaurantes.ToListAsync();
            return Ok(model);
        }

        [Authorize(Roles = "Gerente")]
        [HttpPost]
        public async Task<ActionResult> Create(Restaurante model)
        {
            _context.Restaurantes.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }

        [Authorize(Roles = "Gerente")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
           var model = await _context.Restaurantes
                .Include(t => t.Usuarios).ThenInclude(t=>t.Usuario)
                .Include(t => t.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id); 

            if (model == null) return NotFound();

            GerarLinks(model);
            return Ok(model);
        }

        [Authorize(Roles = "Gerente")]
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

        [Authorize(Roles = "Gerente")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Restaurantes.FindAsync(id);

            if(model == null) return NotFound();   

            _context.Restaurantes.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        private void GerarLinks(Restaurante model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "DELETE"));

        }

        [HttpPost("{id}/usuarios")]
        public async Task<ActionResult> AddUsuario(int id, RestauranteUsuarios model)
        {
            if (id != model.RestauranteId) return BadRequest();
            _context.RestauranteUsuarios.Add(model);
            await _context.SaveChangesAsync();  

            return CreatedAtAction("GetById", new { id = model.RestauranteId}, model);
        }

        [HttpDelete("{id}/usuarios/{usuarioId}")]
        public async Task<ActionResult> DeleteUsuario(int id, int usuarioId)
        {
            var model = await _context.RestauranteUsuarios
                 .Where(c => c.RestauranteId == id && c.UsuarioId == usuarioId)
                 .FirstOrDefaultAsync();

            if (model == null) return NotFound();

            _context.RestauranteUsuarios.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
