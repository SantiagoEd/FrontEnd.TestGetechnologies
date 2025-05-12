using FrontEnd.TestGetechnologies.Domain;
using FrontEnd.TestGetechnologies.Service.Persona.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.TestGetechnologies.Service.Persona
{
    public class PersonService : IPersonService
    {
        IRestApiConsumer restApiConsumer;
        public PersonService(IRestApiConsumer _restApiConsumer)
        {
            this.restApiConsumer = _restApiConsumer;
        }

        public async Task<ResponseDto<bool>> AddPerson(string Nombre, string ApellidoP, string ApellidoM, Guid Identificacion)
        {
            var result = new ResponseDto<bool>();

            try
            {
                var request = new PersonRQ 
                {
                    persona = new PersonDto
                    {
                        apellidoMaterno = ApellidoM,
                        apellidoPaterno = ApellidoP,
                        identificacion = Identificacion,
                        nombre = Nombre
                    }
                };
                result = await restApiConsumer.Consume<ResponseDto<bool>>($"Directory/storePersona", request, RestSharp.Method.Post);
            }
            catch (Exception ex)
            {
                // Manda a Log
                //throw ex;
                result.Success = false;
            }

            return result;
        }
    }
}
