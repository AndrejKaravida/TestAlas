using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Core.IRepository;
using TestApi.Core.Models;

namespace TestApi.Persistence
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly DataContext _context;
        public TranslationRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public List<TranslationResult> GetAllTranslation()
        {
            return _context.TranslationResults.ToList();
        }

        public TranslationResult GetTranslation(string text)
        {
            return _context.TranslationResults.Where(x => x.SerbianText == text).FirstOrDefault();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
