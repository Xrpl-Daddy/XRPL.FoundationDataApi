using Newtonsoft.Json;
using XRPL.FoundationDataApi;
using XRPL.FoundationDataApi.Domain;
using XRPL.FoundationDataApi.Domain.Responses;
using XRPL.FoundationDataApi.Domain.Responses.Dex;

var api_key = "";
var client = new FoundationDataClient(true, api_key); //create client
client.OnWaitAction += Console.WriteLine;

void Print<T>(BaseServerResponse<T> response)
{
    Console.WriteLine(JsonConvert.SerializeObject(response.ErrorInfo is null ? response.Data : response.ErrorInfo));
}

var baseCurrency = new FoundationIssuedCurrency()
{
    CurrencyCode = "MAG",
    Issuer = "rXmagwMmnFtVet3uL26Q2iwk287SRvVMJ"
};
var counterCurrency = new FoundationIssuedCurrency();
while (true)
{
    var api = await client.GetApiVersion(default);
    Print(api);
    var ping = await client.Ping(default);
    Print(ping);

    var exchangeRates = await client.ExchangeRates(
        baseCurrency,
        counterCurrency, null, default);
    Print(exchangeRates);
    exchangeRates = await client.ExchangeRates(
        baseCurrency,
        counterCurrency, DateTime.UtcNow - TimeSpan.FromDays(1), default);
    Print(exchangeRates);

    var exchanges = await client.Exchanges(
        baseCurrency,
        counterCurrency, null, null, false, 0, 10, default);
    Print(exchanges);

    exchanges = await client.Exchanges(
        baseCurrency,
        counterCurrency, DateTime.UtcNow - TimeSpan.FromDays(5), null, false, 0, 10, default);
    Print(exchanges);


    var market = await client.MarketData(
        baseCurrency,
        counterCurrency, new MarketInterval() { Type = MarketIntervalType.day, Value = 1 },
        DateTime.UtcNow - TimeSpan.FromDays(5), null, false, 0, 10, default);
    Print(market);

    var supplyInfo = await client.SupplyInfo(null, default);
    Print(supplyInfo);

    supplyInfo = await client.SupplyInfo(DateTime.UtcNow - TimeSpan.FromDays(2), default);
    Print(supplyInfo);

    var ledgerIndex = await client.LedgerIndex(null, default);
    Print(ledgerIndex);

    var ledgerClosedTime = await client.LedgerClosedTime(ledgerIndex.Data.ledger_index, default);
    Print(ledgerClosedTime);


    var data = await ledgerClosedTime.Response.Content.ReadAsStringAsync();
    var headers = ledgerClosedTime.Response.Headers.Concat(ledgerClosedTime.Response.Content.Headers);
    Console.WriteLine("Wait");
    await Task.Delay(5000);
}


Console.ReadLine();