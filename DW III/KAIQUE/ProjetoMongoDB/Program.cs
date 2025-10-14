using Microsoft.AspNetCore.Identity;
using ProjetoMongoDB.Models;
using ProjetoMongoDB.Services;
using ProjetoMongoDB.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexão com o MongoDB
ContextMongoDb.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionStrings").Value;
ContextMongoDb.DatabaseName = builder.Configuration.GetSection("MongoConnection:Database").Value;
ContextMongoDb.Isssl = Convert.ToBoolean(builder.Configuration.GetSection("MongoConnection:IsSsl").Value);

// Configuração��o do Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
    (ContextMongoDb.ConnectionString, ContextMongoDb.DatabaseName)
    .AddDefaultTokenProviders(); // Usado para gerar os tokens

// Configuração do Envio de E-mail
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddSingleton<EmailService>();

builder.Services.AddScoped<ContextMongoDb>();

var app = builder.Build();

// Lógica da assinatura no evento
using (var scope = app.Services.CreateScope())
{
    var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();

    // Assinante 
    ProjetoMongoDB.Services.EventoNotifier.OnParticipanteRegistrado += emailService.HandleRegistroAsync;
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

// Autentica��o de usu�rio do Identity
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
