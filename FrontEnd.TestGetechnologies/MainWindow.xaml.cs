using FrontEnd.TestGetechnologies.Service.Persona;
using FrontEnd.TestGetechnologies.Views.Person;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontEnd.TestGetechnologies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Path;
        public MainWindow(string path) 
        {
            InitializeComponent();
            Path = path;
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            IRestApiConsumer restApiConsumer = new RestApiConsumer(Path);
            IPersonService personService = new PersonService(restApiConsumer);
            var AddPerson = new AddPersonView(personService);
            AddPerson.Show();
            this.Close();
        }
    }
}