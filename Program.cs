using System.Text;
using gamer_store_api.Data;
using gamer_store_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddScoped<ProductosService>();
builder.Services.AddScoped<PlataformasService>();
builder.Services.AddScoped<MetodosPagoService>();
builder.Services.AddScoped<UnidadesMedidaService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
