using System;
using System.Collections.Generic;

namespace QuestLog.Models
{
    public interface IItemRepository
    {
        void Add(Objective item);
        void Update(Objective item);
        Objective Remove(string key);
        Objective Get(string id);
        IEnumerable<Objective> GetAll();
    }
}
