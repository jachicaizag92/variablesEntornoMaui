using System;
using System.Diagnostics;
using entorno.Config;
using Microsoft.Maui.Controls;

namespace entorno
{
    public partial class MainPage : ContentPage
    {
        private readonly IEnvironments _baseUrlProvider;

        public MainPage()
        {
            // Utiliza el contenedor de servicios de la aplicación para obtener el servicio IBaseUrlProvider.
            _baseUrlProvider = MauiProgram.CreateMauiApp().Services.GetRequiredService<IEnvironments>();

            string dbConnectionString = _baseUrlProvider.GetDatabaseConnectionString();


            InitializeComponent();

            // Ahora puedes acceder a _baseUrlProvider para obtener el devUri.
            string devUri = _baseUrlProvider.GetBaseUrl();

            // Imprime en la consola
            Debug.WriteLine($"entornooo: {devUri}");
            Debug.WriteLine($"BASEEE: {dbConnectionString}");


            // Asigna el valor de devUri al texto del Label
            DevUriLabel.Text = $"entornooo: {devUri}";
        }

        // Constructor original con parámetros.
        public MainPage(IEnvironments baseUrlProvider)
            : this()
        {
            _baseUrlProvider = baseUrlProvider;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            // Realiza acciones cuando se hace clic en el contador.
        }
    }
}
