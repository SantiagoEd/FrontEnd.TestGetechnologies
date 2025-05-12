using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FrontEnd.TestGetechnologies.Service.Persona.Common
{
    public class PersonDto
    {
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public Guid identificacion { get; set; }
    }
}
