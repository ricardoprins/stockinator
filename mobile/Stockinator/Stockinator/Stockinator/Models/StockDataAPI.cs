using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Stockinator.Models
{
    internal class StockDataAPI : INotifyPropertyChanged
    {
        public string Ticker { get; set; }

        private string _title;

        [JsonProperty("title")]       

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
