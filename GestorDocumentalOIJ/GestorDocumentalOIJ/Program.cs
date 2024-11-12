using GestorDocumentalOIJ.BW.CU;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Acciones;
using GestorDocumentalOIJ.DA.Contexto;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5f27de4fcb458f61c065fe8e497170b907ef9c6074a43c871568a0df6b6da46c83473261b1b2f45018413479f74ffa7f9adfec6f83d464da1c921dc5050e6229"));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateAudience = false,
        ValidateIssuer = false,
    };
});




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

builder.Services.AddTransient<IGestionarDoctoBW, GestionarDoctoBW>();
builder.Services.AddTransient<IGestionarDoctoDA, GestionarDoctoDA>();

builder.Services.AddTransient<IGestionarDocumentoBW, GestionarDocumentoBW>();
builder.Services.AddTransient<IGestionarDocumentoDA, GestionarDocumentoDA>();

builder.Services.AddTransient<IGestionarVersionBW, GestionarVersionBW>();
builder.Services.AddTransient<IGestionarVersionDA, GestionarVersionDA>();

builder.Services.AddTransient<IGestionarUsuarioBW, GestionarUsuarioBW>();
builder.Services.AddTransient<IGestionarUsuarioDA, GestionarUsuarioDA>();

builder.Services.AddTransient<IGestionarRolBW, GestionarRolBW>();
builder.Services.AddTransient<IGestionarRolDA, GestionarRolDA>();

builder.Services.AddTransient<IGestionarOficinaBW, GestionarOficinaBW>();
builder.Services.AddTransient<IGestionarOficinaDA, GestionarOficinaDA>();

builder.Services.AddTransient<IGestionarPermisoBW, GestionarPermisoBW>();
builder.Services.AddTransient<IGestionarPermisoDA, GestionarPermisoDA>();

builder.Services.AddTransient<IGestionarPermisoRolBW, GestionarPermisoRolBW>();
builder.Services.AddTransient<IGestionarPermisoRolDA, GestionarPermisoRolDA>();

builder.Services.AddTransient<IGestionarPermisoOficinaBW, GestionarPermisoOficinaBW>();
builder.Services.AddTransient<IGestionarPermisoOficinaDA, GestionarPermisoOficinaDA>();

builder.Services.AddTransient<IGestionarOficinaGestorDA, GestionarOficinaGestorDA>();
builder.Services.AddTransient<IGestionarOficinaGestorBW, GestionarOficinaGestorBW>();

builder.Services.AddTransient<IGestionarNormaUsuarioBW, GestionarNormaUsuarioBW>();
builder.Services.AddTransient<IGestionarNormaUsuarioDA, GestionarNormaUsuarioDA>();

builder.Services.AddTransient<IGestionarUsuarioOficinaBW, GestionarUsuarioOficinaBW>();
builder.Services.AddTransient<IGestionarUsuarioOficinaDA, GestionarUsuarioOficinaDA>();

builder.Services.AddTransient<IGestionarReporteBW,GestionarReporteBW>();
builder.Services.AddTransient<IGestionarReporteDA, GestionarReporteDA>();

builder.Services.AddTransient<IGestionarBitacoraMovimientoBW, GestionarBitacoraMovimientoBW>();
builder.Services.AddTransient<IGestionarBitacoraMovimientoDA,GestionarBitacoraMovimientoDA>();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<UsuarioSesionHttp>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
