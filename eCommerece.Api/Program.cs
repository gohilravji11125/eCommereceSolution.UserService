using eCommerece.Api.Middlewares;
using eCommerece.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
