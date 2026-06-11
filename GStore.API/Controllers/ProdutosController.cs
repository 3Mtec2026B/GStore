using GStore.API.Data;
using GStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GStore.API.Controllers;

[ApiController]
[Route("api/Produtos")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Produto>> GetProdutos()
    {
        return Ok(_context.Produtos.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> GetProduto(int id)
    {
        var Produto = _context.Produtos.Find(id);
        return Produto == null ? NotFound("Produto não encontrada") : Ok(Produto);
    }

    [HttpPost]
    public ActionResult PostProduto([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Verifique os dados informados");
        
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public ActionResult PutProduto(int id, [FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Verifique os dados informados");
        if (id != produto.Id)
            return BadRequest("Verifique os dados informados");
        
        var oldProduto = _context.Produtos.Find(id);
        if (oldProduto == null) 
            return NotFound("Produto não localizada");
        oldProduto.Nome = produto.Nome;
        oldProduto.CategoriaId = produto.CategoriaId;
        oldProduto.Descricao = produto.Descricao ?? oldProduto.Descricao;
        oldProduto.Qtde = produto.Qtde;
        oldProduto.ValorCusto = produto.ValorCusto;
        oldProduto.ValorVenda = produto.ValorVenda;
        oldProduto.Destaque = produto.Destaque;
        oldProduto.Foto = produto.Foto ?? oldProduto.Foto;
        _context.Entry(oldProduto).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public ActionResult DeleteProduto(int id)
    {
        var oldProduto = _context.Produtos.Find(id);
        if (oldProduto == null) 
            return NotFound("Produto não localizada");
        // Poderia pesquisar se existem produtos antes de excluir
        _context.Produtos.Remove(oldProduto);
        _context.SaveChanges();
        return NoContent();
    }

}
