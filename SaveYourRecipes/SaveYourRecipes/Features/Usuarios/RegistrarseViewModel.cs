using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SaveYourRecipes.Models;

namespace SaveYourRecipes.Features.Usuarios
{
    public class RegistrarseViewModel : BaseViewModel
    {
        #region Atributos
        public string nombreUsuario;
        public string contrasenaUsuario;
        public string contrasenaRepetidaUsuario;
        public string nombreUsuarioReal;
        public string apellidoUsuarioReal;
        public int edadUsuario;

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

        public string passwordUsuarioTxt
        {
            get { return this.contrasenaUsuario; }
            set { SetValue(ref this.contrasenaUsuario, value); }
        }

        public string passwordRepeatUsuarioTxt
        {
            get { return this.contrasenaRepetidaUsuario; }
            set { SetValue(ref this.contrasenaRepetidaUsuario, value); }
        }

        public string nombreUsuarioRealTxt
        {
            get { return this.nombreUsuarioReal; }
            set { SetValue(ref this.nombreUsuarioReal, value); }
        }

        public string apellidoUsuarioRealTxt
        {
            get { return this.apellidoUsuarioReal; }
            set { SetValue(ref this.apellidoUsuarioReal, value); }
        }

        public int edadUsuarioTxt
        {
            get { return this.edadUsuario; }
            set { SetValue(ref this.edadUsuario, value); }
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
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
        }
        #endregion

        #region Methods
        private async void RegisterMethod()
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

            if (string.IsNullOrEmpty(this.nombreUsuarioReal))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_error_empty_firstname, Strings.Strings.display_alert_aceptar);
                return;
            }

            if (string.IsNullOrEmpty(this.apellidoUsuarioReal))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_error_empty_lastname, Strings.Strings.display_alert_aceptar);
                return;
            }

            if (this.edadUsuario.Equals(null) | this.edadUsuario.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_error_empty_age, Strings.Strings.display_alert_aceptar);
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

            await Task.Delay(1000);

            var user = new User
            {
                user_nombre_usuario = nombreUsuario,
                user_password = contrasenaUsuario,
                user_nombre_real = nombreUsuarioReal,
                user_apellido_real = apellidoUsuarioReal,
                user_edad = edadUsuario,
                user_fecha_creacion = DateTime.Now,
            };

            await App.Database.SaveUserAsync(user);

            await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_success, Strings.Strings.display_alert_welcome + " " + nombreUsuario.ToString(), Strings.Strings.display_alert_aceptar);

            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;

            await App.Current.MainPage.Navigation.PushModalAsync(new IniciarSesionView());
        }
        #endregion

        #region Constructor
        public RegistrarseViewModel()
        {
            IsEnabledTxt = true;
        }

        #endregion
    }
}
