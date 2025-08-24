using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Data
{
    public class SimuQuestDbContext : DbContext
    {
        public SimuQuestDbContext(DbContextOptions<SimuQuestDbContext> options) : base(options) { }

        public DbSet<Exam> Exams { get; set; }
        //public DbSet<Question> Questoes { get; set; }
        //public DbSet<Option> Alternativas { get; set; }
        //public DbSet<SimuladoResult> SimuladoResults { get; set; }
        //public DbSet<AnsweredQuestion> QuestoesRespondidas { get; set; }
        //public DbSet<SelectedOption> AlternativasRespondidas { get; set; }
    }
}
