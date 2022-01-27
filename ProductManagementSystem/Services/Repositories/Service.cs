using ProductManagementSystem.DBContext;

/*
 * Kodda Ef Core - Code First ile veri tabanı kurulumu gerçekleştirilmiştir.
 * Swagger eklentisiyle mevcut endpointler test edilebilir durumdadır.
 */

namespace ProductManagementSystem.Services.Repositories
{
    public class Service : IService
    {
        private readonly ICategoryDataAccess? _categoryDataAccess;
        private readonly IOrderDataAccess? _orderDataAccess;
        private readonly IOrderProductDataAccess? _orderProductDataAccess;
        private readonly IProductDataAccess? _productDataAccess;

        public Service
            (
            ICategoryDataAccess categoryDataAccess,
            IOrderDataAccess orderDataAccess,
            IOrderProductDataAccess orderProductDataAccess,
            IProductDataAccess productDataAccess
            )
        {
            _categoryDataAccess = categoryDataAccess;
            _orderDataAccess = orderDataAccess;
            _orderProductDataAccess = orderProductDataAccess;
            _productDataAccess = productDataAccess;
        }

        public List<Product>? GetProductsOfCategoryAndDescendants(int categoryID)
        {
            using var context = new ProductManagementSystemDbContext();
            var productList = context.Products;
            var subCategories = _categoryDataAccess?.GetSubCategories(categoryID);

            var filteredProducts = productList?.Where(x => x.CategoryID == categoryID).ToList();

            if (subCategories != null)
            {
                foreach (var item in subCategories)
                {
                    var tempList = productList?.Where(x => x.CategoryID == item.ID).ToList();

                    if (tempList != null)
                    {
                        filteredProducts?.AddRange(tempList);
                    }
                }
            }

            return filteredProducts;
        }

        public Entities.OrderStatistics GetOrderStatistics(List<Entities.Orders> orders)
        {
            // Burayı doldurun:
            // Verilen siparişlerin içinde, her bir kategoride toplam
            // kaç ürün satıldığını ve toplam ne kadarlık ürün
            // satıldığını hesaplayan kodu yazınız.


            /*
             * NOT: İstenilen Kod Hangi Kategoride Kaç adet ürün satıldığı ve toplam fiyatı ancak verilen entitylerde CategoryId göremedim. Bu yüzden CategoryId de ekledim.
             * Ancak CategoryId ile ekleme yapınca bigO n^3 ten daha etkin bir çözüm bulamadım.
             * Çünkü elimizde bilmediğimiz sayıda kategori var ve bunları gruplamak zorundayız. Ayrıca gelen requestte de Order List olduğu için bu listenin her bir elemanını da dönmek zorundayız.
             * Bu sebeplerden dolayı çok beğenmediğim ama çalışan bir çözüm sunduğumu düşünüyorum.
             * NOT2: Gelen requestte ürünün CategoryId değerinin doğru girildiği kabul edilmiştir.
             */

            var orderStatisticCategory = new Entities.OrderStatisticCategory();
            var orderStatistics = new Entities.OrderStatistics();

            foreach (var order in orders)
            {
                foreach (var product in order.Products.GroupBy(x => x.CategoryID))
                {
                    foreach (var item in product)
                    {
                        orderStatisticCategory.CategoryID = product.Key;
                        orderStatisticCategory.NumberOfProductsSold++;
                        orderStatisticCategory.TotalPriceOfProductsSold += Convert.ToDouble(_orderProductDataAccess.GetPriceByOrderAndProductId(order.OrderID, item.ID));
                    }

                    orderStatistics.Statistic.Add(orderStatisticCategory);
                    orderStatisticCategory = new Entities.OrderStatisticCategory();
                }
            }

            return orderStatistics;
        }
    }
}
