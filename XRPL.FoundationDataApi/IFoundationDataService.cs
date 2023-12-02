using XRPL.FoundationDataApi.Domain;
using XRPL.FoundationDataApi.Domain.Responses;
using XRPL.FoundationDataApi.Domain.Responses.ApiInfo;
using XRPL.FoundationDataApi.Domain.Responses.Dex;
using XRPL.FoundationDataApi.Domain.Responses.LedgerData;

namespace XRPL.FoundationDataApi;
public interface IFoundationDataService
{
    #region API info methods

    /// <summary>
    /// Returns a list of the available API versions
    /// </summary>
    /// <returns></returns>
    Task<BaseServerResponse<List<ApiVersion>>> GetApiVersion(CancellationToken Cancel);
    /// <summary>
    /// Returns information about the server
    /// </summary>
    /// <returns></returns>
    Task<BaseServerResponse<ServerInfo>> Ping(CancellationToken Cancel);

    #endregion

    #region DEX
    /// <summary>
    /// Retrieve an exchange rate for a given currency pair at a specific time.
    /// </summary>
    /// <param name="baseCurrency">Base currency of the pair as issuer address, followed by _ and a currency code. (Or XRP with no issuer.)</param>
    /// <param name="counterCurrency">Counter currency of the pair as issuer address, followed by _ and a currency code. (Or XRP with no issuer.)</param>
    /// <param name="date">Return an exchange rate for the specified time. The default is the current time.</param>
    /// <returns></returns>
    Task<BaseServerResponse<ExchangeRateInfo>> ExchangeRates(FoundationIssuedCurrency baseCurrency, FoundationIssuedCurrency counterCurrency, DateTime? date, CancellationToken Cancel);
    /// <summary>
    /// Retrieve Exchanges for a given currency pair over time.
    /// </summary>
    /// <param name="baseCurrency">Base currency of the pair as issuer address, followed by _ and a currency code. (Or XRP with no issuer.)</param>
    /// <param name="counterCurrency">Counter currency of the pair as issuer address, followed by _ and a currency code. (Or XRP with no issuer.)</param>
    /// <param name="start">Filter to this time and later</param>
    /// <param name="end">Filter to this time and earlier</param>
    /// <param name="descending">If true, return results in reverse chronological order.</param>
    /// <param name="skip">Skip a defined number of entries.</param>
    /// <param name="limit">Limit the entries in the response.</param>
    /// <returns></returns>
    Task<BaseServerResponse<List<ExchangeInfo>>> Exchanges(FoundationIssuedCurrency baseCurrency,
        FoundationIssuedCurrency counterCurrency, DateTime? start, DateTime? end,
        bool descending, int? skip, int? limit, CancellationToken Cancel);

    /// <summary>
    /// Retrieve market data for a given currency pair over time.
    /// </summary>
    /// <param name="intervar">Aggregation interval. Possible values are: s,m,h,d,M,y. As example: 1d to aggregate data by 1 day intervals. The default is non-aggregated results.</param>
    /// <param name="baseCurrency">Base currency of the pair as issuer address, followed by _ and a currency code. (Or XRP with no issuer.)</param>
    /// <param name="counterCurrency">Counter currency of the pair as issuer address, followed by _ and a currency code. (Or XRP with no issuer.)</param>
    /// <param name="start">Filter to this time and later</param>
    /// <param name="end">Filter to this time and earlier</param>
    /// <param name="descending">If true, return results in reverse chronological order.</param>
    /// <param name="skip">Skip a defined number of entries.</param>
    /// <param name="limit">Limit the entries in the response.</param>
    /// <returns></returns>
    Task<BaseServerResponse<List<MarketData>>> MarketData(FoundationIssuedCurrency baseCurrency,
        FoundationIssuedCurrency counterCurrency, MarketInterval intervar,
        DateTime? start, DateTime? end,
        bool descending, int? skip, int? limit, CancellationToken Cancel);

    #endregion

    #region Ledgers

    /// <summary>
    /// Returns supply information about the XRPL of the closest available ledger for the given time. <br/>
    /// ledger = ledger index of supply information <br/>
    /// closeTimeHuman = close time of the ledger in human readable time <br/>
    /// accounts = number of accounts <br/>
    /// xrpExisting = total number of existing XRP <br/>
    /// xrp.xrpTotalSupply = Circulating supply of XRP (Total amount of XRP in accounts minus account reserve and minus non transient reserves) <br/>
    /// xrp.xrpTotalBalance = Total amount of XRP in Accounts <br/>
    /// xrp.xrpTotalReserved = Total number of XRP reserved in Accounts and Objects <br/>
    /// xrp.xrpTotalTransientReserves = Total number of XRP in transient objects like Offers <br/>
    /// <param name="date">time</param>
    /// </summary>
    /// <returns></returns>
    Task<BaseServerResponse<SupplyInfo>> SupplyInfo(DateTime? date, CancellationToken Cancel);

    /// <summary>
    /// Retrieve the last closed ledger by a given time <br/>
    /// </summary>
    /// <param name="date">time</param>
    Task<BaseServerResponse<LedgerInfo>> LedgerIndex(DateTime? date, CancellationToken Cancel);
    /// <summary>
    /// Return the closed ledger by the specified ledger_index.
    /// </summary>
    /// <param name="ledgerIndex">ledger index</param>
    /// <returns></returns>
    Task<BaseServerResponse<LedgerClosed>> LedgerClosedTime(int ledgerIndex, CancellationToken Cancel);


    #endregion
}