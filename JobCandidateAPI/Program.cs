using JobCandidateAPI.Contracts.Const;
using JobCandidateAPI.Data;
using JobCandidateAPI.Repository.Candidates;
using JobCandidateAPI.Services.Candidates;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    //Registration services

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

    builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
    builder.Services.AddScoped<ICandidateService, CandidateService>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}