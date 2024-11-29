using BurguerAndBeer.Mobile.Data;
using BurguerAndBeer.Mobile.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.Services
{
    public class DatabaseService : IAsyncDisposable
    {
        private const string DatabaseName = "BurguerAndBeer.db3";

        private static readonly string _databasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseName);

        private SQLiteAsyncConnection? _connection;
        private SQLiteAsyncConnection Database => _connection ??= new SQLiteAsyncConnection(_databasePath,
                                                  SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);

        public async Task<int> AddCartItem(CartItemEntity entity)
        {
            await Database.CreateTableAsync<CartItemEntity>();        
            await Database.InsertAsync(entity);

            return entity.Id;
        }

        public async Task UpdateCartItem(CartItemEntity entity)
        {
            await Database.CreateTableAsync<CartItemEntity>();
            await Database.UpdateAsync(entity);
        }

        public async Task<CartItemEntity> GetCartItemAsync(CartItem cartItem)
        {
            await Database.CreateTableAsync<CartItemEntity>();
            return await Database.Table<CartItemEntity>()
                                 .Where(item => item.ItemId == cartItem.ItemId && item.CategoryId == cartItem.CategoryId)
                                 .FirstOrDefaultAsync();
        }

        public async Task DeleteCartItemAsync(CartItemEntity entity)
        {
            await Database.CreateTableAsync<CartItemEntity>();
            await Database.DeleteAsync(entity);        
        }

        public async Task<List<CartItemEntity>> GetAllCartItemsAsync()
        {
            await Database.CreateTableAsync<CartItemEntity>();
            return await Database.Table<CartItemEntity>().ToListAsync();
        }

        public async Task ClearCartAsync()=> await Database.DeleteAllAsync<CartItemEntity>();      

        public async ValueTask DisposeAsync()
        {
            await _connection?.CloseAsync();
        }
    }
}
