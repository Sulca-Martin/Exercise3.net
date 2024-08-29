using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioObilagotorio3
{
    public class RegistroTemperatura
    {
        Random random = new Random();
        //Properties
        public int EmpleadoActual;

        private int _temperaturaRegistrada;
        public int TemperaturaRegistrada
        {
            get { return _temperaturaRegistrada; }
            set { _temperaturaRegistrada = value; }
        }

        private Persona _personaDeTurno;
        public Persona PersonaDeTurno
        {
            get { return _personaDeTurno; }
            set { _personaDeTurno = value; }
        }

        private DateOnly? _fechaDeRegistro;
        public DateOnly? FechaDeRegistro
        {
            get { return _fechaDeRegistro; }
            set { _fechaDeRegistro = value; }
        }

        private string? _turnoDeRegistro;
        public string? TurnoDeRegistro
        {
            get { return _turnoDeRegistro; }
            set
            {
                if (value.ToLower() == "mañana" || value.ToLower() == "tarde" || value.ToLower() == "noche")
                    _turnoDeRegistro = value;
                else
                    throw new ArgumentException("El turno debe ser mañana, tarde o noche");
            }
        }

        //Methods
        private Persona PersonaAleatoria(Empleados empleados, int empleadoAnterior)
        {
            while (true)            //Hasta que no se retorne un valor valido, sigue iterando
            {
                EmpleadoActual = random.Next(0,6);
                if (empleados.MostrarTrabajador(empleadoAnterior).Rol != empleados.MostrarTrabajador(EmpleadoActual).Rol & (EmpleadoActual != empleadoAnterior))               //Restringe que elija a la misma persona o el mismo rol
                {
                    return empleados.MostrarTrabajador(EmpleadoActual);
                }
            }
        }

        //Constructor
        public RegistroTemperatura(Empleados empleados, int empleadoAnterior)
        {
            //aca va todo lo aleatorio
            TemperaturaRegistrada = random.Next(-20, 50);
            PersonaDeTurno = PersonaAleatoria(empleados, empleadoAnterior);
        }

     
    }
}
