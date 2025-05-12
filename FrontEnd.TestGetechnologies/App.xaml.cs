using FrontEnd.TestGetechnologies.Service.Persona;
using FrontEnd.TestGetechnologies.Views.Person;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.ServiceProcess;
using System.Windows;

namespace FrontEnd.TestGetechnologies
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            //    base.OnStartup(e);
            //
            //    if( _serviceProvider == null) 
            //    {
            //        _serviceProvider = new ServiceCollection()
            //            .AddSingleton<IPersonService, PersonService>()
            //            .AddSingleton<IRestApiConsumer>(new RestApiConsumer(ConfigurationManager.AppSettings["UrlApi"]!.ToString()))
            //            .AddSingleton<AddPersonView>()
            //            .BuildServiceProvider();
            //    }
            var main = new MainWindow(ConfigurationManager.AppSettings["UrlApi"]!.ToString());
            main.Show();
        //
        }
    }

}
