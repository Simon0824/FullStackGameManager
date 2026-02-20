using RestApiLearning.Data;
using RestApiLearning.Dtos;
using RestApiLearning.Endpoints;
using Microsoft.OpenApi;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddGameDb();
var ConnectionString = "Data Source=RestApi.db";
builder.Services.AddSqlite<RestApiContext>(ConnectionString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("angular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("angular");

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MigrationDb();

app.MapGetEndpoints();

app.Run();
