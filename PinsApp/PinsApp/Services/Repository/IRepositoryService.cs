using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using PinsApp.Models;

namespace PinsApp.Services.Repository
{
	public interface IRepositoryService
	{
		Task<List<T>> GetItemsAsync<T>() where T : class, new();

		Task<int> DeleteItemAsync<T>(T item);

		Task<int> AddAsync<T>(T item);

		Task<int> UpdateAsync<T>(T item);
	}
}
