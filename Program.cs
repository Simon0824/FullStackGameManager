using RestApiLearning.Data;
using RestApiLearning.Dtos;
using RestApiLearning.Endpoints;
var builder = WebApplication.CreateBuilder(args);

var ConnectionString = "Data Source=RestApi.db";
builder.Services.AddSqlite<RestApiContext>(ConnectionString);

var app = builder.Build();


app.MapGetEndpoints();

app.Run();
