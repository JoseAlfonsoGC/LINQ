using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02_Query_desde_metodos
{
    class CclaseExplicita
    {
        //arreglo sobre el cual trabajar
        private static string[] postres = { "Pay de manzana", "Pastel de chocolate", "Manzana caramelizada", "Fresas con crema" };

        //ejemplo 01 query
        //no puede usarse de forma implicita
        //dibe de ser estatico
        private static IEnumerable<string> encontrados = from p in postres
                                                         where p.Contains("manzana")
                                                         orderby p
                                                         select p;
        //ejemplo02
        //el metodo regresa y todo se trabaja internamente
        public static IEnumerable<int> obtenerNumerosPares()
        {
            int[] numero = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };

            IEnumerable<int> pares = from n in numero
                                     where n % 2 == 0
                                     select n;

            return pares;
        }
        //metodo que regresa el resultado del query
        public static IEnumerable<string> ObtenerPostres()
        {
            return encontrados;
        }
        //metodo que regresa el resultado de un query inmediato
        public static int[] ObtenerNumerosImpares()
        {
            int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };

            var resultado = from n in numeros
                            where n % 2 != 0 //numeros inpares
                            select n;
            return resultado.ToArray();
        }
    }
}
