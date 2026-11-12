
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// CONFIGURAÇÃO DO BANCO DE DADOS
// ==========================================

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ==========================================
// CONFIGURAÇÃO DO IDENTITY
// ==========================================

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

// ==========================================
// CONSTRUÇÃO DA APLICAÇÃO
// ==========================================

var app = builder.Build();

// ==========================================
// CONFIGURAÇÃO DO ADMINISTRADOR
// ==========================================

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // Criar função Admin caso não exista
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        var roleResult = await roleManager.CreateAsync(
            new IdentityRole("Admin"));

        if (!roleResult.Succeeded)
        {
            var errors = string.Join("; ",
                roleResult.Errors.Select(e => e.Description));

            throw new Exception("Erro ao criar função Admin: " + errors);
        }
    }

    // Recuperar configurações do administrador
    var adminEmail = app.Configuration["AdminUser:Email"];
    var adminPassword = app.Configuration["AdminUser:Password"];

    if (string.IsNullOrWhiteSpace(adminEmail))
    {
        throw new Exception(
            "E-mail do administrador não configurado no User Secrets.");
    }

    // Procurar conta administrativa
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    // Criar administrador caso não exista
    if (adminUser == null)
    {
        if (string.IsNullOrWhiteSpace(adminPassword))
        {
            throw new Exception(
                "Senha do administrador não configurada no User Secrets.");
        }

        adminUser = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var createResult = await userManager.CreateAsync(
            adminUser, adminPassword);

        if (!createResult.Succeeded)
        {
            var errors = string.Join("; ",
                createResult.Errors.Select(e => e.Description));

            throw new Exception(
                "Erro ao criar administrador: " + errors);
        }

        app.Logger.LogInformation(
            "Conta administrativa criada com sucesso.");
    }

    // Atribuir função Admin
    if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        var assignmentResult = await userManager.AddToRoleAsync(
            adminUser, "Admin");

        if (!assignmentResult.Succeeded)
        {
            var errors = string.Join("; ",
                assignmentResult.Errors.Select(e => e.Description));

            throw new Exception(
                "Erro ao atribuir função Admin: " + errors);
        }
    }
}

// ==========================================
// CONFIGURAÇÃO DO PIPELINE
// ==========================================

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// Autenticação antes da autorização
app.UseAuthentication();
app.UseAuthorization();

// ==========================================
// ROTAS
// ==========================================

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Instrumentos}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
