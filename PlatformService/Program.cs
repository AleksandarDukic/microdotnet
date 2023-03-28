using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>().ConfigurePrimaryHttpMessageHandler(h =>
{
    var handler = new HttpClientHandler();
/*     if (this.env.IsDevelopment())
    { */
        //Allow untrusted Https connection
        handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
/*     } */
    return handler;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

Console.WriteLine($"--> CommandService Endpoint {app.Configuration["CommandService"]}");

PrepDb.PrepPopulation(app);
//builder.Services.AddDbContext<AppDbContext>();
//builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

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

// 4:09