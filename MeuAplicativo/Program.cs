using MeuAplicativo.Data;
using MeuAplicativo.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


// Adiciona serviços ao contêiner.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configuração do DbContext usando a string de conexão do appsettings.json
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

var app = builder.Build();

// Configurações do pipeline de solicitação
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
