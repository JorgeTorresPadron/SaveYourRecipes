﻿using SaveYourRecipes.Models;
using SaveYourRecipes.Service;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.NuevaReceta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevoPaisView : ContentPage
    {
        public NuevoPaisView()
        {
            InitializeComponent();
        }

        private async void nuevoPaisButton_Clicked(object sender, EventArgs e)
        {
            string nombreUsuario = CompartirInformacion.nombreUsuarioShare;

            Pais pais = new Pais()
            {
                pais_nombre = nuevoPaisTxt.Text,
                pais_nombre_usuario = nombreUsuario,
            };

            await App.Database.SavePaisAsync(pais);
            await DisplayAlert(Strings.Strings.display_alert_success, Strings.Strings.display_alert_country_stored_correctly, Strings.Strings.display_alert_aceptar);

            await ListaMostrar();
        }

        private async void lstPaises_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Pais)e.SelectedItem;
            nuevoPaisButton.IsVisible = false;
            modificarPaisButton.IsVisible = true;
            eliminarPaisButton.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.pais_id.ToString()))
            {
                var pais = await App.Database.GetPaisPorId(obj.pais_id);
                if (pais != null)
                {
                    idPaisTxt.Text = pais.pais_id.ToString();
                    nuevoPaisTxt.Text = pais.pais_nombre.ToString();
                }

                idPaisTxt.IsVisible = false;
            }
        }

        public async Task ListaMostrar()
        {
            string nombreUsuario = CompartirInformacion.nombreUsuarioShare;
            var paisesList = await App.Database.GetPaisAsync(nombreUsuario);
            if (paisesList != null)
            {
                lstPaises.ItemsSource = paisesList;
            }
        }

        private async void modificarPaisButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idPaisTxt.Text))
            {
                string nombreUsuario = CompartirInformacion.nombreUsuarioShare;
                Pais pais = new Pais()
                {
                    pais_id = Convert.ToInt32(idPaisTxt.Text),
                    pais_nombre = nuevoPaisTxt.Text,
                    pais_nombre_usuario = nombreUsuario,
                };
                await App.Database.SavePaisAsync(pais);
                await DisplayAlert(Strings.Strings.display_alert_success, Strings.Strings.display_alert_country_updated, Strings.Strings.display_alert_aceptar);

                modificarPaisButton.IsVisible = false;
                eliminarPaisButton.IsVisible = false;
                nuevoPaisButton.IsVisible = true;

                nuevoPaisTxt.Text = "";

             await ListaMostrar();
            }
        }

        private async void eliminarPaisButton_Clicked(object sender, EventArgs e)
        {
            var pais = await App.Database.GetPaisPorId(Convert.ToInt32(idPaisTxt.Text));

            if (pais != null)
            {
                await App.Database.DeletePaisAsync(pais);
                await DisplayAlert(Strings.Strings.display_alert_eliminado, Strings.Strings.display_alert_country_deleted, Strings.Strings.display_alert_aceptar);

                modificarPaisButton.IsVisible = false;
                eliminarPaisButton.IsVisible = false;
                nuevoPaisButton.IsVisible = true;

               await ListaMostrar();
            }

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ListaMostrar();
        }
    }
}