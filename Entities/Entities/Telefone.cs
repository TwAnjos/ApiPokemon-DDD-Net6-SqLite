using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Entities
{
    [Table("TB_TELEFONE")]
    public class Telefone
    {
        [Key]
        [Column("TLF_ID")]
        public int Id { get; set; }

        [Column("TLF_TELEFONE")]
        public string? NumeroTelefone { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column("TLF_USR_ID", Order = 1)]
        public string? UserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}