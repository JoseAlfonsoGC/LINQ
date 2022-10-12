using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_06_Operaciones_relacionadas_con_conjuntos
{
    class Program
    {
        static void Main(string[] args)
        {
            //ejemplo de Except, Intersect, Union, Concat, Distinct operaciones con conjuntos

            List<int> conjunto1 = new List<int> { 2, 4, 6, 8, 9 };
            List<int> conjunto2 = new List<int> { 2, 5, 6, 7, 9 };
            
            //Except nos dala diferencia entre dos contenedores [list] 
            
            var expt = (from n1 in conjunto1 select n1)
                .Except(from n2 in conjunto2 select n2);

            Console.WriteLine("Except");

            foreach (int num in expt)
            {
                Console.WriteLine(num);
            }
            //Intersect nos da lo comun entre los dos contenedores
            var ints = (from n1 in conjunto1 select n1)
                .Intersect(from n2 in conjunto2 select n2);

            Console.WriteLine("Intersect");

            foreach (int num in ints)
            {
                Console.WriteLine(num);
            }
            //Union une dos contenedores sin repeticiones
            var un = (from n1 in conjunto1 select n1)
                .Union(from n2 in conjunto2 select n2);

            Console.WriteLine("Union");

            foreach (int num in un)
            {
                Console.WriteLine(num);
            }

            //Concat, contatena los contenedores
            var cnt = (from n1 in conjunto1 select n1)
                .Concat(from n2 in conjunto2 select n2);

            Console.WriteLine("Concat");

            foreach (int num in cnt)
            {
                Console.WriteLine(num);
            }
            //Distinct, remueve los diplicados
            Console.WriteLine("Distinct");
            foreach (int num in cnt.Distinct())
                Console.WriteLine(num);
        }
    }
}
