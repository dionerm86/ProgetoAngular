using Microsoft.EntityFrameworkCore;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Palestrante> Palestrantes { get; set; }

        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

        public DbSet<Lote> Lotes { get; set; }

        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
        }
    }
}