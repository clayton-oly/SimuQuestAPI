using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuração do banco de dados
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SimuQuestDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ISimulatedExamRepository, SimulatedExamRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IOptionRepository, OptionRepository>();
builder.Services.AddScoped<ISimulatedResultRepository, SimulatedResultRepository>();
builder.Services.AddScoped<ISelectedOptionRepository, SelectedOptionRepository>();
builder.Services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
