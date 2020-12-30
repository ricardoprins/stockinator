fetch('https://stockinator-data.herokuapp.com/stock/MSFT').then(function(response){
                  return response.json();
                }).then(function(obj){
                  console.log(obj);
                  newPrice(obj);
                }).catch(function(error){
                  console.error('Something went wrong');
                  console.error(error);
                });

                function newPrice(arr){
                  currentPrice = arr["open"];
                  highPrice = arr["high"];
                  lowPrice = arr["low"];
                  volumePrice = arr["volume"];
                  mktPrice = arr["price"];
                  prevClose = arr["prevclose"];
                  forwardPE = arr["forwardPE"];
                  var history = document.getElementById("priceHistory");
                  document.getElementById("price").innerHTML = (
                    "OPEN = "+currentPrice+" <br> HIGH ="+highPrice+" <br> LOW ="+lowPrice+" <br> VOLUME ="+volumePrice );
                }