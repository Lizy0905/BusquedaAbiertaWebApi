using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_C
{
    public class Singleton
    {

        //Pasos para utilizar el patron de diseño singleton

        // 1.- Crear un construcctor vacio y ponerlo en privado

        private Singleton()
        {

        }

        // 2.- Crear variable de lectura. 

        private static Singleton shared;



        public static Singleton Metodo()
        {
            return shared;

        }



    }
}
