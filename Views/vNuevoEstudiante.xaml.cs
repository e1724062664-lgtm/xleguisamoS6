using System.Net;

namespace xleguisamoS6.Views;

public partial class vNuevoEstudiante : ContentPage
{
	public vNuevoEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellid", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

			cliente.UploadValues("http://192.168.100.153/ws_uisrael/ws_estudiante.php", "POST", parametros);
			Navigation.PushAsync(new vEstudiante());

        }catch (Exception ex){
			 DisplayAlertAsync("Alerta", ex.Message, "OK");
			
		}
    }
}