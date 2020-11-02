class stockData {

    // HTTP Request
    async get(url) {
        // Awaiting for response
        const response = await fetch(url);
        // Awaiting for response.json()
        const resData = await response.json();
        // Returning JSON stock data
        return resData;
    }

    async newPrice(map) {
        currentPrice = arr["open"];
        highPrice = arr["high"];
        lowPrice = arr["low"];
        volumePrice = arr["volume"];
        var history = document.getElementById("priceHistory");
        document.getElementById("price").innerHTML = ("OPEN = "+currentPrice+" HIGH ="+highPrice+" LOW ="+lowPrice+" VOLUME ="+volumePrice);
    }
}
