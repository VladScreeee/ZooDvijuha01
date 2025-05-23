﻿using ZooDvijuha.Data.Enum;

namespace ZooDvijuha.ViewModels
{
    public class EditSubscriptionViewModel
    {
        internal readonly string AppUserId;

        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public SubscriptionLevel SubscriptionLevel { get; set; }
    }
}
