using System;
using System.Collections.Generic;
using ProAgil.Dominio;

namespace ProAgil.Dominio
{
    public class Evento
    {
        public int Id { get; set; }

        public string Local { get; set; }

        public DateTime DataEnvio { get; set; }

        public string Tema { get; set; }

        public int QtdPessoas { get; set; }

        public string imagemURL { get; set; }

        public string Email { get; set; }
        
        public string Telefone { get; set; }

        public List<Lote> Lotes { get; set; }

        public List<RedeSocial> RedesSociais { get; set; }

        public List<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}