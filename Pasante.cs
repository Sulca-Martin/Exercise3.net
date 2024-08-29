using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioObilagotorio3
{
    public class Pasante : Persona
    {
        //Properties
        private string _numeroLegajo;
        public string NumeroLegajo
        {
            get { return _numeroLegajo; }
            set { _numeroLegajo = value; }
        }
    }
}
