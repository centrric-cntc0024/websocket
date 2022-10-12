
using Serilog;
using sockettestlast.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
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
app.Lifetime.ApplicationStarted.Register(OnStarted);
app.Lifetime.ApplicationStopping.Register(OnStopping);
app.Lifetime.ApplicationStopped.Register(OnStopped);
async void OnStarted()
{
    WebsocketService websocket = new WebsocketService();
    CancellationToken stoppingToken = CancellationToken.None;
    await websocket.StartAsync(stoppingToken);
    
    
}
void OnStopping()
{
    Log.Information("error: application stopped");
}
void OnStopped()
{
    Log.Information("error: application stopped");
}
app.Run();
