using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.Editar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarRecetaView : ContentPage
    {
        public EditarRecetaView()
        {
            InitializeComponent();
        }

        private void actualizarRecetaButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}