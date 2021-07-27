using System.Threading.Tasks;
using AnimeViews.models;

namespace AnimeViews.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Anime[]> GetAllAnimesAsync(bool includePessoa);
        Task<Anime> GetAnimeAsyncById(int AnimeId, bool includePessoa);

        Task<Pessoa[]> GetAllPessoasAsync(bool includeAnime);
        Task<Pessoa> GetPessoaAsyncById(int PessoaId, bool includeAnime);
    }
}