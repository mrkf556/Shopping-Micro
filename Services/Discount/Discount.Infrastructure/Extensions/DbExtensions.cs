using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.Infrastructure.Extensions;

public static class DbExtension
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var serviceProvider = scope.ServiceProvider;

        var configuration =
            serviceProvider.GetRequiredService<IConfiguration>();

        var logger =
            serviceProvider
                .GetRequiredService<ILoggerFactory>()
                .CreateLogger("DatabaseMigration");

        try
        {
            logger.LogInformation(
                "Starting database migration...");

            ApplyMigration(
                configuration,
                logger);

            logger.LogInformation(
                "Database migration completed successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "An error occurred during database migration.");

            throw;
        }

        return host;
    }

    private static void ApplyMigration(
        IConfiguration configuration,
        ILogger logger)
    {
        var connectionString =
            configuration["DatabaseSettings:ConnectionString"];

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Database connection string is not configured.");
        }

        var retry = 5;

        while (retry > 0)
        {
            try
            {
                using var connection =
                    new NpgsqlConnection(connectionString);

                connection.Open();

                using var command =
                    connection.CreateCommand();

                // Create Discounts table
                command.CommandText = """
                    CREATE TABLE IF NOT EXISTS Discounts
                    (
                        Id SERIAL PRIMARY KEY,
                        ProductId TEXT NOT NULL,
                        ProductName VARCHAR(500) NOT NULL,
                        Description TEXT,
                        Amount INT NOT NULL
                    );
                    """;

                command.ExecuteNonQuery();

                logger.LogInformation(
                    "Discounts table is ready.");

                // Seed 1
                command.CommandText = """
                    INSERT INTO Discounts
                    (
                        ProductName,
                        Description,
                        Amount,
                        ProductId
                    )
                    SELECT
                        'Adidas Quick Force Indoor Badminton Shoes',
                        'Shoe Discount',
                        500,
                        '602d2149e773f2a3990b47f5'
                    WHERE NOT EXISTS
                    (
                        SELECT 1
                        FROM Discounts
                        WHERE ProductId = '602d2149e773f2a3990b47f5'
                    );
                    """;

                command.ExecuteNonQuery();

                // Seed 2
                command.CommandText = """
                    INSERT INTO Discounts
                    (
                        ProductName,
                        Description,
                        Amount,
                        ProductId
                    )
                    SELECT
                        'Yonex VCORE Pro 100 A Tennis Racquet (270gm, Strung)',
                        'Racquet Discount',
                        700,
                        '992d2149e773f2a3990b47fa'
                    WHERE NOT EXISTS
                    (
                        SELECT 1
                        FROM Discounts
                        WHERE ProductId = '992d2149e773f2a3990b47fa'
                    );
                    """;

                command.ExecuteNonQuery();

                logger.LogInformation(
                    "Database seed completed.");

                break;
            }
            catch (Exception ex)
            {
                retry--;

                if (retry == 0)
                {
                    throw;
                }

                logger.LogWarning(
                    ex,
                    "Database is not ready. Retrying... Attempts left: {Retry}",
                    retry);

                Thread.Sleep(2000);
            }
        }
    }
}