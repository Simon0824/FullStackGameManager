using RestApiLearning.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<GameDto> games = [
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

app.Run();
