namespace ProductManagementSystem.Entities
{
    public class OrderStatistics
    {
        public List<OrderStatisticCategory> Statistic { get; set; }

        public OrderStatistics()
        {
            this.Statistic = new List<OrderStatisticCategory>();
        }
    }
}
