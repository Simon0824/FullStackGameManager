using System;
using RestApiLearning.Dtos;

namespace RestApiLearning.Endpoints;

public static class GameEndpoints
{
     private static readonly List<GameDto> games = [
    new(
        1,
        "The Legend of Zelda: Breath of the Wild",
        "Action-adventure",
        new DateOnly(2017, 3, 3)
    ),
    new(
        2,
        "God of War",
        "Action-adventure",
        new DateOnly(2018, 4, 20)
    ),
    ];

    public static void MapGetEndpoints(this WebApplication app)
    {
        app.MapGet("/games", () => games);

        app.MapGet("/games/{id}", (int id) => games.Find(g => g.Id == id));

        app.MapPost("/games", (CreateGameDto newGame) =>
       {
         GameDto game = new(
        games.Count + 1,
        newGame.Title,
        newGame.Genre,
        newGame.ReleaseDate
        );
        games.Add(game);
        return Results.Created($"/games/{game.Id}", game);
      });

      app.MapDelete("/games/{id}", (int id) =>
      {
       var game = games.Find(g => g.Id == id);
       if (game is null)
       {
         return Results.NotFound();
       }
       games.Remove(game);
       return Results.NoContent();
      });
    }
}
