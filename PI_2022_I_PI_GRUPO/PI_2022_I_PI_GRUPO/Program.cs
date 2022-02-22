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

            bool ejecucion, menu2, menu = true, encuestaExiste=false;
            int p=0, r=0, participantes=0;
            int i=1, j=1, mayor = 0;
            string decision;

            string[] preguntaCompleta = new string[21]; //inicializador (espagueti)
            int[,] cantidadRespuestas = new int[21,21]; //almacena la cantidad de cada respuesta

            //try
            //{
            do
            {
                try
                {
                    Console.WriteLine("Elija una opcion y presione enter\n" + "\n1.crear una encuesta" + "\n2.tomar la encuesta " + "\n3.salir");
                    decision = Console.ReadLine();

                    //menu inicia -------------------------------------------------------
                    switch (decision)
                    {
                        case "1": //CREAR ENCUESTA --------------------------------------
                            Console.Clear();

                            //entrada de las preguntas
                            do
                            {
                                Console.Write("Favor ingrese la cantidad de preguntas que constara la encuesta (Maximo 20): ");
                                p = int.Parse(Console.ReadLine());
                                if (p > 20) //comprobar el limite
                                {
                                    Console.Clear();
                                    Console.WriteLine("Favor escoja un numero menor");
                                    p = 0;
                                }
                            } while (p == 0);
                            do
                            {
                                Console.Write("Favor ingrese la cantidad de respuestas para cada pregunta (Maximo 20): ");
                                r = int.Parse(Console.ReadLine());
                                if (r > 20) //comprobar el limite
                                {
                                    Console.Clear();
                                    Console.WriteLine("Favor escoja un numero menor");
                                    r = 0;
                                }
                            } while (r == 0);



                            string[,] preguntasRespuestas = new string[21, 21]; //delimitador


                            //llenado
                            for (i = 1; i <= p; i++)
                            {
                                Console.WriteLine($"Escriba su pregunta #{i}");
                                preguntasRespuestas[0, i] = Console.ReadLine();// [0,x] Contiene las preguntas, [i,x] contiene las respuestas

                                preguntaCompleta[i] = preguntasRespuestas[0, i];

                                for (j = 1; j <= r; j++)
                                {
                                    Console.WriteLine($"Escriba la {j}a respuesta de la pregunta {i}");
                                    preguntasRespuestas[i, j] = Console.ReadLine();

                                    preguntaCompleta[i] += $"\n{j}) " + preguntasRespuestas[i, j]; //compila en un arreglo unidimensional
                                }
                            }

                            encuestaExiste = true; //bandera de encuesta

                            Console.WriteLine("\nSu encuesta fue creada con exito, presione cualquier tecla para retornar al menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case "2": //TOMAR ENCUESTA----------------------------------------------------------------

                            if (!encuestaExiste) //comprueba si ya hay una encuesta
                            {
                                Console.Clear();
                                Console.WriteLine("No se ha encontrado ninguna encuesta, cree una antes de empezar...");
                            }
                            else //toma la encuesta
                            {
                                menu2 = true;
                                do
                                {
                                    Console.WriteLine("\nPor favor escoja una opcion\n1.Vista previa de la encuesta\n2.Realizar encuesta\n3.Regresar");
                                    decision = Console.ReadLine();
                                    switch (decision)
                                    {
                                        case "1"://Vista previa
                                            Console.Clear();
                                            for (int k = 1; k <= p; k++)
                                            {
                                                Console.WriteLine($"Pregunta #{k}\n{preguntaCompleta[k]}");
                                            }
                                            Console.ReadLine();
                                            break;
                                        case "2"://Responder la encuesta
                                            ejecucion = true;
                                            do
                                            {
                                                try
                                                {
                                                    for (int k = 1; k <= p; k++)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine($"Pregunta #{k}\n{preguntaCompleta[k]}");
                                                        int seleccion = int.Parse(Console.ReadLine()); // acumula las respuestas
                                                        if (seleccion > r)
                                                        {
                                                            throw new IndexOutOfRangeException();//excepcion
                                                        }
                                                        else
                                                        {
                                                            cantidadRespuestas[k, seleccion]++; //guardado
                                                        }

                                                    }
                                                }
                                                catch (IndexOutOfRangeException) //catch #1
                                                {
                                                    Console.WriteLine("Error de indice, intente de nuevo");
                                                    Console.WriteLine("Favor seleccione unicamente las respuestas disponibles");
                                                    participantes--;
                                                }
                                                catch (FormatException formEx) //catch #2
                                                {
                                                    Console.WriteLine(formEx.Message);
                                                    Console.WriteLine("Favor solo utlice numeros en este espacio");
                                                    participantes--;
                                                }
                                                participantes++; //acumulador

                                                //ciclo
                                                Console.WriteLine("Desea aplicar la encuesta una vez mas? (s/n)\nAl salir podra ver los resultados");
                                                decision = Console.ReadLine();
                                                switch (decision)
                                                {
                                                    case "s":
                                                    case "S":
                                                    default:
                                                        ejecucion = true;
                                                        break;
                                                    case "n":
                                                    case "N":
                                                        //salida
                                                        Console.Clear();
                                                        Console.WriteLine($"Se entrevisto a un total de {participantes} personas");
                                                        if (participantes > 0) //comprueba si se entrevisto a alguien u ocurrio un error
                                                        {
                                                            for (int k = 1; k <= p; k++)
                                                            {
                                                                Console.WriteLine($"Pregunta #{k}\n{preguntaCompleta[k]}\nRespuestas obtenidas:");
                                                                for (int m = 1; m <= r; m++)
                                                                {
                                                                    Console.WriteLine($"Opcion #{m}: {cantidadRespuestas[k, m]}");
                                                                    if (cantidadRespuestas[k, m] > cantidadRespuestas[k, m - 1])
                                                                    {
                                                                        mayor = m;
                                                                    }
                                                                }
                                                                
                                                                Console.WriteLine($"Respuesta mas popular: #{mayor}\n");
                                                            }
                                                        }
                                                        ejecucion = false; //termina
                                                        break;
                                                }
                                            } while (ejecucion); //termina la encuesta
                                            break;
                                        case "3": //regresar al menu principal
                                            Console.Clear();
                                            menu2 = false;
                                            break;
                                        default: //default
                                            Console.Clear();
                                            Console.WriteLine("La opcion que ha elegido no es valida, porfavor intente de nuevo\n");
                                            break;
                                    }
                                } while (menu2);//sale del segundo menu
                            }
                            break;
                        //regreso al menu -----------------------------------------------------------------
                        case "3": //SALIR
                            menu = false;
                            break;
                        /*case "9": //debug
                            encuestaExiste = true;
                            Console.WriteLine("Una encuesta se materializa (pero no en realidad)");
                            break;*/
                        default: //N/A
                            Console.Clear();
                            Console.WriteLine("La opcion que ha elegido no es valida, porfavor intente de nuevo\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nParece haber ocurrido un problema, por favor solo introduzca valores adecuados de acuerdo al contexto");
                    Console.ReadLine();
                }
             } while (menu);
            //}
            
        }
    }
}
