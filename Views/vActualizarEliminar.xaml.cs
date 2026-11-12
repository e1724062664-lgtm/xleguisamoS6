using System.Net;
using xleguisamoS6.Modelos;

namespace xleguisamoS6.Views;

public partial class vActualizarEliminar : ContentPage
{
	public vActualizarEliminar(Estudiante datos)
	{
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellid;
        txtEdad.Text = datos.edad.ToString();

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            // En PUT el PHP lee los datos desde la URL ($_GET)
            string url = "http://192.168.100.153/ws_uisrael/ws_estudiante.php" +
                         "?codigo=" + txtCodigo.Text +
                         "&nombre=" + Uri.EscapeDataString(txtNombre.Text) +
                         "&apellid=" + Uri.EscapeDataString(txtApellido.Text) +
                         "&edad=" + txtEdad.Text;

            cliente.UploadValues(url, "PUT", parametros);
            DisplayAlertAsync("Alerta", "Estudiante actualizado", "OK");
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Alerta", ex.Message, "OK");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            // En DELETE el PHP lee el código desde la URL ($_GET)
            string url = "http://192.168.100.153/ws_uisrael/ws_estudiante.php?codigo=" + txtCodigo.Text;

            cliente.UploadValues(url, "DELETE", parametros);
            DisplayAlertAsync("Alerta", "Estudiante eliminado", "OK");
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Alerta", ex.Message, "OK");
        }
    }
}