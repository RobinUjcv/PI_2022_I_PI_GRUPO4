using System;



using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2022_I_PI_GRUPO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //encuestas preguntas y respuestas

            bool repetir=true, menu = true, encuestaExiste=false;
            int p, r;
            int i=1, j=1;
            string decision;
            try
            {
                do
                {
                    do //menu
                    {
                        Console.WriteLine("Elija una opcion y presione enter\n" + "\n1.crear una encuesta" + "\n2.tomar la encuesta " + "\n3.salir");

                        decision = Console.ReadLine();

                        switch (decision)
                        {
                            case "1": //CREAR ENCUESTA 
                                Console.Clear();

                                //entrada de las preguntas
                                Console.Write("Favor ingrese la cantidad de preguntas que constara la encuesta: ");
                                p = int.Parse(Console.ReadLine());
                                Console.Write("Favor ingrese la cantidad de respuestas para cada pregunta: ");
                                r = int.Parse(Console.ReadLine());

                                string[,] preguntasRespuestas = new string[p + 1, r + 1]; //delimitador

                                //llenado
                                for (i = 1; i <= p; i++)
                                {
                                    Console.WriteLine($"Escriba su pregunta #{i}");
                                    preguntasRespuestas[0, i] = Console.ReadLine();// [0,x] Contiene las preguntas, [i,x] contiene las respuestas

                                    for (j = 1; j <= r; j++)
                                    {
                                        Console.WriteLine($"Escriba la {j}a respuesta de la pregunta {i}");
                                        preguntasRespuestas[i, j] = Console.ReadLine();
                                    }

                                }

                                encuestaExiste = true;

                                Console.WriteLine("\nSu encuesta fue creada con exito, presione cualquier tecla para retornar al menu");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "2": //TOMAR ENCUESTA
                                Console.Clear();

                                if (!encuestaExiste)
                                {
                                    Console.WriteLine("No se ha encontrado ninguna encuesta, favor cree una antes de empezar...");
                                }
                                else
                                {
                                    Console.WriteLine("He aqui una encuesta");
                                }
                                break;
                            case "3": //SALIR
                                menu = false;
                                repetir = false;
                                break;
                            default: //N/A
                                Console.Clear();
                                Console.WriteLine("La opcion que ha elegido no es valida, porfavor intente de nuevo\n");
                                break;
                        }

                    } while (menu);





                    


                } while (repetir);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
