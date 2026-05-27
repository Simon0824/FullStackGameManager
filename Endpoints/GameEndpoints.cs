using Microsoft.EntityFrameworkCore;
using FullStackGameManager.Data;
using FullStackGameManager.Dtos;
using FullStackGameManager.Models;

namespace FullStackGameManager.Endpoints;

public static class GameEndpoints
{
    public static void MapGetEndpoints(this WebApplication app)
    {
      var GamesGroup =  app.MapGroup("/games");
      
      GamesGroup.MapPost("/", async (GameDto cGame, RestApiContext dbContext) =>
      {
        Game game = new()
        {
          Title = cGame.Title,
          Genre = cGame.Genre,
          Price = cGame.Price,
          ReleaseDate = cGame.ReleaseDate
        };
        bool gameExist = await dbContext.Game.AnyAsync(g =>
          g.Title == cGame.Title &&
          g.Genre == cGame.Genre &&
          g.Price == cGame.Price &&
          g.ReleaseDate == cGame.ReleaseDate
        );
        if(gameExist)
        {
          return Results.BadRequest("Game is already in db!");
        }
        dbContext.Game.Add(game);
        await dbContext.SaveChangesAsync();
        
        return Results.Created($"/{game.Id}", game);
      });

      GamesGroup.MapGet("/", async (RestApiContext dbContext) =>
      {
        var games = await dbContext.Game.Select(g => new GameSummaryDto(
          g.Id,
          g.Title,
          g.Genre,
          g.Price,
          g.ReleaseDate
        )).AsNoTracking().ToListAsync();

        return Results.Ok(games);
      });

      GamesGroup.MapPut("/{id}", async (int id, GameDto cGame, RestApiContext dbContext) =>
      {
        var game = dbContext.Game.Find(id);
        if (game is null)
        {
          return Results.NotFound();
        }

        game.Title = cGame.Title;
        game.Genre = cGame.Genre;
        game.Price = cGame.Price;
        game.ReleaseDate = cGame.ReleaseDate;

        await dbContext.SaveChangesAsync();
        return Results.Ok(game);
      });

      GamesGroup.MapDelete("/{id}", async (int id, RestApiContext dbContext) =>
      {
        var game = dbContext.Game.Find(id);
        if (game is not null)
        {
          dbContext.Game.Remove(game);
        }
        else
        {
          return Results.NotFound();
        }
        await dbContext.SaveChangesAsync();
        return Results.NoContent();
      });
    }
}
