﻿using System;
using System.Linq;
using Xamarin.Forms;

using AppPlazero.Models;
using Newtonsoft.Json;

namespace AppPlazero.Views
{
    public partial class ProductosPage : ContentPage
    {
        public ProductosPage()
        {
            InitializeComponent();
            Title = "Productos";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CollectionProductos.ItemsSource = await App.TodoManager.GetTasksAsync();
        }
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.strUsuario = null;
            App.strUsuario = JsonConvert.SerializeObject(App.strUsuario);
            Application.Current.Properties["UsuarioActivo"] = App.strUsuario;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (e.CurrentSelection.FirstOrDefault() as Producto);
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage {BindingContext = item});
        }

        async void OnAgregarProductoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemDetailPage(true));
        }
    }
}