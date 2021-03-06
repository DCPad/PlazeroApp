﻿using AppPlazero.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlazero.Views
{
    public partial class HeaderIncome : ContentPage
    {
        public ObservableCollection<string> Incomes { get; set; }

        public HeaderIncome()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            listHeaderIncome.ItemsSource = await App.TodoManager.RefreshIncome();
            base.OnAppearing();
        }

        private async void cargarDetalle(object sender, SelectionChangedEventArgs e)
        {
            var item = (e.CurrentSelection.FirstOrDefault() as Income);
            
            if (item == null)
                return;

            await Navigation.PushAsync(new vwListarDetalle(item));
            ((CollectionView)sender).SelectedItem = null;
        }

        private async void agregarIngreso(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarritoGeneral());

        }
    }
}

