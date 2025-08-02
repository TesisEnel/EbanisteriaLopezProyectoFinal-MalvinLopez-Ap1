namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class ClienteDto
{
    public string Id { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? PhoneNumber { get; set; }
    public bool EmailConfirmed { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }

    public bool EstaBloqueado => LockoutEnd != null && LockoutEnd > DateTimeOffset.UtcNow;
}
