using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;

namespace BLL
{
    public class PersonaService
    {
        PersonaRepository PersonaRespositorio = new PersonaRepository();
        public string Guardar(Persona persona)
        {
            if (PersonaRespositorio.Buscar(persona) == null)
            {
                PersonaRespositorio.Guardar(persona);
                return $"Se registro la persona {persona.Identificacion} Satisfactoriamente";
            }
            else
            {
                return $"La persona {persona.Identificacion} ya esta registrada";
            }


        }

        public string Eliminar(Persona persona)
        {
            if (PersonaRespositorio.Buscar(persona) == null)
            {

                return $"La persona con identificacion no se encuentra registrada";

            }
            else
            {
                PersonaRespositorio.Eliminar(persona);
                return $"La persona {persona.Identificacion} fue eliminada";
            }
        }

        public List<Persona> Consultar()
        {
            return PersonaRespositorio.Consultar();
        }

        public string Modificar(Persona persona)
        {
            if (PersonaRespositorio.Buscar(persona) == null)
            {

                return $"La persona con identificacion no se encuentra registrada";

            }
            else
            {
                PersonaRespositorio.Modificar(persona);
                return $"La persona {persona.Identificacion} fue Modificada";
            }
        }

        public Persona Buscar(string identificacion)
        {
            return PersonaRespositorio.Buscar(identificacion);
        }

        public void Buscar(Persona persona)
        {

        }
    }
}
