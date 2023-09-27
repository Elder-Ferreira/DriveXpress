using DriveXpress.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DriveXpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Gerente,Funcionario,Cliente")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Produtos.ToListAsync();
            return Ok(model);
        }

        [Authorize(Roles = "Gerente,Funcionario")]
        [HttpPost]
        public async Task<ActionResult> Create(Produto model)
        {
            _context.Produtos.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [Authorize(Roles = "Gerente,Funcionario")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Produtos
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            GerarLinks(model);
            return Ok(model);
        }

        [Authorize(Roles = "Gerente,Funcionario")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Produto model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Produtos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Produtos.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [Authorize(Roles = "Gerente,Funcionario")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Produtos.FindAsync(id);

            if (model == null) return NotFound();

            _context.Produtos.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void GerarLinks(Produto model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "DELETE"));

        }
    }
}
