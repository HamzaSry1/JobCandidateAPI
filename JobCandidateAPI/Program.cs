using JobCandidateAPI.Contracts.Const;
using JobCandidateAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("SqlCnx");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception(Messages.SqlConnectionException);
        }

        options.UseSqlServer(connectionString);
    });
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}