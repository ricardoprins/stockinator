using Stockinator.Controls;
using Stockinator.ViewModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Stockinator
{
    public partial class MainPage : ContentPage
    {

        private const string Url = "https://stockinator-data.herokuapp.com/stock/";
        private readonly HttpClient _client = new HttpClient();
        // private MarshalingObservableCollection<Stocks> _data; TO IMPLEMENT

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url);
            // List<Stocks> stocks = JsonConvert.DeserializeObject<List<Stocks>>(content); TO IMPLEMENT
        }

        // TO ADD: remaining "CRUD" stuff - not really CRUD, but I'll remember what I wanna do when I read this later

        uint animationSpeed = 300;
        private async void StockCellRecognizer_Tapped(object sender, EventArgs e)
        {   
            // thingamajig to fade in the overlay
            FadeBackground.Opacity = 0;
            FadeBackground.IsVisible = true;
            _ = FadeBackground.FadeTo(1, animationSpeed);

            // gets cell that was tapped
            var element = (StockCell)sender;
            FakeCell.BindingContext = element.BindingContext;

            // positions the dropdowns
            PositionDropDown(element, Front);
            PositionDropDown(element, Back);


            // the dropdowns have to start hidden - might refactor this later, this looks ugly...
            Front.IsVisible = true;
            DeleteDropDown.IsVisible = false;
            EditDropDown.IsVisible = false;
            InfoDropDown.IsVisible = false;
            Back.IsVisible = false;

            await OpenDropDown(InfoDropDown);
            await OpenDropDown(DeleteDropDown);
            await OpenDropDown(EditDropDown);

        }

        private void PositionDropDown(VisualElement parent, VisualElement dropDown)
        {
            AbsoluteLayout.SetLayoutFlags(dropDown, AbsoluteLayoutFlags.None);
            var dropDownContainerRect = new Rectangle(0, parent.Bounds.Top, this.Width, dropDown.Height);
            AbsoluteLayout.SetLayoutBounds(dropDown, dropDownContainerRect);
        }

        private async Task OpenDropDown(View view)
        {
            view.IsVisible = true;
            view.RotationX = -90;
            view.Opacity = 0;
            _ = view.FadeTo(1, animationSpeed); // to remove the annoying await msg
            await view.RotateXTo(0, animationSpeed, Easing.SpringOut);
        }

        private async Task CloseDropDown(View view)
        {
            _ = view.FadeTo(0, animationSpeed); // to remove the annoying await msg
            await view.RotateXTo(-90, animationSpeed);
            view.IsVisible = false;
        }


        private async void BackgroundTapRecognizer_Tapped(object sender, EventArgs e)
        {
            // closes all the dropdowns
            await CloseDropDown(EditDropDown);
            await CloseDropDown(DeleteDropDown);
            await CloseDropDown(InfoDropDown);

            // thingamajig to fade out the overlay -- added async/await because it makes sense to me.
            await FadeBackground.FadeTo(0, animationSpeed);
            FadeBackground.IsVisible = false;
        }

        private async void DeleteTapRecognizer_Tapped(object sender, EventArgs e)
        {
            await CloseDropDown(InfoDropDown);
            FakeCell.IsVisible = true;
            await Flip(Front, Back);
        }

        private async Task Flip(VisualElement from, VisualElement to)
        {
            await from.RotateYTo(-90, animationSpeed, Easing.SpringIn);
            to.RotationY = 90;
            to.IsVisible = true;
            from.IsVisible = false;
            await to.RotateYTo(0, animationSpeed, Easing.SpringOut);
        }

        private async void NoTapRecognizer_Tapped(object sender, EventArgs e)
        {
            await Flip(Back, Front);
            await OpenDropDown(InfoDropDown);
        }
    }
}
