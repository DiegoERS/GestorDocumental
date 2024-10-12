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

builder.Services.AddTransient<IGestionarTipoDocumentoBW, GestionarTipoDocumentoBW>();
builder.Services.AddTransient<IGestionarTipoDocumentoDA, GestionarTipoDocumentoDA>();

builder.Services.AddTransient<IGestionarNormaBW, GestionarNormaBW>();
builder.Services.AddTransient<IGestionarNormaDA, GestionarNormaDA>();

builder.Services.AddTransient<IGestionarEtapaBW, GestionarEtapaBW>();
builder.Services.AddTransient<IGestionarEtapaDA, GestionarEtapaDA>();

builder.Services.AddTransient<IGestionarClasificacionBW, GestionarClasificacionBW>();
builder.Services.AddTransient<IGestionarClasificacionDA, GestionarClasificacionDA>();

builder.Services.AddTransient<IGestionarSubclasificacionBW, GestionarSubclasificacionBW>();
builder.Services.AddTransient<IGestionarSubclasificacionDA, GestionarSubclasificacionDA>();



// Configurar la cadena de conexión a la base de datos

builder.Services.AddDbContext<GestorDocumentalContext>(options =>
{
    // Usar la cadena de conexión desde la configuración
    var connectionString = builder.Configuration.GetConnectionString("GestorDocumentalConnection");
    options.UseSqlServer(connectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aquí, si es necesario
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
