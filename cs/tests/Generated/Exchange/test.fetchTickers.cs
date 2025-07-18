using ccxt;
namespace Tests;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


public partial class testMainClass : BaseTest
{
    async static public Task<object> testFetchTickers(Exchange exchange, object skippedProperties, object symbol)
    {
        object withoutSymbol = testFetchTickersHelper(exchange, skippedProperties, null);
        object withSymbol = testFetchTickersHelper(exchange, skippedProperties, new List<object>() {symbol});
        object results = await promiseAll(new List<object>() {withoutSymbol, withSymbol});
        testFetchTickersAmounts(exchange, skippedProperties, getValue(results, 0));
        return results;
    }
    async static public Task<object> testFetchTickersHelper(Exchange exchange, object skippedProperties, object argSymbols, object argParams = null)
    {
        argParams ??= new Dictionary<string, object>();
        object method = "fetchTickers";
        object response = await exchange.fetchTickers(argSymbols, argParams);
        assert((response is IDictionary<string, object>), add(add(add(add(add(add(exchange.id, " "), method), " "), exchange.json(argSymbols)), " must return an object. "), exchange.json(response)));
        object values = new List<object>(((IDictionary<string,object>)response).Values);
        object checkedSymbol = null;
        if (isTrue(isTrue(!isEqual(argSymbols, null)) && isTrue(isEqual(getArrayLength(argSymbols), 1))))
        {
            checkedSymbol = getValue(argSymbols, 0);
        }
        testSharedMethods.assertNonEmtpyArray(exchange, skippedProperties, method, values, checkedSymbol);
        for (object i = 0; isLessThan(i, getArrayLength(values)); postFixIncrement(ref i))
        {
            // todo: symbol check here
            object ticker = getValue(values, i);
            testTicker(exchange, skippedProperties, method, ticker, checkedSymbol);
        }
        return response;
    }
    public static void testFetchTickersAmounts(Exchange exchange, object skippedProperties, object tickers)
    {
        object tickersValues = new List<object>(((IDictionary<string,object>)tickers).Values);
        if (!isTrue((inOp(skippedProperties, "checkActiveSymbols"))))
        {
            //
            // ensure all "active" symbols have tickers
            //
            object nonInactiveMarkets = testSharedMethods.getActiveMarkets(exchange);
            object notInactiveSymbolsLength = getArrayLength(nonInactiveMarkets);
            object obtainedTickersLength = getArrayLength(tickersValues);
            object toleranceCoefficient = 0.01; // 1% tolerance, eg. when 100 active markets, we should have at least 99 tickers
            assert(isGreaterThanOrEqual(obtainedTickersLength, multiply(notInactiveSymbolsLength, (subtract(1, toleranceCoefficient)))), add(add(add(add(add(add(add(exchange.id, " "), "fetchTickers"), " must return tickers for all active markets. but returned: "), ((object)obtainedTickersLength).ToString()), " tickers, "), ((object)notInactiveSymbolsLength).ToString()), " active markets"));
            //
            // ensure tickers length is less than markets length
            //
            object allMarkets = exchange.markets;
            object allMarketsLength = getArrayLength(new List<object>(((IDictionary<string,object>)allMarkets).Keys));
            assert(isLessThanOrEqual(obtainedTickersLength, allMarketsLength), add(add(add(add(add(add(add(exchange.id, " "), "fetchTickers"), " must return <= than all markets, but returned: "), ((object)obtainedTickersLength).ToString()), " tickers, "), ((object)allMarketsLength).ToString()), " markets"));
        }
    }

}