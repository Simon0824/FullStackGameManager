using System;
using Microsoft.EntityFrameworkCore;

namespace RestApiLearning.Data;

public static class DataExtention
{
    public static void MigrationDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RestApiContext>();
        context.Database.Migrate();
    }
}
