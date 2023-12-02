namespace XRPL.FoundationDataApi.Domain.Responses.LedgerData;

public class XrpInfo
{
    public decimal xrpTotalSupply { get; set; }
    public decimal xrpTotalBalance { get; set; }
    public decimal xrpTotalReserved { get; set; }
    public decimal xrpTotalTransientReserves { get; set; }
}