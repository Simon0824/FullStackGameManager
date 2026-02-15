using System;
using Microsoft.EntityFrameworkCore;
using RestApiLearning.Data;
using RestApiLearning.Dtos;
using RestApiLearning.Models;

namespace RestApiLearning.Endpoints;

public static class GameEndpoints
{
     /*private static readonly List<GameDto> games = [
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
    ];*/

    public static void MapGetEndpoints(this WebApplication app)
    {
      app.MapPost("/games", (GameDto cGame, RestApiContext dbContext) =>
      {
        Game game = new()
        {
          Title = cGame.Title,
          Genre = cGame.Genre,
          ReleaseDate = cGame.ReleaseDate
        };
        dbContext.Game.Add(game);
        dbContext.SaveChangesAsync();
        return Results.Created($"/games/{game.Id}", game);
      });
      app.MapGet("/games", (RestApiContext dbContext) =>
      {
        dbContext.Game.Select(g => new GameSummaryDto(
          g.Id,
          g.Title,
          g.Genre,
          g.ReleaseDate
        )).ToList();

        return Results.Ok(dbContext.Game);
      });

        //app.MapGet("/games/{id}", (int id) => games.Find(g => g.Id == id));

        /*app.MapPost("/games", (CreateGameDto newGame) =>
       {
         GameDto game = new(
        games.Count + 1,
        newGame.Title,
        newGame.Genre,
        newGame.ReleaseDate
        );
        games.Add(game);
        return Results.Created($"/games/{game.Id}", game);
      });*/

      /*app.MapDelete("/games/{id}", (int id) =>
      {
       var game = games.Find(g => g.Id == id);
       if (game is null)
       {
         return Results.NotFound();
       }
       games.Remove(game);
       return Results.NoContent();
      });*/
    }
}
