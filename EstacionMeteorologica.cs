using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EjercicioObilagotorio3
{
    public class EstacionMeteorologica
    {
        private RegistroTemperatura[,] temperaturas;     //Matriz para guardar las temperaturas del mes

        private int PersonaAnterior;                     //Valor que sera ocupado para elegir la persona de turno aleatoriamente

        //Constructor carga automatica
        public EstacionMeteorologica()
        {
            temperaturas = new RegistroTemperatura[5, 7];
            PersonaAnterior = 0;
        }

        //Method
        public RegistroTemperatura RegistrarTemperatura(Empleados empleados, int personaAnterior)
        {
            return new RegistroTemperatura(empleados, personaAnterior);
        }

        public void VerTemperaturas()
        {
            //devuelve solo las temperaturas
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)        //Restringe que se guarden valores fueras del mes, a pesar de que ya sean valores igual a 0
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"{ temperaturas[i, j].TemperaturaRegistrada} ");     //Llama al constructor de temperatura para que lo genere
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public void VerLosTurnosDeEmpleados()
        {
            //devuelve solo las temperaturas
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)        //Restringe que se guarden valores fueras del mes, a pesar de que ya sean valores igual a 0
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"{temperaturas[i, j].PersonaDeTurno.Name} ");     //Llama al constructor de temperatura para que lo genere
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public void CargaManual()
        {
        }

        public void CargaAutomatica(Empleados empleados)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)        //Restringe que se guarden valores fueras del mes, a pesar de que ya sean valores igual a 0
                    {
                        break;
                    }
                    else
                    {
                        temperaturas[i, j] = RegistrarTemperatura(empleados, PersonaAnterior);     //Llama al constructor de temperatura para que lo genere
                        PersonaAnterior = temperaturas[i, j].EmpleadoActual;
                    }
                }
            }
        }
    }
}
