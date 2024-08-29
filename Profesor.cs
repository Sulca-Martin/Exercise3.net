using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioObilagotorio3
{
    public class Profesor : Persona
    {
        //Properties
        private string _numeroMatricula;
        public string NumeroMatricula
        {
            get { return _numeroMatricula; }
            set { _numeroMatricula = value; }
        }
    }
}
