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
}