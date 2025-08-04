using Blazored.Toast;
using EbanisteriaLopezProyectoFinal.Components;
using EbanisteriaLopezProyectoFinal.Components.Account;
using EbanisteriaLopezProyectoFinal.Components.Services;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<ServicioService>();

builder.Services.AddScoped<CategoriaServices>();
builder.Services.AddScoped<SupabaseStorageService>();
builder.Services.AddScoped<CarritoService>();
builder.Services.AddHttpClient<SupabaseStorageService>();
builder.Services.AddScoped<CotizacionService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<VentaService>();


builder.Services.AddScoped<EstadoProductoService>(sp =>


{
    var dbContextFactory = sp.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    return new EstadoProductoService(dbContextFactory);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

 
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.Run();