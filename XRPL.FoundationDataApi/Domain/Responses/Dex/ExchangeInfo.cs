namespace XRPL.FoundationDataApi.Domain.Responses.Dex;

public class ExchangeInfo
{
    public decimal base_amount { get; set; }
    public decimal counter_amount { get; set; }
    public decimal rate { get; set; }
    public string buyer { get; set; }
    public DateTime executed_time { get; set; }
    public int ledger_index { get; set; }
    public string provider { get; set; }
    public string seller { get; set; }
    public string taker { get; set; }
    public string tx_hash { get; set; }
}