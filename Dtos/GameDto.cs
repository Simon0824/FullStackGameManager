using System;
using System.ComponentModel.DataAnnotations;

namespace RestApiLearning.Dtos;

public record class GameDto(
    [Required] [StringLength(30)]string Title,
    [Required] string Genre,
    [Required]DateOnly ReleaseDate
);
