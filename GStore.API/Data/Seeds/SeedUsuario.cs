using GStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GStore.API.Data.Seeds;

public class SeedUsuario
{
    public SeedUsuario(ModelBuilder builder)
    {
        #region Perfis de Usuário
        List<IdentityRole> perfis = [
            new() {
                Id = "115c9e13-507e-4c7a-bb29-68207f12d060",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new() {
                Id = "149820d6-238c-4572-a84a-7335cfb5f512",
                Name = "Cliente",
                NormalizedName = "CLIENTE"
            }
        ];
        builder.Entity<IdentityRole>().HasData(perfis);
        #endregion
        
        #region Usuario
        List<Usuario> usuarios = [
            new() {
                Id = "a000d918-c865-416e-a43c-78995bd7feb1",
                Email = "admin@gstore.com.br",
                NormalizedEmail = "ADMIN@GSTORE.COM.BR",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "José Antonio Gallo Junior",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Foto = "/img/usuarios/a000d918-c865-416e-a43c-78995bd7feb1.png"
            }
        ];
        foreach (var usuario in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            usuario.PasswordHash = pass.HashPassword(usuario, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Usuário Perfil
        List<IdentityUserRole<string>> userRoles = [
            new() {
                UserId = usuarios[0].Id,
                RoleId = perfis[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}
