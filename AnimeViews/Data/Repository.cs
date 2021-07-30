using System.Linq;
using System.Threading.Tasks;
using AnimeViews.models;
using Microsoft.EntityFrameworkCore;

namespace AnimeViews.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        
        public Repository(DataContext contex)
        {
            _context = contex;
        }

        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<Anime[]> GetAllAnimesAsync(bool includePessoa)
        {
            IQueryable<Anime> query = _context.Animes;

            query = query   
                    .AsNoTracking()
                    .OrderBy(anime => anime.AnimeId);

            return await query.ToArrayAsync();
        }

        public async Task<Anime> GetAnimeAsyncById(int AnimeId, bool includePessoa)
        {
           IQueryable<Anime> query = _context.Animes;
    
            query = query   
                    .AsNoTracking()
                    .OrderBy(anime => anime.AnimeId)
                    .Where(anime => anime.AnimeId == AnimeId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa[]> GetAllPessoasAsync(bool includeAnime)
        {
             IQueryable<Pessoa> query = _context.Pessoas;

            query = query   
                    .AsNoTracking()
                    .OrderBy(pessoa => pessoa.PessoaId);

            return await query.ToArrayAsync();
        }

        public async Task<Pessoa> GetPessoaAsyncById(int PessoaId, bool includeAnime)
        {
            IQueryable<Pessoa> query = _context.Pessoas;

            query = query   
                    .AsNoTracking()
                    .OrderBy(pessoa => pessoa.PessoaId)
                    .Where(pessoa => pessoa.PessoaId == PessoaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<AnimePessoa> GetAnimePessoaAsyncById(AnimePessoa AnimePessoa)
        {
         IQueryable<AnimePessoa> query = _context.AnimesPessoas;
    
                query = query   
                        .AsNoTracking()
                        .Where(ap => ap.AnimeId == AnimePessoa.AnimeId && ap.PessoaId ==  AnimePessoa.PessoaId);
                
            return await query.FirstOrDefaultAsync();
        }
    }
}