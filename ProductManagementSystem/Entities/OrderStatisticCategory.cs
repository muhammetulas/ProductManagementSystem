namespace ProductManagementSystem.Entities
{
    public class OrderStatisticCategory
    {
        public int CategoryID { get; set; }
        public int NumberOfProductsSold { get; set; }
        public double TotalPriceOfProductsSold { get; set; }

        public OrderStatisticCategory()
        {
            this.NumberOfProductsSold = 0;
            this.TotalPriceOfProductsSold = 0;
        }

    }
}
