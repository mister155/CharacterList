using CharacterList.Data;
using SQLite;

namespace CharacterList.Model.Sqlite
{
    public class Item : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string SpecialTraits { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; }
    }
}
