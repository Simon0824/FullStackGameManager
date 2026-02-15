using System;

namespace RestApiLearning.Dtos;

public record class GameSummaryDto
(
    int Id,
    string Title,
    string Genre,
    DateOnly ReleaseDate
);



