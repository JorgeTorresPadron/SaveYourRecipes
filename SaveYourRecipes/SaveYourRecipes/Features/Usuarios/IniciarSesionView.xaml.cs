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
    public partial class IniciarSesionView : ContentPage
    {
        public IniciarSesionView()
        {
            InitializeComponent();
            BindingContext = new IniciarSesionViewModel();
        }

        private async void noCuentaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrarseView());
        }

        private async void cambiarContrasenaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CambiarContrasenaView());
        }
    }
}