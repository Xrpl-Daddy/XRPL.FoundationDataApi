namespace XRPL.FoundationDataApi.Domain.Responses.Dex;

public class MarketInterval
{
    public int Value;

    public MarketIntervalType Type;

    #region Overrides of Object

    public override string ToString()
    {
        var type = Type switch
        {
            MarketIntervalType.second => "s",
            MarketIntervalType.minute => "m",
            MarketIntervalType.hour => "h",
            MarketIntervalType.day => "d",
            MarketIntervalType.month => "M",
            MarketIntervalType.year => "y",
            _ => throw new ArgumentOutOfRangeException()
        };
        return $"{Value}{type}";
    }

    #endregion
}