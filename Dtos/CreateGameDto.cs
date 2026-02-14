using System;

namespace RestApiLearning.Dtos;

public record class CreateGameDto(
    int Id,
    string Title,
    string Genre,
    DateOnly ReleaseDate
);
