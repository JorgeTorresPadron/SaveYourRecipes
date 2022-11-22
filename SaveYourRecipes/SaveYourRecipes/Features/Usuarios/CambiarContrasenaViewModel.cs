using CommunityToolkit.Mvvm.Input;
using SaveYourRecipes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaveYourRecipes.Features.Usuarios
{
    public class CambiarContrasenaViewModel : BaseViewModel
    {
        #region Atributos
        public string nombreUsuario;
        public string contrasenaUsuario;
        public string contrasenaRepetidaUsuario;
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

        public string contrasenaRepetidaUsuarioTxt
        {
            get { return this.contrasenaRepetidaUsuario; }
            set { SetValue(ref this.contrasenaRepetidaUsuario, value); }
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
        public ICommand ChangePasswordCommand
        {
            get
            {
                return new RelayCommand(ChangePasswordMethod);
            }
        }
        #endregion

        #region Methods
        public async void ChangePasswordMethod()
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

            if (this.contrasenaUsuario != this.contrasenaRepetidaUsuario)
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_error_password_not_match, Strings.Strings.display_alert_aceptar);
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(20);

            List<User> e = App.Database.GetUserChangePasswordValidate(nombreUsuario).Result;

            if (e.Count == 0)
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_cant_change_password_user_not_exist, Strings.Strings.display_alert_aceptar);

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            }
            else if (e.Count > 0)
            {
                await App.Database.UpdateUserPassword(nombreUsuario, contrasenaUsuario);

                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_password_updated, Strings.Strings.display_alert_aceptar);

                await App.Current.MainPage.Navigation.PushModalAsync(new IniciarSesionView());

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            }
        }
        #endregion

        #region Constructor
        public CambiarContrasenaViewModel()
        {
            this.IsEnabledTxt = true;
        }
        #endregion
    }
}
