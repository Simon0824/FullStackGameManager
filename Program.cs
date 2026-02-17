using RestApiLearning.Data;
using RestApiLearning.Dtos;
using RestApiLearning.Endpoints;
var builder = WebApplication.CreateBuilder(args);

var ConnectionString = "Data Source=RestApi.db";
builder.Services.AddSqlite<RestApiContext>(ConnectionString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("angular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("angular");


app.MigrationDb();

app.MapGetEndpoints();

app.Run();
