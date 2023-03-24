using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_USER")]
    public class ApplicationUser : IdentityUser
    {
        [Column("USR_CPF", TypeName = "VARCHAR(11)")]
        public string? CPF { get; set; }

        [Column("USR_RG", TypeName = "VARCHAR(11)")]
        public string? RG { get; set; }

        [Column("USR_IDADE")]
        public int? Idade { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        [Column("USR_GENERO")]
        public Genero? Genero { get; set; }

        [Column("USR_TIPO")]
        public TipoUsuario? Tipo { get; set; }

        [Required]
        [Column("USR_DT_NASCIMENTO")]
        public DateTime DtNascimento { get; set; }

        [ForeignKey("TB_TELEFONE")]
        [Column("USR_TELEFONE", Order = 1)]
        public Telefone? Telefone { get; set; }

        [ForeignKey("TB_USER_ENDERECO")]
        [Column("USR_ENDERECOS", Order = 1)]
        public UserEndereco? User_Endereco { get; set; }
    }
}