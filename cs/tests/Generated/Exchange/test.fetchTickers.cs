using ccxt;
namespace Tests;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


public partial class testMainClass : BaseTest
{
    async static public Task<object> testFetchTickers(Exchange exchange, object skippedProperties, object symbol)
    {
        // const withoutSymbol = testFetchTickersHelper (exchange, skippedProperties, undefined);
        // const withSymbol = testFetchTickersHelper (exchange, skippedProperties, [ symbol ]);
        await promiseAll(new List<object> {testFetchTickersHelper(exchange, skippedProperties, null), testFetchTickersHelper(exchange, skippedProperties, new List<object>() {symbol})});
        return true;
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
        return true;
    }

}