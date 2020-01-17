using System.Threading.Tasks;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public interface IProagilRepositorio
    {
         void Add<T>(T entity) where T : class;

         void Update<T>(T entity) where T : class;

         void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        #region Eventos
        Task<Evento[]> GetEventosAsyncByTema(string Tema, bool includePalestrantes);

        Task<Evento[]> GetEventosAsync(bool includePalestrantes);

        Task<Evento[]> GetEventoSyncById(int EventoId, bool includePalestrantes);
        
        #endregion

        #region Palestrantes

        Task<Evento[]> GetPalestrantesAsyncByName(bool includePalestrantes);

        Task<Evento> GetPalestranteAsync(int PalestranteId, bool includePalestrantes);

        #endregion



        
    }
}