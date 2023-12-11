using Ejemplo1.Models;
using ProductoApp1.Services;

namespace ProductoApp1;

public partial class IniciarSesion : ContentPage
{

    private Usuario _usuario;
    public IniciarSesion()
	{
		InitializeComponent();
	}

    private readonly APIService _APIService;
    public IniciarSesion(APIService apiservice)
    {  
        InitializeComponent();
        _APIService = apiservice;

    }


    private async void OnClickIniciarSesion(object sender, EventArgs e)
    {
        //Correo.Text = "123";
        //Contrasena.Text = "123";
        Usuario userLogin = await _APIService.GetIniciarSesion(Correo.Text, Contrasena.Text);


        if (userLogin != null && userLogin.Nombre != null)
        {
            //_userService.usuarioGlobal = userLogin;

                
            await Navigation.PushAsync(new ListaProductos(_APIService , userLogin));

        }
        else
            await Navigation.PushAsync(new IniciarSesion(_APIService));
    }

    private async void OnClickVolverLista(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new ListaProductos(_APIService, _usuario));
    }
    
}