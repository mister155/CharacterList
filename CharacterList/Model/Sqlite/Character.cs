using System;
using CharacterList.Data;
using SQLite;

namespace CharacterList.Model.Sqlite
{
    public class Character : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Faction { get; set; }
        public string Race { get; set; }
        public string MagicType { get; set; }
        public string SoulColor { get; set; }
        public int Height { get; set; }
        public string HairColor { get; set; }
        public string EyesColor { get; set; }
    }
}
