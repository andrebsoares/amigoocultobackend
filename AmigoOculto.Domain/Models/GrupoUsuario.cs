namespace AmigoOculto.Domain.Models
{
    public class GrupoUsuario
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
        public int AmigoId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
