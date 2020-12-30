import React from 'react'

const url = `https://stockinator-data.herokuapp.com/stock/MSFT`

async function APIRetrieval() {

    let data = await fetch(url).json;
    const {price, open, high, low, volume, prevclose, forwardPE} = tickData;
    return
}


function Stockdata() {
    return (
        <table className="table-auto">
            <thead>
                <tr>
                    <th><h1>Microsoft</h1></th>
                </tr>
                <tr>
                    <th>Price</th>
                    <th>Open</th>
                    <th>High</th>
                    <th>Low</th>
                    <th>Volume</th>
                    <th>Previous Close</th>
                    <th>Forward PE</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th>a</th>
                    <th>214.75</th>
                    <th>220.11</th>
                    <th>214.75</th>
                    <th>35023253</th>
                    <th>214.13</th>
                    <th>29.354753</th>
                </tr>
            </tbody>
        </table>
    )
}

export default Stockdata
