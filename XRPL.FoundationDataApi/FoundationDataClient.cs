using System.Collections.Generic;
using System.Text;
using XRPL.FoundationDataApi.Domain;
using XRPL.FoundationDataApi.Domain.Responses;
using XRPL.FoundationDataApi.Domain.Responses.ApiInfo;
using XRPL.FoundationDataApi.Domain.Responses.Dex;
using XRPL.FoundationDataApi.Domain.Responses.LedgerData;
using XRPL.TrustlineService;

namespace XRPL.FoundationDataApi;
/// <summary> client to connect to <a>https://data.xrplf.org/</a></summary>
public class FoundationDataClient : BaseXrplDataClient, IFoundationDataService
{
    public FoundationDataClient(bool waitWhenLimit, string apiKey, string BaseServiceAddress = "https://data.xrplf.org/") : base(waitWhenLimit, apiKey, BaseServiceAddress)
    {
    }

    #region Implementation of IFoundationDataService

    public async Task<BaseServerResponse<List<ApiVersion>>> GetApiVersion(CancellationToken Cancel)
    {
        if (!await CheckLimit(Cancel))
            return null;

        var response = await GetAsync<List<ApiVersion>>($"/v{ApiVersion}", Cancel);
        return response;
    }

    public async Task<BaseServerResponse<ServerInfo>> Ping(CancellationToken Cancel)
    {
        if (!await CheckLimit(Cancel))
            return null;

        var response = await GetAsync<ServerInfo>($"/v{ApiVersion}/ping", Cancel);
        return response;
    }

    public async Task<BaseServerResponse<ExchangeRateInfo>> ExchangeRates(
        FoundationIssuedCurrency baseCurrency, FoundationIssuedCurrency counterCurrency, DateTime? date, CancellationToken Cancel)
    {
        if (!await CheckLimit(Cancel))
            return null;
        var row = new StringBuilder($"/v{ApiVersion}/iou/exchange_rates/");
        row.Append($"{baseCurrency.ToRequestString()}/");
        row.Append(counterCurrency.ToRequestString());

        if (date is { } d)
        {
            row.Append($"?date={d:u}");
        }

        var response = await GetAsync<ExchangeRateInfo>(row.ToString(), Cancel);
        return response;
    }

    public async Task<BaseServerResponse<List<ExchangeInfo>>> Exchanges(
        FoundationIssuedCurrency baseCurrency, FoundationIssuedCurrency counterCurrency, DateTime? start, DateTime? end, bool descending, int? skip, int? limit,
        CancellationToken Cancel)
    {
        if (!await CheckLimit(Cancel))
            return null;
        var row = new StringBuilder($"/v{ApiVersion}/iou/exchanges/");
        row.Append($"{baseCurrency.ToRequestString()}/");
        row.Append(counterCurrency.ToRequestString());

        row.Append($"?descending={descending.ToString().ToLower()}");

        if (start is { } st)
        {
            row.Append($"&start={st:u}");
        }

        if (end is { } e)
        {
            row.Append($"&end={e:u}");
        }

        if (skip is { } s)
        {
            row.Append($"&skip={s}");
        }

        if (limit is { } l)
        {
            row.Append($"&limit={limit}");
        }

        var response = await GetAsync<List<ExchangeInfo>>(row.ToString(), Cancel);
        return response;
    }

    public async Task<BaseServerResponse<List<MarketData>>> MarketData(
        FoundationIssuedCurrency baseCurrency, FoundationIssuedCurrency counterCurrency, MarketInterval intervar, DateTime? start, DateTime? end, bool descending,
        int? skip, int? limit, CancellationToken Cancel)
    {
        if (!await CheckLimit(Cancel))
            return null;
        var row = new StringBuilder($"/v{ApiVersion}/iou/market_data/");
        row.Append($"{baseCurrency.ToRequestString()}/");
        row.Append(counterCurrency.ToRequestString());

        row.Append($"?descending={descending.ToString().ToLower()}");
        row.Append($"&interval={intervar.ToString()}");

        if (start is { } st)
        {
            row.Append($"&start={st:u}");
        }

        if (end is { } e)
        {
            row.Append($"&end={e:u}");
        }

        if (skip is { } s)
        {
            row.Append($"&skip={s}");
        }

        if (limit is { } l)
        {
            row.Append($"&limit={limit}");
        }

        var response = await GetAsync<List<MarketData>>(row.ToString(), Cancel);
        return response;
    }

    public async Task<BaseServerResponse<SupplyInfo>> SupplyInfo(DateTime? date, CancellationToken Cancel)
    {
        if (!await CheckLimit(Cancel))
            return null;
        var row = new StringBuilder($"/v{ApiVersion}/ledgers/supply_info");

        if (date is { } d)
        {
            row.Append($"?date={d:u}");
        }

        var response = await GetAsync<SupplyInfo>(row.ToString(), Cancel);
        return response;
    }

    public async Task<BaseServerResponse<LedgerInfo>> LedgerIndex(DateTime? date, CancellationToken Cancel)
    {
        if (!await CheckLimit(Cancel))
            return null;
        var row = new StringBuilder($"/v{ApiVersion}/ledgers/ledger_index");

        if (date is { } d)
        {
            row.Append($"?date={d:u}");
        }

        var response = await GetAsync<LedgerInfo>(row.ToString(), Cancel);
        return response;
    }

    public async Task<BaseServerResponse<LedgerClosed>> LedgerClosedTime(int ledgerIndex, CancellationToken Cancel)
    {
        if (!await CheckLimit(Cancel))
            return null;
        var row = new StringBuilder($"/v{ApiVersion}/ledgers/ledger_index");

        if (ledgerIndex is { } index)
        {
            row.Append($"?ledger_index={index}");
        }

        var response = await GetAsync<LedgerClosed>(row.ToString(), Cancel);
        return response;
    }

    #endregion
}
