using Ejemplo1.Models;
using ProductoApp1.Services;

namespace ProductoApp1;

public partial class Registrarse : ContentPage
{
    private object _ApiService;

    public Registrarse()
	{
		InitializeComponent();

	}
    private readonly APIService _APIService;
    public Registrarse(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;

    }

    private async void OnClickRegistrarse(object sender, EventArgs e)
    {
        Usuario user = await _APIService.PostRegistrarse(new Usuario {Nombre=Nombre.Text, Correo=Correo.Text, Contrasena=Contrasena.Text });

        if (user != null)
        {
            Usuario userLogin = await _APIService.GetIniciarSesion(user.Correo, user.Contrasena);

            if (userLogin != null && userLogin.Nombre != null)
            {
                await Navigation.PushAsync(new ListaProductos(_APIService));
            }
            else
                await Navigation.PushAsync(new IniciarSesion(_APIService));
        }
        else
            await Navigation.PushAsync(new Registrarse(_APIService));
    
    }
}