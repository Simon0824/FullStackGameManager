using System;

namespace RestApiLearning.Dtos;

public record class GameDto(
    int Id,
    string Title,
    string Genre,
    DateOnly ReleaseDate
);
