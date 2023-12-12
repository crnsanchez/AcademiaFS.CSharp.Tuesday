using Farsiman.Exceptions.DependencyInjection;
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


//builder.Services.AddDbContext<LogisticDBContext>(o => o.UseSqlServer(
//                builder.Configuration.GetConnectionStringFromENV("LOGISTIC")));

//builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddFsAuthService((options) =>
{
    options.Username = builder.Configuration.GetFromENV("FsIdentityServer:Username");
    options.Password = builder.Configuration.GetFromENV("FsIdentityServer:Password");
});

// Servicio de Aplicación
// builder.Services.AddTransient<EmpresaSerivce>();


// Add services to the container.

var app = builder.Build();


app.UseFsWebApiExceptionHandler(builder.Configuration["seq:url"], builder.Configuration["seq:key"]);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.UseAuthentication();

app.UseCors("AllowSPecificOrigin");

app.UseFsAuthService();

app.MapControllers();



var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
