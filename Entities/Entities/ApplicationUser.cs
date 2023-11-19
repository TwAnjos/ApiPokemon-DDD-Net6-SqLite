using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{

    public class ApplicationUser : IdentityUser
    {
        [Column("USR_CPF", TypeName = "VARCHAR(11)")]
        public string CPF { get; set; }

        [Column("USR_RG", TypeName = "VARCHAR(11)")]
        public string RG { get; set; }

        [Column("USR_IDADE")]
        public int Idade { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        [Column("USR_GENERO")]
        public Genero? Genero { get; set; }

        [Column("USR_TIPO")]
        public TipoUsuario Tipo { get; set; }

        [Required]
        [Column("USR_DT_NASCIMENTO")]
        public DateTime DtNascimento { get; set; }

        [Column("USR_TELEFONE_ID")]
        public virtual Telefone Telefone { get; set; }

        [Column("USR_ENDERECOS_ID")]
        public virtual UserEndereco User_Endereco { get; set; }
    }
}