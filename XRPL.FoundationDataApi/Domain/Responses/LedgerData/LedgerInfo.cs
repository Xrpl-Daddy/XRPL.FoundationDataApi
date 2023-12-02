namespace XRPL.FoundationDataApi.Domain.Responses.LedgerData;

public class LedgerInfo
{
    public int ledger_index { get; set; }
    public DateTime closed { get; set; }
}