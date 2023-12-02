namespace XRPL.FoundationDataApi.Domain.Responses.LedgerData;

public class LedgerClosed
{
    public int ledger_index { get; set; }
    public DateTime closed { get; set; }
}