using EjercicioObligatorio3;
using Microsoft.Win32;
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
        //Properties
        public RegistroTemperatura[,] temperaturas { get; set; }     //Matriz para guardar las temperaturas del mes

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

        public void VerRegistro()           //devuelve el dia, temperatura, turno y persona de turno
        {
            Console.Clear();
            foreach (var registro in temperaturas)
            {
                Console.WriteLine($"Dia : {registro.DiaDeRegistro}, temperatura: {registro.TemperaturaRegistrada},  turno: {registro.TurnoDeRegistro},   persona de turno: {registro.PersonaDeTurno.Name}");
                
                if (registro.DiaDeRegistro == 31)       //Restringe a que siga leyendo en la matriz, dado que no tiene mas registros guardados
                {
                    break;
                }
            }
            Console.ReadKey();
        }

        public void VerTemperaturas()
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)        //Restringe a que siga leyendo en la matriz, dado que no tiene mas registros guardados
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"{temperaturas[i, j].TemperaturaRegistrada} ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public void VerTemperaturaDiaEspecifico(int dia)
        {
            Console.Clear();
            if (dia < 1 | dia > 31)
                throw new ArgumentException("El dia debe ser entre 1 a 31");
            else
            {
                int semana = dia / 7;
                dia = dia % 7 - 1;
                Console.WriteLine(temperaturas[semana, dia].TemperaturaRegistrada);
            }
            Console.ReadKey();
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
                        temperaturas[i, j].DiaDeRegistro = i * 7 + j + 1;               //Guardamos el dia en el que se registro
                        PersonaAnterior = temperaturas[i, j].EmpleadoActual;
                    }
                }
            }
        }
    }
}
