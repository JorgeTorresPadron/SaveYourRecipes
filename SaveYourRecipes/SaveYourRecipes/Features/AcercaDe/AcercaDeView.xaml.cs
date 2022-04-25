using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.AcercaDe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcercaDeView : ContentPage
    {
        public AcercaDeView()
        {
            InitializeComponent();
            BindingContext = new AcercaDeViewModel();
        }

        private void volverButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPageView());
        }
    }
}