using System.Threading.Tasks;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public interface IProagilRepositorio
    {
        //Geral
         void Add<T>(T entity) where T : class;

         void Update<T>(T entity) where T : class;

         void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        #region Eventos
        Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes);

        Task<Evento[]> GetAllEventosAsync(int eventoId, bool includePalestrantes);

        Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes);
        
        #endregion

        #region Palestrantes

        Task<Palestrante[]> GetPalestrantesAsyncByName(string name, bool IncludeEvento);

        Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includePalestrantes);

        #endregion



        
    }
}