using System;

using QuestLog.Models;

namespace QuestLog.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Objective Item { get; set; }
        public ItemDetailViewModel(Objective item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
