using System.Text.Json.Serialization;
using ContactList.Helpers;
using ContactList.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var env = builder.Environment;

// Database connection string.
// var connection = @"Server=localhost,1433;Database=ContactList;User=SA;Password=P@ssw0rd;";
// services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
services.AddDbContext<DataContext>();


services.AddCors();
services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // ignore omitted parameters on models to enable optional params (e.g. User update)
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// configure DI for application services
services.AddScoped<IContactService, ContactService>();
services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
}

app.Run();