using EjercicioObilagotorio3;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioObligatorio3
{
    public static class CalcularTemperaturas
    {
        public static void Promedio(RegistroTemperatura[,] temperaturas)
        {
            double suma = 0;
            Console.Clear();
            foreach (var registro in temperaturas)
            {
                suma += registro.TemperaturaRegistrada;
                if (registro.DiaDeRegistro == 31)       //Restringe a que siga leyendo en la matriz, dado que no tiene mas registros guardados
                {
                    break;
                }
            }
            Console.WriteLine($"La temperatura promedio del mes es: {(suma/31).ToString("N2")} grados celcius.");
            Console.ReadKey();
        }

        public static void PromedioSemanal(RegistroTemperatura[,] temperaturas)
        {
            double[] temp_prom = new double[5];
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)
                    {
                        break;
                    }
                    else
                    {
                        temp_prom[i] += temperaturas[i, j].TemperaturaRegistrada;
                    }
                }
                if (i == 4)             //restringimos que la ultima semana al contar solo con 3 dias el mes el promedio debe dividirse por esos dias.
                {
                    temp_prom[i] = temp_prom[i] / 3;
                }
                else
                {
                    temp_prom[i] = temp_prom[i] / 7;
                }
                Console.WriteLine($"La temperatura promedio de la semana {i + 1} es: {temp_prom[i].ToString("N2")} grados Celcius.");
            }
            Console.ReadKey();
        }

        public static void MasAlta(RegistroTemperatura[,] temperaturas)
        {
            int max = -21;                       //Asignamos el valor mas bajo a la variable, forzando a que ingrese en el condicional que guarda el valor maximo
            List<string> temperaturas_max_min = new List<string>();

            Console.Clear();
            for (int i = 0; i < 5; i++)                         //Iteramos la matriz principal de las temperaturas
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)
                    {
                        break;
                    }
                    else
                    {
                        if (max < temperaturas[i, j].TemperaturaRegistrada)          //Si la temperatura anterior es menor lo reemplazamos y restauramos la lista
                        {
                            max = temperaturas[i, j].TemperaturaRegistrada;
                            temperaturas_max_min = new List<string>();              //Se vuelve a instanciar la lista, para que el tamaño de lista sea nuevamente 0

                            temperaturas_max_min.Add((i * 7 + j + 1).ToString());           //Guarda el dia en el tipo de dato string
                        }
                        else if (max == temperaturas[i, j].TemperaturaRegistrada)                 // Si es igual seguira añadiendo a la lista
                        {
                            temperaturas_max_min.Add((i * 7 + j + 1).ToString());
                        }
                    }
                }
            }
            Console.WriteLine($"La temperatura maxima fue de: {max} grados Celcius.");
            if (temperaturas_max_min.Count < 2)                                               //Verificamos si la temperatura maxima ocurrio en varios dias
            {
                Console.WriteLine($"En el dia: {temperaturas_max_min[0]}");
            }
            else
            {
                foreach (var valor in temperaturas_max_min)                      //Si ocurrio en varios dias, corremos el bucle mostrando todos ellos
                {
                    Console.WriteLine($"En el dia: {valor}.");
                }
            }
            Console.ReadKey();
        }

        public static void MasBaja(RegistroTemperatura[,] temperaturas)
        {
            int min = 51;                       //Asignamos el valor mas alto a la variable, forzando a que ingrese en el condicional que guarda el valor minimo
            List<string> temperaturas_max_min = new List<string>();

            Console.Clear();
            for (int i = 0; i < 5; i++)                         //Iteramos la matriz principal de las temperaturas
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)
                    {
                        break;
                    }
                    else
                    {
                        if (min > temperaturas[i, j].TemperaturaRegistrada)          //Si la temperatura anterior es menor lo reemplazamos y restauramos la lista
                        {
                            min = temperaturas[i, j].TemperaturaRegistrada;
                            temperaturas_max_min = new List<string>();              //Se vuelve a instanciar la lista, para que el tamaño de lista sea nuevamente 0
                            temperaturas_max_min.Add((i * 7 + j + 1).ToString());           //Guarda el dia en el tipo de dato string
                        }
                        else if (min == temperaturas[i, j].TemperaturaRegistrada)                 // Si es igual seguira añadiendo a la lista
                        {
                            temperaturas_max_min.Add((i * 7 + j + 1).ToString());           //Guarda el dia en el tipo de dato string
                        }
                    }
                }
            }
            Console.WriteLine($"La temperatura minima fue de: {min} grados Celcius.");
            if (temperaturas_max_min.Count < 2)                                               //Verificamos si la temperatura minima ocurrio en varios dias
            {
                Console.WriteLine($"En el dia: {temperaturas_max_min[0]}");
            }
            else
            {
                foreach (var valor in temperaturas_max_min)                      //Si ocurrio en varios dias, corremos el bucle mostrando todos ellos
                {
                    Console.WriteLine($"En el dia: {valor}.");
                }
            }
            Console.ReadKey();
        }

        public static void MayorAVeinte(RegistroTemperatura[,] temperaturas)
        {
            List<(string, string)> umbral = new List<(string, string)>();      //Lista que guarda el dia y temperatura

            Console.Clear();
            foreach (var valor in temperaturas)
            {
                if (valor.TemperaturaRegistrada > 20)         //Si la temperatura del dia es mayor a 20 grados celcius, guardamos el dia, semana y temperatura en una lista
                {
                    umbral.Add((valor.DiaDeRegistro.ToString(), valor.TemperaturaRegistrada.ToString()));        //Calcula el dia, transforma los valores en string y los guarda    
                }

                if (valor.DiaDeRegistro == 31)       //Restringe a que siga leyendo en la matriz, dado que no tiene mas registros guardados
                {
                    break;
                }
            }
            Console.WriteLine("Itero");
            if (umbral.Count > 0)               //Verificamos que al menos un dia tiene una temperatura mayor a 20 grados
            {
                Console.WriteLine("Los dias con temperaturas mayores a 20 grados son:");
                foreach (var valor in umbral)
                {
                    Console.WriteLine($"Dia: {valor.Item1}, con temperatura de: {valor.Item2} grados Celsius");
                }
            }
            else
            {
                Console.WriteLine("No hay ningun dia del mes que tenga una temperatura superior a 20 grados.");
            }
            Console.ReadKey();
        }
    }
}
