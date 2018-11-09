namespace PackageMail.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Estados
    {
        [Key]
        public int EstadoId { get; set; }
        
        [Display(Name ="Estado")]
        public string Estado { get; set; }
        public virtual ICollection<Solicitudes> Solicitudes { get; set; }
    }
}