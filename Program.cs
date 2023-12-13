using AcademiaFS.CSharp.Tuesday._Features.ContadorCaracteres;
using AcademiaFS.CSharp.Tuesday._Features.ConteoPersonasGrupo;
using AcademiaFS.CSharp.Tuesday._Features.EstudiantesPromedio;
using AcademiaFS.CSharp.Tuesday._Features.OperacionesAritmeticas;
using Farsiman.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Learn more about configurin Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddFsAuthService((options) =>
{
    options.Username = builder.Configuration.GetFromENV("FsIdentityServer:Username");
    options.Password = builder.Configuration.GetFromENV("FsIdentityServer:Password");
});


// Servicio de Aplicación
builder.Services.AddTransient<OperacionesAritmeticasService>();
builder.Services.AddTransient<ContadorCaracteresService>();
builder.Services.AddTransient<ConteoPersonasGrupoService>();
builder.Services.AddTransient<EstudiantePromedioService>();


// Add services to the container.

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.UseAuthentication();

app.UseCors("AllowSpecificOrigin");

app.UseFsAuthService();

app.MapControllers();


app.Run();

