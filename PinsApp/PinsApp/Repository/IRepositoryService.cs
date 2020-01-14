using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace PinsApp.Repository
{
    public interface IRepositoryService
    {
        Task<List<User>> GetItemsAsync();

        Task<int> DeleteItemAsync(User  item);

        Task<int> SaveItemAsync(User  item);

        Task<bool> FindItem(string _Email, string _Password);
    }
}
