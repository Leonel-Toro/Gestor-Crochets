using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Gestor.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<GestorContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DB_CROCHET") ?? throw new InvalidOperationException("Connection string 'DB_CROCHET' not found.")));

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

app.Run();
