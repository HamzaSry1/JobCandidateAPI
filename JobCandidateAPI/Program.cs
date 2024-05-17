using JobCandidateAPI.Contracts.Const;
using JobCandidateAPI.Data;
using JobCandidateAPI.Repository.Candidates;
using JobCandidateAPI.Services.Candidates;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Registration services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlCnx");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new Exception(Messages.SqlConnectionException);
    }

    options.UseSqlServer(connectionString);
});


// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register repositories and services
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
