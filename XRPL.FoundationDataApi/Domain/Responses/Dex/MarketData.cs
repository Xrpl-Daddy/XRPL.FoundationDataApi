namespace XRPL.FoundationDataApi.Domain.Responses.Dex;

public class MarketData
{
    public decimal base_volume { get; set; }
    public decimal close { get; set; }
    public DateTime timestamp { get; set; }
    public decimal counter_volume { get; set; }
    public decimal high { get; set; }
    public decimal low { get; set; }
    public decimal open { get; set; }
    public int exchanges { get; set; }
}