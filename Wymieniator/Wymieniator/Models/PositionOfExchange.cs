namespace Wymieniator.Models
{
    public class PositionOfExchange
    {
        public int PositionOfExchangeId { get; set; }
        public int ExchangeId { get; set; }
        public int BookId { get; set; }


        public virtual Book Book { get; set; }
        public virtual Exchange Exchange { get; set; }
    }
}