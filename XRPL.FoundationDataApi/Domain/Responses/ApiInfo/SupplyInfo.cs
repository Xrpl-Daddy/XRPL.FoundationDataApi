using XRPL.FoundationDataApi.Domain.Responses.LedgerData;

namespace XRPL.FoundationDataApi.Domain.Responses.ApiInfo;

public class SupplyInfo
{
    public int ledger { get; set; }
    public DateTime closeTimeHuman { get; set; }
    public int accounts { get; set; }
    public decimal xrpExisting { get; set; }
    public XrpInfo xrp { get; set; }
}