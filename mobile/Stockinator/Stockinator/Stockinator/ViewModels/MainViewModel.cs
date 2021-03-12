using MvvmHelpers;
using Stockinator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Stockinator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public IList<StockInfo> Quotes { get; }

        public MainViewModel()
        {
            Quotes = new ObservableCollection<StockInfo>
            {
                new StockInfo() { Ticker = "MSFT", Price = "243.30" },
                new StockInfo() { Ticker = "TSLA", Price = "730.76" },
                new StockInfo() { Ticker = "SPCE", Price = "50.22" }
            };
        }
    }
}
