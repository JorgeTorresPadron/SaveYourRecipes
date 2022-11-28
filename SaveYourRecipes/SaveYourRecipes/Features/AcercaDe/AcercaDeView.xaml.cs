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
    }
}