using CharacterList.Data;
using SQLite;

namespace CharacterList.Model.Sqlite
{
    public class Class : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
