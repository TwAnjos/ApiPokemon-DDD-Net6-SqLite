using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntitiesExternal
{
    public class EvolvesTo
    {
        public List<EvolvesTo> evolves_to { get; set; }
        public bool is_baby { get; set; }
        public Species species { get; set; }
    }
}
