using System;
using Microsoft.EntityFrameworkCore;
using RestApiLearning.Models;

namespace RestApiLearning.Data;

public static class DataExtention
{
    public static void MigrationDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RestApiContext>();
        context.Database.Migrate();
    }

    public static void AddGameDb(this WebApplicationBuilder builder)
    {
        builder.Services.AddSqlite<RestApiContext>("Data Source=RestApi.db", optionsAction : options => options.UseSeeding((context, _)
        =>
        {
            if(!context.Set<Game>().Any())
            {
                context.Set<Game>().Add(
                    new Game
                    {
                        Title = "FirstGame",
                        Genre = "FirstGenre",
                        Price = 99.99m,
                        ReleaseDate = DateOnly.Parse("2000, 01, 01")
                    }
                );
                context.SaveChanges();
            }
        }));
    }
}
