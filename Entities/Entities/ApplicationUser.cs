using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public char? Genero { get; set; }

        [Column("USR_TIPO")]
        public TipoUsuario? Tipo { get; set; }

        [Required]
        [Column("USR_DT_NASCIMENTO")]
        public DateTime DtNascimento { get; set; }


        [Column("USR_TELEFONE")]
        public virtual ICollection<Telefone>? Telefones { get; set; }

        [Column("USR_ENDERECOS")]
        public virtual ICollection<UserEndereco>? User_Enderecos { get; set; }
    }
}
