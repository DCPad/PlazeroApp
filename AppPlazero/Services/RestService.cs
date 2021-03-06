﻿using AppPlazero.Models;
using AppPlazero.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPlazero.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public ObservableCollection<Producto> Items { get; private set; }
        public ObservableCollection<Income> Incomes { get; private set; }
        public ObservableCollection<detailsIncome> DetailsIncome { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<ObservableCollection<Producto>> RefreshDataAsync()
        {
            Items = new ObservableCollection<Producto>();

            var uri = new Uri(string.Format(Constants.TodoItemsUrl+ "producto.php", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ObservableCollection<Producto>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task crearIngreso(Income Ingreso)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl + "ingresos.php", string.Empty));

            try
            {
                //var json = JsonConvert.SerializeObject(item);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (1==1)//isNewItem)
                {
                    //response = await _client.PostAsync(uri, content);
                }
                else
                {
                    //response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task SaveTodoItemAsync(Producto item, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl + "ingresos.php", string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }


        public async Task<User> ValidarLogin(User usuario)
        {
            User Usuario1 = new User();
            var uri = new Uri(string.Format(Constants.TodoItemsUrl + "terceros.php?rh_sUsuario=JCAMPOS&rh_sPassword=123456", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JsonConvert.PopulateObject(content, Usuario1);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Usuario1;
        }

        public async Task<ObservableCollection<Income>> RefreshIncome()
        {
            Incomes = new ObservableCollection<Income>();

            var uri = new Uri(string.Format(Constants.TodoItemsUrl + "income.php", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Incomes = JsonConvert.DeserializeObject<ObservableCollection<Income>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Incomes;
        }

        public async Task<ObservableCollection<detailsIncome>> RefreshListDetailIncome(Income IngresoHeader)
        {
            DetailsIncome = new ObservableCollection<detailsIncome>();

            var uri = new Uri(string.Format(Constants.TodoItemsUrl + "income.php?id=1", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    DetailsIncome = JsonConvert.DeserializeObject<ObservableCollection<detailsIncome>>(content);
                }
}
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return DetailsIncome;
          
        }

}
}
