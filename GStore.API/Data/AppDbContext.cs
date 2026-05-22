using GStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GStore.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Configuração das Tabelas do Identity
        builder.Entity<Usuario>().ToTable("usuarios");
        builder.Entity<IdentityRole>().ToTable("perfis");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfis");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regras");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_tokens");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_logins");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regras");
        #endregion
    }
}
