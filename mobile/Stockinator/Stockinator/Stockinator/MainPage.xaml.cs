using Stockinator.Controls;
using Stockinator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Stockinator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        uint animationSpeed = 300;
        private async void StockCellRecognizer_Tapped(object sender, EventArgs e)
        {   
            // thingamajig to fade in the overlay
            FadeBackground.Opacity = 0;
            FadeBackground.IsVisible = true;
            FadeBackground.FadeTo(1, animationSpeed);

            // gets cell that was tapped
            var element = (StockCell)sender;

            // positions the overlay
            FakeCell.BindingContext = element.BindingContext;

            var dropDownContainerRect = new Rectangle(0, element.Bounds.Top, this.Width, FakeCell.Height + InfoDropDown.Height + DeleteDropDown.Height);
            AbsoluteLayout.SetLayoutBounds(DropDownContainer, dropDownContainerRect);

            // the dropdowns have to start hidden - might refactor this later, this looks ugly...
            DeleteDropDown.IsVisible = false;
            EditDropDown.IsVisible = false;
            InfoDropDown.IsVisible = false;

            await OpenDropDown(InfoDropDown);
            await OpenDropDown(DeleteDropDown);
            await OpenDropDown(EditDropDown);

        }

        private async Task OpenDropDown(View view)
        {
            view.IsVisible = true;
            view.RotationX = -90;
            view.Opacity = 0;
            _ = view.FadeTo(1, animationSpeed); // to remove the annoying await msg
            await view.RotateXTo(0, animationSpeed);
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
    }
}
