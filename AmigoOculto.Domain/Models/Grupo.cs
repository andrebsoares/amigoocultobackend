using System;
using System.Collections.Generic;

namespace AmigoOculto.Domain.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataHoraEntrega { get; set; }
        public string Observacao { get; set; }
        public virtual IEnumerable<GrupoUsuario> GrupoUsuarios { get; set; }
    }
}
