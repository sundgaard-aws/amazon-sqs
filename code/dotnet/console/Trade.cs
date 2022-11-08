namespace Amazon.SQS.Demo
{
    public class Trade
    {
        public string TradeGUID { get; set; }
        public string? TradeType { get; set; }
        public int TradeAmount { get; set; }
        public DateTime TradeDate { get; set; }
        public string? CounterpartyId { get; set; }
    }
}