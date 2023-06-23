using System.ComponentModel.DataAnnotations;

namespace ConectaEmpresa.Models
{
    public class Empresas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome_fantasia { get; set; }

        [Required]
        [StringLength(10)]
        public string Cep { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }
    }
}
