using SaveYourRecipes.Features.MisRecetas;
using SaveYourRecipes.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.NuevaReceta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaRecetaView : ContentPage
    {
        public NuevaRecetaView()
        {
            InitializeComponent();
            BindingContext = new NuevaRecetaViewModel();
        }
    }
}