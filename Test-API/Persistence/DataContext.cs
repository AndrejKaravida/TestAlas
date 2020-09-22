using Microsoft.EntityFrameworkCore;
using TestApi.Core.Models;

namespace TestApi.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TranslationResult> TranslationResults { get; set; }

    }
}
