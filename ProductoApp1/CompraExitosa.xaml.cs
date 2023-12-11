using ProductoApp1.Services;

namespace ProductoApp1;

public partial class CompraExitosa : ContentPage
{
	public CompraExitosa()
	{
		InitializeComponent();
	}
    private readonly APIService _APIService;
    public CompraExitosa(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;


    }

    private async void OnClickVolverList(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new ListaProductos(_APIService));
    }
}