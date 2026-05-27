using Microsoft.EntityFrameworkCore;
using FullStackGameManager.Models;

namespace FullStackGameManager.Data;

public class RestApiContext(DbContextOptions<RestApiContext> options) : DbContext(options)
{
        public DbSet<Game> Game => Set<Game>();
}
