using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var builder2 = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddScoped<CategoriaRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped< IProdutosRepositorio, ProdutosRepositorio >();
builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
builder.Services.AddScoped<ISecretariaRepositorio, SecretariaRepositorio>();
builder.Services.AddScoped<IEntradaRepositorio, EntradaRepoitorio>();
builder.Services.AddScoped<IItensEntradaRepositorio, ItensEntradaRepositorio>();
builder.Services.AddScoped<ISaidaRepositorio, ISaidaRepositorio>();


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
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});

builder2.Services.AddAuthorization();
builder2.Services.AddAuthorization();

var app2 = builder2.Build();

// Middleware de autenticação e autorização
app2.UseAuthentication();
app2.UseAuthorization();

app2.MapControllers();

app2.Run();
