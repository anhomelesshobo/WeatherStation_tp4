using Microsoft.Extensions.DependencyInjection;
using OpenWeatherAPI;
using System.Windows;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureViewModel vm;


        public MainWindow()
        {
            InitializeComponent();

            /// TODO : Faire les appels de configuration ici ainsi que l'initialisation
            ApiHelper.InitializeClient();
            var config = AppConfiguration.GetValue("OWApiKey");
            ITemperatureService ops = new OpenWeatherService(config);
            

            vm = new TemperatureViewModel(ops);
            

            DataContext = vm;           
        }
    }
}
