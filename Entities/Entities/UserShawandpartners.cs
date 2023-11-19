using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("UserShawandpartners")]
    public class UserShawandpartners
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("Favorite_sport")]
        public string Favorite_sport { get; set; }
    }
}