using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_11_Operadores_por_categoria
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hay tres categorias para los operadores de query
            //001secuencia a secuencia (secuencia de entrada, secuencia de salida)
            //002secuencia de entrada, elemento sencillo o escalar
            //003nada de entrada, secuencia de salida

            //001secuencia a secuencia 
            //filtro: WWhere, Take, TakeWhile, Skip, SkipWhile, Distinct
            //Proyeccion: Select, SelectMany
            //Union: Join, GroupJoin, Zip
            //Ordenamiento: OrderBy, Thenby, Reverse
            //Agrupamiento: GroupBy
            //Operadorer de conjunto: Concat, Union, Intersect, Exccept
            //Conversion import: OfType, Cast
            //Conversion export: ToArray, ToDictionary, ToLookup, AsEnumerable, Asqueryable

            //002 Secuencia de entrada a elemento oescalar
            //Operadores de elemento: First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrdeFault, 
            //Agregacion: Aggregate, Average, Count, LongCount, Sum, Max, Min
            //Cuantificador: All, Any, Contains, SequenceEqual

            //003 nada de entrada, secuencia de salida
            //Generacion: Empty, Range, Repeat
            //***********************************************************************************




            //001 secuencia a secuencia [filtro]
            //where regresa un subconjunto de elementos que satisfacen una coleccion 
            //Take regresa el primer elemento n e ingnora el resto
            //Skip ignora los primeros n elementos y regresa el resto
            //TakeWhile emite elementos de la secuencia de entrada hasta que el predicado es falso
            //SkipWhite ignora los elementos de la secuencia de entrada hasta que el predicado es falso, luego va a emitir el resto
            //Distinct regresa una secuencia que excluye a los duplicados

            //Where
            //Aparte de lo que hemos visto, where permite un segundo argumento de tipo int que simboliza el indice
            //Esto se conoce como filtrado por indice

            string[] postres = { "Pay de manzana", "Pastel de chocolate", "Manzana caramelizada", "Fresas con crema" };
            Console.WriteLine("-----------------where------------------");
            //Indice en un where
            IEnumerable<string> r1 = postres.Where((n, i) => i % 2 == 0);

            foreach (string postre in r1)
            {
                Console.WriteLine(postre);
            }
            Console.WriteLine("------------------StartsWith-----------------");
            
            IEnumerable<string> r2 = from p in postres
                                     where p.StartsWith("pay")//si determinado elemento inicia con algo en particular
                                     select p;
            foreach (string postre in r2)
            {
                Console.WriteLine(postre);
            }
            Console.WriteLine("-----------------EndsWith------------------");
            //todos los elemetos que finalizan
            IEnumerable<string> r3 = from p in postres
                                     where p.EndsWith("manzana")///si determinado elemento termina con algo en particular
                                     select p;
            foreach (string postre in r3)
            {
                Console.WriteLine(postre);
            }
            Console.WriteLine("-----------------TakeWhile------------------");
            //TakeWhile enumera la secuencia de entrada y emite cada elemento hasta que el predicado es falso
            //ingnora al resto

            int[] numeros = { 1, 5, 7, 3, 5, 9, 8, 11, 2, 4 };
            //                         Expresion lambda es un predicado
            var r4 = numeros.TakeWhile(n => n < 8);//toma encuenta hasta que es falso [9, 8, 11, 2, 4] serian los valores que no toma encuenta y solo toma encuenta [1, 5, 7, 3, 5]

            foreach (int n in r4)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("-----------------SkipWhile------------------");
            //SkipWhile enumera la secuencia ignora los elementos hasta que el  predicado es falso y emite el resto de valores

            var r5 = numeros.SkipWhile(n => n < 8);//toma encuenta hasta que el falso [9, 8, 11, 2, 4] serian los valores que toma encuenta y ignora [1, 5, 7, 3, 5]

            foreach (int n in r5)
            {
                Console.WriteLine(n);
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
            //Proyeccion
            //select transforma el elemento de entrada con la expresion lambda
            //selectMany transforma el elemento la aplana y concatena con las subsecuencias resultantes

            //hemos usado select con tipo anonimo o para tomar el elemento completamente

            //proyeccion indexada 
            Console.WriteLine("-------Proyeccion indexada------\r\n");
            IEnumerable<string> r6 = postres.Select((p, i) => "Indice " + i + "para el postre" + p); //agrega un indice

            foreach (string n in r6)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("------------------SelectMany---------------------");

            //selectMany
            //en select cada elemento de entrada produce un elemento de salida
            //selectMany produce 0..n elementos

            Console.WriteLine("-----select Many -------- \r\n");
            IEnumerable<string> r7 = postres.SelectMany(p => p.Split());//lo regresa "aplanado"

            foreach (string n in r7)
            {
                Console.WriteLine(r7);
            }
            Console.WriteLine("-----------");

            //comparacion con select
            IEnumerable<string[]> r8 = postres.Select(p => p.Split());//regresa un arreglo de cadenas no esta "aplanado"

            foreach (string[] n in r8)
            {
                Console.WriteLine("-");
                foreach (string m in n)
                {
                    Console.WriteLine(m);
                }
            }



            //select con multiples variables de rango
            Console.WriteLine("---- select con multiples variables----\r\n");

            IEnumerable<string> r9 = from p in postres //p variable 01 guarda la informacion del contenedor
                                     from p1 in p.Split()//p1 variable 02 guarda la divicion de las cadenas 
                                     select p1 + "===>" + p; //inpresion + concatenacion de las dos variables

            foreach (string op in r9)
            {
                Console.WriteLine(op);
            }

            Console.WriteLine("---------select con multiples variables--------");
            IEnumerable<string> r10 = from p in postres 
                                      from p1 in postres
                                      select "yo quiero:" + p1 + " y tu quieres: " + p;//lo anterior genera todas las combinaciones posibles en los elementos del contenedor

            foreach (string op in r10)
            {
                Console.WriteLine(op);
            }
            Console.WriteLine("-----------------");

            //////////////////////////////////////////////////////////////////////////

            //Union-Joing
            //join une los elementos de dos collecciones en un solo conjunto
            //GroupJoin es como Join pero da un resultado jerarquico
            //zip enumera dos secuencias y aplica una funcion a cada par

            Console.WriteLine("-------Join-----\r\n");

            List<CEstudiante> estudiantes = new List<CEstudiante>
            {
                new CEstudiante("Ana",100),//el segundo valor es un id para referenciar a la siguiente list
                new CEstudiante("Mario",150),
                new CEstudiante("Susana",180)
            };

            List<CCurso> cursos = new List<CCurso>
            {
                new CCurso("Programacion",100),//el segundo valor es un foreignkey para referenciar a la siguiente list
                new CCurso("Orientado a objetos",150),
                new CCurso("Programacion",150),
                new CCurso("Programacion",180),
                new CCurso("UML",100),
                new CCurso("Orientado objetos",100),
                new CCurso("UML",180),
            };
            var listado = from e in estudiantes
                          join c in cursos on e.Id equals c.Id //join para trabajar con 2 tablas //los foreignkey que sean iguales con id se unen
                          select e.Nombre + "Esta en curso " + c.Curso;

            foreach (string n in listado)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();

            ///////////////////////////////////////////////////////////////////////
            ///001-GroupJoin e into
            ///002-zip
            ///003-OrderBy
            ///004-OrderByDescending
            ///

            //001
            Console.WriteLine("-------GrouoJoin------");

            var listado2 = from e in estudiantes
                           join c in cursos on e.Id equals c.Id
                           into tempListado //es lo mismo del ejemplo anterior solo que con [into]
                           select new { estudiante = e.Nombre, tempListado };//la impresion es en jerarquia
            foreach (var lst in listado2)
            {
                Console.WriteLine(lst.estudiante);

                foreach (var lst2 in lst.tempListado)
                {
                    Console.WriteLine(lst2);
                }
            }

            //002
            //regresa una secuencia que aplica una funcion a cada par 
            Console.WriteLine("-----zip-----");

            string[] helados = { "Chocolate", "Vainilla", "Fresa", "Limon" };

            IEnumerable<string> r12 = postres.Zip(helados, (p, h) => p + "con helado de " + h);

            foreach (string n in r12)
            {
                Console.WriteLine(n);
            }
            //////////////
            ///Ordenamiento
            ///orderby, thenBy Ordena en orden ascendente
            ///OrderByDescending, ThenByDescending Ordena en orden descendente
            ///Reverse regrea en el orden inverso
            ///
            Console.WriteLine("--Ordenamiento--");

            IEnumerable<int> numOrder = numeros.OrderBy(n => n);//ordenamiento ascendente
            IEnumerable<int> numDes = numeros.OrderByDescending(n => n);//ordenamiento descendente

            foreach (int n in numOrder)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("--------------");
            foreach (int n in numDes)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("--------------");
            string[] palabras = { "hola", "piedra", "pato", "pastel", "carros", "auto" };// ordenar cadenas

            IEnumerable<string> palabrasOrd = palabras.OrderBy(p => p.Length).ThenBy(p => p);//length permitye ordenar por tamaño

            foreach (string n in palabrasOrd)
            {
                Console.WriteLine(n);
            }
            ////////////////////////////////////////////////////////////////////////
            ///Agrupamiento
            ///GroupBy Agrupa uan secuencia en subsecuencias
            Console.WriteLine("---------Agrupamiento-------------");

            string[] archivos = System.IO.Directory.GetFiles("c:\\inter");

            Console.WriteLine("Archivos obtenidos por GetFiles");
            foreach (string n in archivos)
            {
                Console.WriteLine(n);
            }
            //Agrupamiento basado en la extencion
            //Adentro de ()colocamos el criterio de agrupamiento
            var archivoAg = archivos.GroupBy(a => System.IO.Path.GetExtension(a));//agrupar los archivos contenidos en [c:\\inter] por extension [.GetExrtension()]

            Console.WriteLine("Resultado agrupado");

            foreach (IGrouping<string, string> g in archivoAg)
            {
                Console.WriteLine("Archivo de extension {0}", g.Key);
                foreach (string a in g)
                {
                    Console.WriteLine("\t {0}", a);
                }
            }
            //////////////////////////////////////////
            ///de elemento
            ///First, FirstOrdefault    Regresa primer elemento de la secuencia
            ///Last, LastOrDefault      regresa el ultimo elemento de la secuencia
            ///Single, SingleOrdefault  Equivalente a First, FirstOrdefault pero lanza un excepcion si hay mas de uno
            ///ElementAt, Elemeny¿tAtOrDefault Regresa el elemento de determinada posicion
            ///DefaultIfEmpy Regresa el elemento de default si la secuencia no tiene elemento

            Console.WriteLine("-----De elemento-----");
            //obtenemos el primero
            int primero = numeros.First();
            Console.WriteLine(primero);

            //primero que se cumpla cierta condicion
            int primerob = numeros.First(n => n % 2 == 0);
            Console.WriteLine(primerob);

            //primero que cumpla o default
            int primeroc = numeros.FirstOrDefault(n => n % 57 == 0);
            Console.WriteLine(primeroc);

            ///////////////////////////////////////
            ///De agregacion
            //Count, LongCount regresa la cantidad de elementos en la secuencia int o int64
            //Min regresa el elemento menor de la secuencia 
            //Max regresa el elemento mayor de la secuencia 
            //sum regresa la sumatoria de los elementos 
            //Average regresa el promedio de los elementos
            //Aggregate hace una agregacion usando nuestro algoritmo
            ///Sum
            ///Aggregate
            ///All
            ///SequenceEqual
            ///Emptyy
            ///Repeat
            ///Range

            Console.WriteLine("---------------------De agregacion--------------------");
            int sumatoria = numeros.Sum();
            Console.WriteLine(sumatoria);

            int[] numeros2 = { 1, 2, 3, 4, 5 };

            //en este caso la semilla es cero, si no se pone la semilla, toma el primer valor
            int agregado = numeros2.Aggregate(0, (t, n) => t + (n * 2));
            Console.WriteLine(agregado);



            //////////////////////////////////////////////////////////////////
            /// Cuantificadores
            /// Contains        regresa true si la secuencia contiene al elemento
            /// Any             regresa true si un elemento satisface al predicado
            /// All             regresa true si todos los elementos satisfacen al predicado
            /// SequenceEqual   regresa true si la segunda secuencia tiene elementos identicos a la de entrada

            Console.WriteLine("------- Cuantificadores------");

            bool todos = numeros2.All(n => n < 10);
            Console.WriteLine(todos);

            bool iguales = numeros2.SequenceEqual(numeros);
            Console.WriteLine(iguales);

            ////////////////////////////////////////////////////
            ///Generacion
            ///Empty    crea una secuencia vacia
            ///Repeat   Crea una secuencia de elementos que se repiten
            ///Range    Crea una secuencia de enteros
            ///
            Console.WriteLine("------------Generacion--------------");
            var vacia = Enumerable.Empty<int>();

            foreach (int n in vacia)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("-----------Repeat---------");

            var repetir = Enumerable.Repeat("hola", 5);
            
            foreach (string n in repetir)
                Console.WriteLine(n);

            var rango = Enumerable.Range(5, 15);//inicio, cantidad de elementos

            foreach(int n in rango)
            {
                Console.WriteLine(n);
            }

            Console.ReadKey();
        }
    }
}
