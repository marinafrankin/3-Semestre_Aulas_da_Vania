using ProjetoMongoDB.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexao com o MongoDB
ContextMongoDb.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
ContextMongoDb.DatabaseName = builder.Configuration.GetSection("MongoConnection:Database").Value;
ContextMongoDb.Isssl = Convert.ToBoolean(builder.Configuration.GetSection("MongoConnection:Isssl").Value);


// Confuguração do Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
    (ContextMongoDb.ConnectionString, ContextMongoDb.DatabaseName);


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

// Autentificação de usuário do Indentity
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
