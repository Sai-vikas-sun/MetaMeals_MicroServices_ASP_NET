using AutoMapper;
using Meatmeals.Services.CouponAPI;
using Meatmeals.Services.CouponAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddConsole(); // Add console logging
builder.Logging.AddDebug(); // Add debug logging

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connString);

});

//AutoMapper Configuration to map Coupon Object to CouponDto and CouponDto to coupon Object
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ApplyMigration();

app.Run();

 void ApplyMigration()
{

    using (var scope = app.Services.CreateScope())
    {
        logger.LogInformation("In the ApplyMigration method");
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (db.Database.GetPendingMigrations().Count() > 0)
        {
            db.Database.Migrate();

        }
    }

    /*try
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            logger.LogInformation("Starting database initialization...");

            // This will create the database if it doesn't exist
            context.Database.EnsureCreated();

            // Check if we need to apply any migrations
            if (context.Database.GetPendingMigrations().Any())
            {
                logger.LogInformation("Applying pending migrations...");
                context.Database.Migrate();
            }

            // Force a refresh of the schema to reflect any changes in OnModelCreating
            // This will drop and recreate tables if schema has changed
            if (app.Environment.IsDevelopment())  // Only in development environment
            {
                logger.LogInformation("Ensuring database is up to date with current model...");
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            logger.LogInformation("Database initialization completed successfully.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while initializing the database.");
        throw;
    }*/


}
