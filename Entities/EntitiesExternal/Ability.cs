using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntitiesExternal
{
    public class Ability
    {
        public AbilityDetails ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }
}
