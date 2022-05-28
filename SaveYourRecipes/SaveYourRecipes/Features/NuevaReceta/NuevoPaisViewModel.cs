using CommunityToolkit.Mvvm.Input;
using SaveYourRecipes.Features.Usuarios;
using SaveYourRecipes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaveYourRecipes.Features.NuevaReceta
{
    public class NuevoPaisViewModel : BaseViewModel
    {
        #region Atributos
        public string nombrePais;

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Propiedades
        public string nombrePaisTxt
        {
            get { return this.nombrePais; }
            set { SetValue(ref this.nombrePais, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Commands
        public ICommand NewCountryCommand
        {
            get
            {
                return new RelayCommand(NewCountryMethod);
            }
        }
        #endregion

        #region Methods
        private async void NewCountryMethod()
        {
            if (string.IsNullOrEmpty(this.nombrePais))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir el país que quieres añadir / You must enter the country you want to add", "Ok");
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(1000);

            var pais = new Pais
            {
                pais_nombre = nombrePais,
            };

            await App.Database.SavePaisAsync(pais);

            await App.Current.MainPage.DisplayAlert("Éxito / Success", "País / Country " + nombrePais.ToString() + " almacenado correctamente / stored correctly", "Ok");

            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;

            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        #endregion

        #region Constructor
        public NuevoPaisViewModel()
        {
            IsEnabledTxt = true;
        }

        #endregion
    }
}
