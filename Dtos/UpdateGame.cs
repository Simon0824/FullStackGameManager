using System;

namespace RestApiLearning.Dtos;

public record class UpdateGame(
    int Id,
    string Title,
    string Genre,
    DateOnly ReleaseDate
);
