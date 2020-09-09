using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Persona
    {
        public Persona(string identificacion, string nombre, int edad, string sexo)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
        }

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int Pulsaciones { get; set; }



        public void CalcularPulsaciones()
        {
            if (Sexo == "f")
            {
                Pulsaciones = (220 - Edad) / 10;
            }
            else if (Sexo == "m")
            {
                Pulsaciones = (210 - Edad) / 10;
            }
            else
            {
                Pulsaciones = 0;
            }
        }

        public override string ToString()
        {
            return $"Identificacion: {Identificacion} \nNombre {Nombre} \nEdad: {Edad} \nSexo: {Sexo}  \nPulsaciones: {Pulsaciones}";
        }

    }
}
