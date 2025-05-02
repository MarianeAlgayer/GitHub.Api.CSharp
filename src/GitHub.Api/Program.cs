using TrackFetch.Api.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Load configuration files
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddUseCases();
builder.Services.AddVersioning();
builder.Services.AddMediatorToUseCases();
//builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(UseCase))));
builder.Services.AddOptionsConfig(builder.Configuration);
builder.Services.AddHttpClients(builder.Configuration);

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
