using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class ClienteService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    private readonly UserManager<ApplicationUser> _userManager;

    public ClienteService(IDbContextFactory<ApplicationDbContext> dbContextFactory, UserManager<ApplicationUser> userManager)
    {
        _dbContextFactory = dbContextFactory;
        _userManager = userManager;
    }

    public async Task<List<ClienteDto>> ObtenerClientesAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.Users
            .AsNoTracking()
            .Select(u => new ClienteDto
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                PhoneNumber = u.PhoneNumber,
                EmailConfirmed = u.EmailConfirmed,
                LockoutEnd = u.LockoutEnd
            })
            .ToListAsync();
    }

    public async Task<int> ContarClientesAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Users.CountAsync();
    }

    public async Task<bool> BloquearUsuarioAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;

        if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow)
        {
            // Desbloquear
            user.LockoutEnd = null;
        }
        else
        {
            // Bloquear por 100 años
            user.LockoutEnd = DateTimeOffset.UtcNow.AddYears(100);
        }

        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }

    public async Task<bool> EliminarClienteAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }
}
