using Newtonsoft.Json;
using System.Collections.ObjectModel;

using xleguisamoS6.Modelos;

namespace xleguisamoS6.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = "http://192.168.100.153/ws_uisrael/ws_estudiante.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> _estudiante;

    public vEstudiante()
    {
        InitializeComponent();
        Mostrar();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Mostrar();
    }

    public async void Mostrar()
    {
        try
        {
            var content = await cliente.GetStringAsync(Url);
            List<Estudiante> mostrarEstudiante = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            _estudiante = new ObservableCollection<Estudiante>(mostrarEstudiante);
            listaEstudiantes.ItemsSource = _estudiante;
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", ex.Message, "OK");
        }
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vNuevoEstudiante());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is not Estudiante seleccionado)
            return;

        // Limpia la selección para poder volver a tocar el mismo estudiante
        listaEstudiantes.SelectedItem = null;

        Navigation.PushAsync(new vActualizarEliminar(seleccionado));
    }
}