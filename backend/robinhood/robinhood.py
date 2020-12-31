import robin_stocks as rs
rs.login(username=your_username,
         password=your_password,
         expiresIn=86400,
         by_sms=True)
import os 

robin_user = os.environ.get("robinhood_username")
robin_pass = os.environ.get("robinhood_password")

rs.login(username=robin_user,
         password=robin_pass,
         expiresIn=86400,
         by_sms=True)