using GestorDocumentalOIJ.BW.CU;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Acciones;
using GestorDocumentalOIJ.DA.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de dependencias
builder.Services.AddTransient<IGestionarCategoriaBW, GestionarCategoriaBW>();
builder.Services.AddTransient<IGestionarCategoriaDA, GestionarCategoriaDA>();


// Configurar la cadena de conexi�n a la base de datos

builder.Services.AddDbContext<GestorDocumentalContext>(options =>
{
    // Usar la cadena de conexi�n desde la configuraci�n
    var connectionString = "Server=Diego;Database=WebServices;Trusted_Connection=True;TrustServerCertificate=True;";
    options.UseSqlServer(connectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aqu�, si es necesario
});
var app = builder.Build();

app.UseCors(Options =>
{
    Options.AllowAnyOrigin();
    Options.AllowAnyMethod();
    Options.AllowAnyHeader();
});

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
