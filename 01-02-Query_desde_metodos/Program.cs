using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02_Query_desde_metodos
{
    class Program
    {
        static void Main(string[] args)
        {
            //obtener resultados del query desde metodos

            //Invocamos el metodo
            IEnumerable<int> resultados = CclaseExplicita.obtenerNumerosPares();

            //Mostrar los resultados
            foreach (int num in resultados)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("-----------------");

            IEnumerable<string> postres = CclaseExplicita.ObtenerPostres();

            //mostramos resultado
            foreach (string p in postres)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("-----------------");

            int[] impares = CclaseExplicita.ObtenerNumerosImpares();

            //
            foreach (int m in impares)
            {
                Console.WriteLine(m);
            }
            Console.ReadKey();
        }
    }
}
