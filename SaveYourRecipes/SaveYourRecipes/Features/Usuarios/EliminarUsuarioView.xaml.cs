﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.Usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EliminarUsuarioView : ContentPage
    {
        public EliminarUsuarioView()
        {
            InitializeComponent();
            BindingContext = new EliminarUsuarioViewModel();
        }
    }
}