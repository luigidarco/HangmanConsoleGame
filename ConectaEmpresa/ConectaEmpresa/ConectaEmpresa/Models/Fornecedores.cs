using System.ComponentModel.DataAnnotations;

namespace ConectaEmpresa.Models
{   
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Cnpj_Cpf { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Cep { get; set; }

        [Required]
        public DateTime Data_nascimento { get; set; }

        [StringLength(20)]
        public string RG { get; set; }
    }
}


