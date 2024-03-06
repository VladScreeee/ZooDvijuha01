using ZooDvijuha.Data.Enum;

namespace ZooDvijuha.ViewModels
{
    public class CreateSubscriptionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SubscriptionLevel SubscriptionLevel { get; set; }
        public string AppUserId { get; set; }
    }
}
