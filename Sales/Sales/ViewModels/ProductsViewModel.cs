namespace Sales.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Common.Models;
    using Services;
    using Xamarin.Forms;
    public class ProductsViewModel : BaseViewModel
    {
        private ApiService apiService;  

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }
        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }
        private async void LoadProducts()
        {
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetList<Product>(url, "/api", "/Products");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
        }
    }
}
