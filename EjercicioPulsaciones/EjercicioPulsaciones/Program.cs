using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;

namespace EjercicioPulsaciones
{
    class Program
    {
        static void Main(string[] args)
        {
                string sexo;
                int edad;
                string identificacion;
                string nombre;
                string buscar;
                Persona persona;
                string mensaje;
                ConsoleKeyInfo opcion;
                List<Persona> personas = new List<Persona>();
                PersonaService servicio = new PersonaService();


                int OpcionSeleccionada = 0;
                int x;

                while (OpcionSeleccionada != 5)
                {
                    Console.WriteLine("1) Inserte a la Persona");
                    Console.WriteLine("2) Buscar a la Persona");
                    Console.WriteLine("3) Eliminar a la Persona");
                    Console.WriteLine("4) Modificar a la Persona");
                    Console.WriteLine("5) Salir");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Ingrese una opcion: ");

                    string OpcionSeleccionadaTemporal = Console.ReadLine();

                    if (int.TryParse(OpcionSeleccionadaTemporal, out x))
                    {
                        OpcionSeleccionada = int.Parse(OpcionSeleccionadaTemporal);

                        switch (OpcionSeleccionada)
                        {
                            case 1:

                                do
                                {
                                    try
                                    {

                                        Console.Clear();
                                        Console.WriteLine("***  Dijite Los Siguientes Datos:  ***\n\n");
                                        Console.WriteLine("Identificacion:");
                                        identificacion = Console.ReadLine();

                                        Console.WriteLine("Nombre:");
                                        nombre = Console.ReadLine();

                                        Console.WriteLine("Dijite Edad:");
                                        edad = int.Parse(Console.ReadLine());

                                        Console.WriteLine("Dijite Su Sexo(f/m):");
                                        sexo = Console.ReadLine();


                                        //edad = Convert.ToInt16(Console.ReadLine());

                                        persona = new Persona(identificacion, nombre, edad, sexo);
                                        persona.CalcularPulsaciones();
                                        Console.WriteLine(servicio.Guardar(persona));

                                        personas.Add(persona);

                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Ah ocurrido un error verifique los datos " + e.Message);
                                    }

                                    Console.WriteLine("Desea continuar (S/N)");
                                    opcion = Console.ReadKey();
                                    Console.ReadKey();
                                } while (opcion.Key == ConsoleKey.S);

                                Console.Clear();
                                Console.WriteLine("los datos dijitados son: ");
                                foreach (var itemPersona in servicio.Consultar())
                                {
                                    Console.WriteLine(itemPersona.ToString());
                                }
                                Console.ReadKey();

                                break;
                            case 2:

                                Console.Clear();
                                Console.WriteLine("***  Ingrese La Identificacion A Buscar:  ***");
                                buscar = Console.ReadLine();
                                servicio.Buscar(buscar);
                                Console.WriteLine(servicio.Buscar(buscar));
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("***  Ingrese La Identificacion A Eliminar:  ***");
                                buscar = Console.ReadLine();
                                mensaje = servicio.Eliminar(servicio.Buscar(buscar));
                                Console.WriteLine(mensaje);
                                Console.ReadKey();



                                Console.Clear();
                                Console.WriteLine("los datos dijitados son: ");
                                foreach (var itemPersona in servicio.Consultar())
                                {
                                    Console.WriteLine(itemPersona.ToString());
                                }
                                Console.ReadKey();
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Digite la info de la persona a modificar: ");
                                string IdentificacionBuscada = Console.ReadLine();
                                Persona PersonaVieja = servicio.Buscar(IdentificacionBuscada);
                                Console.WriteLine(PersonaVieja.ToString());
                                Console.WriteLine("***  Dijite Los Siguientes Datos:  ***\n\n");

                                identificacion = PersonaVieja.Identificacion;

                                Console.WriteLine("Nombre:");
                                nombre = Console.ReadLine();

                                Console.WriteLine("Dijite Edad:");
                                edad = int.Parse(Console.ReadLine());

                                Console.WriteLine("Dijite Su Sexo(f/m):");
                                sexo = Console.ReadLine();

                                Persona personaModificada = new Persona(identificacion, nombre, edad, sexo);
                                personaModificada.CalcularPulsaciones();
                                servicio.Modificar(personaModificada);

                                break;
                            case 5:

                                break;
                        }
                    }

                }
        }
        
    }
}
