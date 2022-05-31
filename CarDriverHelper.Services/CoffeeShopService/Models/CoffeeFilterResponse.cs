namespace CarDriverHelper.Services.CoffeeShopService.Models
{
    public class CoffeeFilterResponse<T>
    {
        public IList<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}