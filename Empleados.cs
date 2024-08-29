using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioObilagotorio3
{
    public class Empleados
    {
        //Properties
        private List<Persona> _trabajadores;

        public List<Persona> Trabajadores
        {
            get { return _trabajadores; }
            set { _trabajadores = value; }
        }

        //Constructor
        public Empleados()
        {
            Trabajadores = new List<Persona>();
        }

        //Methods
        public void AgregarProfesor(Profesor profesor)
        {
            Trabajadores.Add(profesor);
        }

        public void AgregarPasante(Pasante pasante)
        {
            Trabajadores.Add(pasante);
        }

        public Persona MostrarTrabajador(int valor)
        {
            return Trabajadores[valor];
        }
    }
}
