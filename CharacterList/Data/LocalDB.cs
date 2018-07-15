using CharacterList.Model.Sqlite;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharacterList.Data
{
    public class LocalDb
    {
        readonly SQLiteAsyncConnection _database;

        public LocalDb(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>().Wait();
            _database.CreateTableAsync<Character>().Wait();
        }

        public async Task<List<T>> GetItems<T>() where T : class, new()
        {
            return await _database.Table<T>().ToListAsync();
        }

        public async Task<List<Item>> GetItemsByClassId(int id)
        {
            return await _database.Table<Item>().Where(x => x.CharacterId == id).ToListAsync();
        }

        public async Task<T> GetItemById<T>(int id) where T : class, ISqliteModel, new()
        {
            return await _database.Table<T>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItem<T>(T item)
        {
            var result = await _database.UpdateAsync(item);

            if (result == 0)
                result = await _database.InsertAsync(item);

            return result;
        }

        public async Task<int> DeleteItem<T>(T item)
        {
            return await _database.DeleteAsync(item);
        }
    }
}
