using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Core.Models;

namespace TestApi.Core.IRepository
{
    public interface ITranslationRepository 
    {
        Task<bool> SaveAsync();
        void Add<T>(T entity) where T : class;
        TranslationResult GetTranslation(string text);
        List<TranslationResult> GetAllTranslation();
    }
}
