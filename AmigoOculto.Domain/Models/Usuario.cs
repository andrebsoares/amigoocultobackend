using System;
using System.Collections.Generic;

namespace AmigoOculto.Domain.Models
{
    public class Usuario
    {
        public int Id{ get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Detalhes { get; set; }
        public virtual IEnumerable<GrupoUsuario> GrupoUsuarios { get; set; }
    }
}
