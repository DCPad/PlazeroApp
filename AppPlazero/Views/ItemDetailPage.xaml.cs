﻿using System;
using Xamarin.Forms;
using AppPlazero.Models;

namespace AppPlazero.Views
{
    [QueryProperty("Name", "name")]
    public partial class ItemDetailPage : ContentPage
    {
        Producto ProductoItem;
        bool isNewItem;

        public ItemDetailPage(bool isNew = false)
        {
            if (isNew)
            {
                ProductoItem = new Producto();
                BindingContext = ProductoItem; // new Producto();
            }            
            
            InitializeComponent();
        }

        async void OnGuardarClicked(object sender, EventArgs e)
        {
            await App.TodoManager.SaveTaskAsync(ProductoItem, true);
            await Navigation.PopAsync();

        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                ProductoItem.pro_nidUnidadBase = selectedIndex;
            }
        }
    }
}