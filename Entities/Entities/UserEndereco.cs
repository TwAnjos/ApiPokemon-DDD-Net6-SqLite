using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_USER_ENDERECO")]
    public class UserEndereco
    {
        [Key]
        [Column("END_ID")]
        public int Id { get; set; }

        [Column("END_ENDERECO")]
        public string? Endereco { get; set; }

        [Column("END_CEP")]
        public string? CEP { get; set; }

        [Column("END_PAIS")]
        public string? Pais { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [Column("END_MUNICIPIO")]
        public string? Municipio { get; set; }

        [Column("END_NUMERO")]
        public string? Numero { get; set; }

        [Column("END_COMPLEMENTO")]
        public string? Complemento { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column("END_USR_ID", Order = 1)]
        public string? UserId { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}