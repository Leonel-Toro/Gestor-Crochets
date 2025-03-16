using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Gestor.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var connectionBD = Environment.GetEnvironmentVariable("DB_CROCHET")
    ?? builder.Configuration.GetConnectionString("DB_CROCHET")
    ?? throw new InvalidOperationException("Connection string 'DB_CROCHET' not found.");

builder.Services.AddDbContext<GestorContext>(options =>
    options.UseNpgsql(connectionBD));

//builder.Services.AddDbContext<GestorContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DB_CROCHET") ?? throw new InvalidOperationException("Connection string 'DB_CROCHET' not found.")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapGet("/", context =>
{
    context.Response.Redirect("/MainView");
    return Task.CompletedTask;
});

// Aplica automáticamente las migraciones pendientes
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<GestorContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

app.Run();
