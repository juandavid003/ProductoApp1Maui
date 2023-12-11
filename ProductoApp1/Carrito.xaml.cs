using Ejemplo1.Models;
using ProductoApp1.Services;
using System.Collections.ObjectModel;

namespace ProductoApp1;

public partial class Carrito : ContentPage
{
    public Carrito()
    {
        InitializeComponent();
    }
    private readonly APIService _APIService;
    List<Producto> ProductosDelCarrito;
    List<Producto> ListaGeneralProductos;
    Usuario usuarioLogin;
    public Carrito(APIService apiservice, List<Producto> MiCarrito, List<Producto> productos, Usuario usuario = null)
    {
        usuarioLogin = usuario;
        InitializeComponent();
        _APIService = apiservice;
        ProductosDelCarrito = MiCarrito;
        ListaGeneralProductos = productos;

        var productosCarrito = new ObservableCollection<Producto>(ProductosDelCarrito);
        MiCarritoList.ItemsSource = productosCarrito;
    }
    private async void OnClickComprar(object sender, EventArgs e)
    {
        foreach (var item in ProductosDelCarrito)
        {
            Compra compra = new Compra
            {
                Cantidad = item.Cantidad,
                Codigo = 1,
                FechaCompra = DateTime.Now,
                IdProducto = item.IdProducto,
                Nombre = usuarioLogin.Nombre
            };

           await _APIService.PostCompra(compra);
        }

        await Navigation.PushAsync(new CompraExitosa(_APIService));
    }

    private async void DeleteProduct(object sender, EventArgs e)
    {


        Producto producto = (sender as Button)?.BindingContext as Producto;
        Producto productoExistencia = ProductosDelCarrito.Find(x => x.IdProducto == producto.IdProducto);
        productoExistencia.Cantidad--;

        Producto productoGeneral = ListaGeneralProductos.Find(x => x.IdProducto == producto.IdProducto);
        productoGeneral.Cantidad++;


        if (producto.Cantidad == 0)
        {
            if (ProductosDelCarrito.Contains(producto))
            {
                ProductosDelCarrito.Remove(producto);

            }
        }


        var productos = new ObservableCollection<Producto>(ProductosDelCarrito);
        MiCarritoList.ItemsSource = productos;
    }
}