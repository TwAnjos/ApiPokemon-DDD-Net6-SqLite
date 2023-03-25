using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntitiesExternal
{
    public class SpeciesDetails
    {
        public EvolutionChain? evolution_chain { get; set; }
        public bool forms_switchable { get; set; }
        public int gender_rate { get; set; }
        public bool has_gender_differences { get; set; }
        public int hatch_counter { get; set; }
        public int id { get; set; }
        public bool is_baby { get; set; }
        public bool is_legendary { get; set; }
        public bool is_mythical { get; set; }
        public string? name { get; set; }
        public int order { get; set; }
        public Shape? shape { get; set; }
    }
}
