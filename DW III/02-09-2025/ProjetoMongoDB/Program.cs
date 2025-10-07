using Microsoft.AspNetCore.Identity;
using ProjetoMongoDB.Models;
using ProjetoMongoDB.Services;
using ProjetoMongoDB.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexao com o MongoDB
ContextMongoDb.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
ContextMongoDb.DatabaseName = builder.Configuration.GetSection("MongoConnection:Database").Value;
ContextMongoDb.Isssl = Convert.ToBoolean(builder.Configuration.GetSection("MongoConnection:Isssl").Value);


// Confugura��o do Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
    (ContextMongoDb.ConnectionString, ContextMongoDb.DatabaseName)
    .AddDefaultTokenProviders(); // Usado para gerar os tokens

// Configuracao do Envio do E-mail
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailService"));
builder.Services.AddTransient<EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Autentifica��o de usu�rio do Indentity
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
