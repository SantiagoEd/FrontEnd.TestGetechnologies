using FrontEnd.TestGetechnologies.Service.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontEnd.TestGetechnologies.Views.Person
{
    /// <summary>
    /// Lógica de interacción para AddPersonView.xaml
    /// </summary>
    public partial class AddPersonView : Window
    {
        IPersonService personService;

        public AddPersonView(IPersonService _personService)
        {
            InitializeComponent();
            this.personService = _personService;
        }


        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (Validation()) 
            {
                var nombre = txtNombre.Text;
                var apellidoP = txtApellidoPaterno.Text;
                var apellidoM = txtApellidoMaterno.Text;

                var response = personService.AddPerson(nombre, apellidoP, apellidoM, Guid.NewGuid()).GetAwaiter().GetResult();

                InitialTexBox();
                MessageBox.Show(response.Message, "Alta de Persona", MessageBoxButton.OK);
            }

        }

        private void txtNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txtNombre.Text == "Nombre*") 
            {
                txtNombre.Text = string.Empty;
                txtNombre.Foreground = new SolidColorBrush(Colors.Black);
            }else if (string.IsNullOrEmpty(txtNombre.Text)) 
            {
                txtNombre.Text = "Nombre*";
                txtNombre.Foreground = new SolidColorBrush(Colors.DarkGray);
            }
        }

        private void txtApellidoPaterno_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtApellidoPaterno.Text == "Apellido Paterno*")
            {
                txtApellidoPaterno.Text = string.Empty;
                txtApellidoPaterno.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtApellidoPaterno.Text = "Apellido Paterno*";
                txtApellidoPaterno.Foreground = new SolidColorBrush(Colors.DarkGray);
            }
        }

        private void txtApellidoMaterno_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtApellidoMaterno.Text == "Apellido Materno")
            {
                txtApellidoMaterno.Text = string.Empty;
                txtApellidoMaterno.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtApellidoMaterno.Text = "Apellido Materno";
                txtApellidoMaterno.Foreground = new SolidColorBrush(Colors.DarkGray);
            }
        }
        private void InitialTexBox() 
        {
            txtNombre.Text = "Nombre*";
            txtApellidoPaterno.Text = "Apellido Paterno*";
            txtApellidoMaterno.Text = "Apellido Materno";
            txtNombre.Foreground = new SolidColorBrush(Colors.DarkGray);
            txtApellidoPaterno.Foreground = new SolidColorBrush(Colors.DarkGray);
            txtApellidoMaterno.Foreground = new SolidColorBrush(Colors.DarkGray);
        }

        private bool Validation() 
        {
            var valid = true;
            if(txtNombre.Text == "Nombre*") 
            {
                MessageBox.Show("El nombre es obligatorio", "Alta de Persona", MessageBoxButton.OK,MessageBoxImage.Error);
                valid = false;
            }
            if (txtApellidoPaterno.Text == "Apellido Paterno*")
            {
                MessageBox.Show("El Apellido Paterno es obligatorio", "Alta de Persona", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }
            return valid;
        }
    }
}
