using System;
using Microsoft.EntityFrameworkCore;
using RestApiLearning.Models;

namespace RestApiLearning.Data;

public class RestApiContext(DbContextOptions<RestApiContext> options) : DbContext(options)
{
        public DbSet<Game> Game => Set<Game>();
}
