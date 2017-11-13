using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication_ezconet.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [StringLength(200, ErrorMessage = "Nome nao pode ser maior que 200 caracteres. (Min: 3 | Max: 200)")]
        [Required(ErrorMessage = "Por vavor, coloque seu nome")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Por vavor, coloque sua data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [StringLength(100, ErrorMessage = "Email nao pode ser maior que 100 caracteres. (Min: 5 | Max: 100)")]
        [Required(ErrorMessage = "Por vavor, coloque seu email")]
        public String Email { get; set; }

        [StringLength(30, ErrorMessage = "A senha nao pode ter mais 30 caracteres.  (Min: 3 | Max: 30)")]
        [Required(ErrorMessage = "Por vavor, coloque uma senha")]
        public String Senha { get; set; }

        [Range(0,1, ErrorMessage = "Valor do status inválido!")]
        public int Ativo { get; set; }

        [Column("SexoId")]
        [Range(1,5, ErrorMessage ="Sexo não definido no BD!")]
        public int SexoId { get; set; }

        [ForeignKey("SexoId")]
        public virtual Sexo Sexo { get; set; }

    }
}