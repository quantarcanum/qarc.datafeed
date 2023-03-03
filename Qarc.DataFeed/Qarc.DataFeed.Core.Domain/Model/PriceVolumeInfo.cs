namespace Qarc.DataFeed.Core.Domain.Model
{
    public class PriceVolumeInfo
    {
        public decimal Volume { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public int Ticks { get; set; }
        public decimal Between { get; set; }
        public int Time { get; set; }
        public decimal Price { get; set; }
    }
}
