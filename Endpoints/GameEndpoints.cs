using System;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RestApiLearning.Data;
using RestApiLearning.Dtos;
using RestApiLearning.Models;

namespace RestApiLearning.Endpoints;

public static class GameEndpoints
{

    public static void MapGetEndpoints(this WebApplication app)
    {

      app.MapPost("/games", (GameDto cGame, RestApiContext dbContext) =>
      {
        Game game = new()
        {
          Title = cGame.Title,
          Genre = cGame.Genre,
          Price = cGame.Price,
          ReleaseDate = cGame.ReleaseDate
        };
        foreach(var gamee in dbContext.Game)
        {
          if(cGame.Title == gamee.Title && cGame.Genre == game.Genre && cGame.Price == gamee.Price && cGame.ReleaseDate == gamee.ReleaseDate)
          {
            return Results.BadRequest("Game is already in db!");
          }
        }
        dbContext.Game.Add(game);
        dbContext.SaveChanges();
        
        return Results.Created($"/games/{game.Id}", game);
      });

      app.MapGet("/games", (RestApiContext dbContext) =>
      {
        var games = dbContext.Game.Select(g => new GameSummaryDto(
          g.Id,
          g.Title,
          g.Genre,
          g.Price,
          g.ReleaseDate
        )).ToList();

        return Results.Ok(games);
      });

      app.MapPut("/games/{id}", (int id, GameDto cGame, RestApiContext dbContext) =>
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

        dbContext.SaveChanges();
        return Results.Ok(game);
      });

      app.MapDelete("/games/{id}", (int id, RestApiContext dbContext) =>
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
        dbContext.SaveChanges();
        return Results.NoContent();
      });
    }
}
