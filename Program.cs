using WebApi_Gestion_en_3_capas.BL.Services;
using WebApi_Gestion_en_3_capas.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Inyeccion de dependencias
// Inyección de dependencias
builder.Services.AddScoped<IProductoRepository, RepositorioProductos>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    }); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
