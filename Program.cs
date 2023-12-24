using gamer_store_api.Data;
using gamer_store_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext
builder.Services.AddSqlServer<GamerStoreContext>(builder.Configuration.GetConnectionString("GamerStoreConnection"));

//Service Layer
builder.Services.AddScoped<EstadosService>();
builder.Services.AddScoped<CategoriasService>();
builder.Services.AddScoped<RolesService>();
builder.Services.AddScoped<UsuariosService>();
builder.Services.AddScoped<LoginService>();

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
