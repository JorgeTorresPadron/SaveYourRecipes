using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.Usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarseView : ContentPage
    {
        public RegistrarseView()
        {
            InitializeComponent();
            BindingContext = new RegistrarseViewModel();
        }

        private async void yaTengoCuentaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new IniciarSesionView());
        }
    }
}