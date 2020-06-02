using System.Threading.Tasks;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public class ProAgilRepositorio : IProagilRepositorio
    {
        private readonly DataContext _context;

        public ProAgilRepositorio(DataContext context)
        {
            _context = context;             
        }

        public ProAgilRepositorio(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lote)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(p => p.Paletrante);
            }

            query = query.OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetEventosAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lote)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(p => p.Paletrante);
            }

            query = query
            .OrderByDescending(c => c.DataEvento)
            .where(c => tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetEventoSyncById(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lote)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(p => p.Paletrante);
            }

            query = query
            .OrderByDescending(c => c.DataEvento)
            .where(c => c.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public Task<Paletrante> GetPalestranteAsync(int PalestranteId, bool includeEvento = false)
        {
            IQueryable<Paletrante> query = _context.Paletrante
            .Include(c => c.RedesSociais);

            if(includeEvento)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query
            .OrderBy(p => p.Nome)
            .where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Paletrante[]> GetPalestrantesAsyncByName(string name, bool includeEvento = false)
        {
            IQueryable<Paletrante> query = _context.Paletrante
            .Include(c => c.RedesSociais);

            if(includeEvento)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query.Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}