namespace XRPL.FoundationDataApi.Domain.Responses.Dex;

public class ExchangeRateInfo
{
    public decimal rate { get; set; }
    public int ledger_index { get; set; }
    public string tx_hash { get; set; }
    public DateTime timestamp { get; set; }
}