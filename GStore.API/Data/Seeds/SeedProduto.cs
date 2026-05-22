using GStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GStore.API.Data.Seeds;

public class SeedProduto
{
    public SeedProduto(ModelBuilder modelBuilder)
    {
        List<Produto> produtos = [
            // Smarthphone = 1
            new() {
                Id = 1,
                CategoriaId = 1,
                Nome = "",
                Descricao = @"",
                ValorCusto = 1,
                ValorVenda = 1.99m,
                Qtde = 0,
                Destaque = true,
                Foto = "/img/produtos/1.png"
            },
        ];
        modelBuilder.Entity<Produto>().HasData(produtos);
    }
}
