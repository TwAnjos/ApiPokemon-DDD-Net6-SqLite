using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("TB_POKEMONS_CAPTURADOS")]
    public class PokemonsCapturados: Notifies
    {
        [Key]
        [Column("PKM_ID")]
        public int Id { get; set; }

        [Column("PKM_ID")]
        public int PokemonId { get; set; }

        [Column("PKM_NOME")]
        public string PokemonName { get; set;}

        [Column("PKM_ATIVO")]
        public bool Ativo { get; set; }

        [Column("PKM_DATA_CAPTURADO")]
        public DateTime DataCapturado { get; set; }

        [Column("PKM_DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column("PKM_USR_ID", Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
