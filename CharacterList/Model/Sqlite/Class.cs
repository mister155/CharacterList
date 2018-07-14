using CharacterList.Data;
using SQLite;

namespace CharacterList.Model.Sqlite
{
    public class Class : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
