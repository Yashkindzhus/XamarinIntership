using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace PinsApp.Repository
{
    public class RepositoruService : IRepositoryService
    {
        SQLiteAsyncConnection asyncConnection;
        const string DB_NAME = "Users.db";

        public RepositoruService()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME);
            asyncConnection = new SQLiteAsyncConnection(path);
            
        }
        
        public async Task<List<User>> GetItemsAsync()
        {
            await asyncConnection.CreateTableAsync<User>();
            return await asyncConnection.Table<User>().ToListAsync();

        }

        public async Task<int> DeleteItemAsync(User item)
        {
            await asyncConnection.CreateTableAsync<User>();
            return await asyncConnection.DeleteAsync(item);
        }

        public async Task<int> SaveItemAsync(User item)
        {
            await asyncConnection.CreateTableAsync<User>();
            if (item.Id != 0)
            {
                await asyncConnection.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await asyncConnection.InsertAsync(item);
            }
        }

        public async Task<bool> FindItem(string _Email, string _Password)
        {
            await asyncConnection.CreateTableAsync<User>();
            List<User> users = new List<User>();
            users = await GetItemsAsync();


            foreach (User user in users)
            {
                if ((_Email == user.Email) && (_Password == user.Password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
