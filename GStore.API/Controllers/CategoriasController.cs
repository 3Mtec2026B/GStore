using GStore.API.Data;
using GStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GStore.API.Controllers;

[ApiController]
[Route("api/categorias")]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Categoria>> GetCategorias()
    {
        return Ok(_context.Categorias.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Categoria> GetCategoria(int id)
    {
        var categoria = _context.Categorias.Find(id);
        return categoria == null ? NotFound("Categoria não encontrada") : Ok(categoria);
    }
}
