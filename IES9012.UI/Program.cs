using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IES9012.UI.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<IES9012Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IES9012Context") ?? throw new InvalidOperationException("Connection string 'IES9012Context' not found.")));
//Inyección de dependencias: se usa porque muchos usuarios van a acceder al mismo tiempo y
//se sobrecargaría el procesador de servidor. 

builder.Services.AddDbContext<IES9012Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IES9012Context") ?? throw new InvalidOperationException("La cadena de conexion'IES9012Context' no se encuentra.")));
//Servicio contexto de base de datos. Servirá en toda las paginas que necesiten acceder a la base de datos.
//Es el objeto que se va a instanciar para cada usuario en el navegador.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else { 
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context=services.GetRequiredService<IES9012Context>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

    app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
