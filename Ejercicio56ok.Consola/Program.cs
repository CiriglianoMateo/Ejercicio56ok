using System.Runtime.InteropServices;

namespace Ejercicio56ok.Consola
{
        internal class Program
        {
            static void Main(string[] args)
            {

                double Reaumur, Fah;
                double Celsius;
                int CantidadIngresada = 0, CantidadSuperior15 = 0;
                double PromedioTemperaturas = 0;
                bool Seguir = true;

                do
                {
                    //Esto es parte del poder ingresar letras sin que el programa se cierre

                    Celsius = PedirDoubleEntreMinYMax("Ingrese el valor de la temperatura en grados celsius (0 para terminar): ", -80, 80);
                    if (Celsius != 0)
                    {
                        Fah = ConvertirCelsiusFah(Celsius);
                        Reaumur = ConvertirCelsiusReaumur(Celsius);
                        CantidadIngresada++;
                        PromedioTemperaturas = +Celsius;

                        if (Celsius > 15)
                        {
                            CantidadSuperior15++;
                        }
                        Console.WriteLine($"{Celsius} - {Fah} - {Reaumur}");
                    }
                    else
                    {
                        Seguir = false;
                    }
                } while (Seguir);

                PromedioTemperaturas = PromedioTemperaturas / CantidadIngresada;
                Console.WriteLine($"Promedio de temperaturas ingresadas {PromedioTemperaturas}");
                Console.WriteLine($"Se ingresaron {CantidadIngresada} temperaturas");
                Console.WriteLine($"Se ingresaron {CantidadSuperior15} temperaturas superiores a 15 grados");
                Console.ReadLine();

            }


            //funcion para calcular Reaumur

            private static double ConvertirCelsiusReaumur(double celsius)
            {
                return 0.8 * celsius;
            }

            //Funcion para calcular Fahrenheit

            private static double ConvertirCelsiusFah(double celsius)
            {
                return 1.8 * celsius + 32;
            }



            //Para que no nos cierre el programa a la hora de ingresar letras

            private static double PedirDouble(String Mensaje)
            {
                double nro = 0;
                do
                {
                    Console.Write(Mensaje);
                    string strConsola = Console.ReadLine();
                    if (!double.TryParse(strConsola, out nro))
                    {
                        Console.WriteLine("Numero mal ingresado");

                    }
                    else
                    {
                        break;
                    }

                } while (true);
                return nro;
            }
            private static double PedirDoubleEntreMinYMax(String Mensaje, double min, double max)
            {
                double nro = 0;
                do
                {
                    Console.Write(Mensaje);
                    string strConsola = Console.ReadLine();
                    strConsola = strConsola.Replace('.', ',');
                    if (!double.TryParse(strConsola, out nro))
                    {
                        Console.WriteLine("Numero mal ingresado");

                    }
                    else if (nro >= min && nro <= max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"el numero debe estra entre {min} y {max}");
                    }

                } while (true);
                return nro;

            }
        }
    }

