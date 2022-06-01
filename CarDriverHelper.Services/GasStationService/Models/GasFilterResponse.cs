namespace CarDriverHelper.Services.GasStationService.Models
{
    public class GasFilterResponse<T>
    {
        public IList<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}