using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using PinsApp.Models;

namespace PinsApp.Services.Repository
{
	public class RepositoryService : IRepositoryService
	{
		SQLiteAsyncConnection asyncConnection;
		const string DB_NAME = "Users.db";

		public RepositoryService()
		{
			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME);
			asyncConnection = new SQLiteAsyncConnection(path);
			asyncConnection.CreateTableAsync<UserModel>();
			asyncConnection.CreateTableAsync<PinModel>();

		}

		public Task<List<T>> GetItemsAsync<T>() where T : class, new()
		{
			return asyncConnection.Table<T>().ToListAsync();
		}


		public async Task<int> DeleteItemAsync<T>(T item)
		{
			return await asyncConnection.DeleteAsync(item);
		}

		public async Task<int> AddAsync<T>(T item)
		{
			return await asyncConnection.InsertAsync(item);
		}
		public async Task<int> UpdateAsync<T>(T item)
		{
			return await asyncConnection.UpdateAsync(item);
		}
	}
}
