using System.Text.Json.Serialization;

using XRPL.TrustlineService;

namespace XRPL.FoundationDataApi.Domain;
public class FoundationIssuedCurrency
{
    /// <summary>
    /// Readable currency name 
    /// </summary>
    [JsonIgnore]
    public string CurrencyValidName => CurrencyCode is { Length: > 0 } row ? row.Length > 3 ? row.FromHexString().Trim('\0') : row : string.Empty;
    public string CurrencyCode { get; set; } = "XRP";
    public string Issuer { get; set; }

    internal string ToRequestString() => string.IsNullOrWhiteSpace(Issuer) ? CurrencyCode : $"{Issuer}_{CurrencyCode}";
}
