using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Models;

namespace QuestLog.Services
{
    public class MockDataStore : IDataStore<Objective>
    {
        List<Objective> items;

        public MockDataStore()
        {
            items = new List<Objective>();
            var mockItems = new List<Objective>
            {
                new Objective { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Objective { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Objective { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Objective { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Objective { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Objective { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Objective item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Objective item)
        {
            var oldItem = items.Where((Objective arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Objective arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Objective> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Objective>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}