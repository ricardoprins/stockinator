// instantiating stockData
const http = new stockData;

// get method
http.get('https://stockinator-data.herokuapp.com/stock/MSFT')
    .then(data => console.log(data))
    .catch(error => console.log(error))