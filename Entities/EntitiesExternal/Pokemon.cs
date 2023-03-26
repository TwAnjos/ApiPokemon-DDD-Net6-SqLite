namespace Entities.EntitiesExternal
{
    public class Pokemon
    {
        public int id { get; set; }
        public int order { get; set; }
        public string name { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public List<Type> types { get; set; }
        public List<Ability> abilities { get; set; }
        public bool is_default { get; set; }
        public Sprites sprites { get; set; }
        public string location_area_encounters { get; set; }
        public Species species { get; set; }
        public List<Species> evolutions { get; set; }
        public byte[] spriteBase64 { get; set; }
    }
}