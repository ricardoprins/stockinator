from fastapi import FastAPI
import json
import yfinance as yf
import pandas as pd
import datetime


app = FastAPI()


@app.get("/stock/{ticker}")
async def get_stock_data(ticker: str):
    ticker_data = yf.Ticker(ticker).info
    mktopen = ticker_data["open"]
    mkthigh = ticker_data["dayHigh"]
    mktlow = ticker_data["dayLow"]
    mktvolume = ticker_data["volume"]
    mkforwardPE = ticker_data["forwardPE"]
    mkforwardEps = ticker_data["forwardEps"]  
    return {"open": mktopen, "high": mkthigh, "low": mktlow, "volume": mktvolume, "forwardPE" : mkforwardPE, "forwardEps" : mkforwardEps}


@app.get("/stock/historic/{ticker}")
async def get_historical_data(ticker: str, tperiod: str = "1mo"):
    # periods: 1m,2m,5m,15m,30m,60m,90m,1h,1d,5d,1wk,1mo,3mo
    ticker_data = yf.Ticker(ticker).history(period=tperiod)
    return json.loads(ticker_data.to_json(orient="index", date_format="iso"))


@app.get("/stock/data-options/{ticker}")
async def get_data_options(ticker: str):
    tk = yf.Ticker(ticker)
    exps = tk.options

    # Get options for each expiration
    options = pd.DataFrame()
    for e in exps:
        opt = tk.option_chain(e)
        opt = pd.DataFrame().append(opt.calls).append(opt.puts)
        opt['expirationDate'] = e
        options = options.append(opt, ignore_index=True)

    # Bizarre error in yfinance that gives the wrong expiration date
    # Add 1 day to get the correct expiration date
    options['expirationDate'] = pd.to_datetime(
        options['expirationDate']) + datetime.timedelta(days=1)
    options['dte'] = (options['expirationDate'] -
                    datetime.datetime.today()).dt.days / 365

    # Boolean column if the option is a CALL
    options['CALL'] = options['contractSymbol'].str[4:].apply(
        lambda x: "C" in x)

    options[['bid', 'ask', 'strike']] = options[[
        'bid', 'ask', 'strike']].apply(pd.to_numeric)
    options['mark'] = (options['bid'] + options['ask']) / 2 # Calculate the midpoint of the bid-ask

    # Drop unnecessary and meaningless columns
    options = options.drop(columns=[
        'contractSize', 'currency', 'change', 'percentChange', 'lastTradeDate', 'lastPrice'])


    pd.set_option('display.max_rows', 1500)

    options = options.to_json(orient='records')

    return options