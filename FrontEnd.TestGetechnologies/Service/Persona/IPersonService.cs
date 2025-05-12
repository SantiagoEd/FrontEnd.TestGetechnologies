using FrontEnd.TestGetechnologies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.TestGetechnologies.Service.Persona
{
    public interface IPersonService
    {
        Task<ResponseDto<bool>> AddPerson(string Nombre, string ApellidoP, string ApellidoM, Guid Identificacion);
    }
}
