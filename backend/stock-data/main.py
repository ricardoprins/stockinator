from fastapi import FastAPI
import json
import yfinance as yf


app = FastAPI()


@app.get("/stock/{ticker}")
async def get_stock_data(ticker: str):
    ticker_data = yf.Ticker(ticker).info
    mktopen = ticker_data["open"]
    mkthigh = ticker_data["dayHigh"]
    mktlow = ticker_data["dayLow"]
    mktvolume = ticker_data["volume"]
    return {"open": mktopen, "high": mkthigh, "low": mktlow, "volume": mktvolume}


@app.get("/stock/historic/{ticker}")
async def get_historical_data(ticker: str, tperiod: str = "1mo"):
    # periods: 1m,2m,5m,15m,30m,60m,90m,1h,1d,5d,1wk,1mo,3mo
    ticker_data = yf.Ticker(ticker).history(period=tperiod)
    return json.loads(ticker_data.to_json(orient="index", date_format="iso"))
