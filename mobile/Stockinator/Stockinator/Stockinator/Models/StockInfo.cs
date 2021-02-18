using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockinator.Models
{
    public class StockInfo : ObservableObject
    {
        private string ticker;
        private string price;

        public string Ticker
        {
            get => ticker;
            set => SetProperty(ref ticker, value);
        }

        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
    }
}
