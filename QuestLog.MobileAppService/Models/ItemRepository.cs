using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace QuestLog.Models
{
    public class ItemRepository : IItemRepository
    {
        private static ConcurrentDictionary<string, Objective> items =
            new ConcurrentDictionary<string, Objective>();

        public ItemRepository()
        {
            Add(new Objective { Id = Guid.NewGuid().ToString(), Text = "Quest 1", Description = "This is an item description.", Category = ObjectiveType.Quest });
            Add(new Objective { Id = Guid.NewGuid().ToString(), Text = "Achievement 2", Description = "This is an item description.", Category = ObjectiveType.Achievement });
            Add(new Objective { Id = Guid.NewGuid().ToString(), Text = "Challenge 3", Description = "This is an item description.", Category = ObjectiveType.Challenge });
        }

        public Objective Get(string id)
        {
            return items[id];
        }

        public IEnumerable<Objective> GetAll()
        {
            return items.Values;
        }

        public void Add(Objective item)
        {
            item.Id = Guid.NewGuid().ToString();
            items[item.Id] = item;
        }

        public Objective Find(string id)
        {
            Objective item;
            items.TryGetValue(id, out item);

            return item;
        }

        public Objective Remove(string id)
        {
            Objective item;
            items.TryRemove(id, out item);

            return item;
        }

        public void Update(Objective item)
        {
            items[item.Id] = item;
        }
    }
}
