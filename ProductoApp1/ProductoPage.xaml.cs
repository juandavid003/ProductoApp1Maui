
using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using System.Collections.ObjectModel;
using ProductoApp1.Services;
using Ejemplo1.Models;

namespace ProductoApp1;

public partial class ProductoPage : ContentPage
{
    private readonly APIService _APIService;
	public ProductoPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
       
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //List<Producto> ListaProducto = await _APIService.GetProductos();
        //var productos = new ObservableCollection<Producto>(ListaProducto);
        //listaProductos.ItemsSource = productos;
    }

    private async void OnClickIniciarSesion(object sender, EventArgs e)
    {
        

       await Navigation.PushAsync(new IniciarSesion(_APIService));
    }

    private async void OnClickRegistrarse(object sender, EventArgs e)
    {
        //var toast = Toast.Make("Click en nuevo producto", ToastDuration.Short, 14);

        //await toast.Show();

        await Navigation.PushAsync(new Registrarse(_APIService));
    }


   
}