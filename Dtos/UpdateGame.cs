using System;
using System.ComponentModel.DataAnnotations;
namespace RestApiLearning.Dtos;

public record class UpdateGame(
    int Id,
    [Required] [StringLength(30)] string Title,
    [Required]string Genre,
    [Range(0.01, 100)] decimal Price,
    [Required]DateOnly ReleaseDate
);
