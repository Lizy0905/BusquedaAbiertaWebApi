using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_C
{
    internal class Program
    {
        static void Main(string[] args)
        {

           

            //Se crea una instancia y se utiliza la variable dentro del metodo.
            Singleton instancia1 = Singleton.Metodo();
            Singleton instancia2 = Singleton.Metodo();

            // Comprobando si las instancias son iguales
            Console.WriteLine("Instancia 1: " + instancia1);
            Console.WriteLine("Instancia 2: " + instancia2);
            Console.WriteLine("¿Son las mismas instancias?: " + (instancia1 == instancia2));
            Console.ReadKey();

            //Se utiliza en login para iniciar sesion.

        }
    }
}
