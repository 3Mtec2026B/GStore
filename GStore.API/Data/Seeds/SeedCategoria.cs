using GStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GStore.API.Data.Seeds;

public class SeedCategoria
{
    public SeedCategoria(ModelBuilder modelBuilder)
    {
        List<Categoria> categorias = [
            new() { Id = 1, Nome = "Smartphones" },
            new() { Id = 2, Nome = "Notebooks" },
        ];
        modelBuilder.Entity<Categoria>().HasData(categorias);
    }
}
