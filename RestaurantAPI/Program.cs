using RestaurantAPI.Services;
using RestaurantAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .Add(new ServiceDescriptor(typeof(IPlato), 
        new PlatoRepository()));
builder.Services
    .Add(new ServiceDescriptor(typeof(IUsuario),
        new UsuarioRepository()));
builder.Services
    .Add(new ServiceDescriptor(typeof(IPedido),
        new PedidoRepository()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
