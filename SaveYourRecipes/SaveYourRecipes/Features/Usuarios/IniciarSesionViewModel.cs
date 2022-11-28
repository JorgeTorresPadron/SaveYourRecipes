using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SaveYourRecipes.Models;
using SaveYourRecipes.Service;

namespace SaveYourRecipes.Features.Usuarios
{
    public class IniciarSesionViewModel : BaseViewModel
    {
        #region Atributos
        public string nombreUsuario;
        public string contrasenaUsuario;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Propiedades
        public string nombreUsuarioTxt
        {
            get { return this.nombreUsuario; }
            set { SetValue(ref this.nombreUsuario, value); }
        }

        public string contrasenaUsuarioTxt
        {
            get { return this.contrasenaUsuario; }
            set { SetValue(ref this.contrasenaUsuario, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
        }
        #endregion

        #region Methods
        public async void LoginMethod()
        {
            if (string.IsNullOrEmpty(this.nombreUsuario))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_error_empty_username, Strings.Strings.display_alert_aceptar);
                return;
            }

            if (string.IsNullOrEmpty(this.contrasenaUsuario))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_error_empty_password, Strings.Strings.display_alert_aceptar);
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(20);

            List<User> e = App.Database.GetUsersValidate(nombreUsuario, contrasenaUsuario).Result;
            CompartirInformacion.nombreUsuarioShare = nombreUsuario;

            if (e.Count == 0)
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_error_iniciarsesionview, Strings.Strings.display_alert_aceptar);

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            }
            else if (e.Count > 0)
            {         
                await App.Current.MainPage.Navigation.PushAsync(new MainPageView());

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            }
        }
        #endregion

        #region Constructor
        public IniciarSesionViewModel()
        {
            this.IsEnabledTxt = true;
        }
        #endregion
    }
}
