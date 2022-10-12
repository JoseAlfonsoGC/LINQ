using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_09_Query_progresivo
{
    class Program
    {
        static void Main(string[] args)
        {
            //001-concepto de query progresivo (hacemos un query en varios pasos) lo cual permite agregar lineas de codigo para modificar el resultado final
            //002-into
            //003-concepto envolvimiento (wrapping)
            //004-let
            Console.WriteLine("----------------ejemplo 1---------------");
            string[] postres = { "pay de manzana", "Pastel de chocolate", "manzana caramelizada con pera", "Fresas con crema y manzana", "manzana y pay", "pay pera" };
            bool mayusculas = true;
            //001
            IEnumerable<string> resultado;//declaracion del contenedor

            var manzanas = postres.Where(n => n.Contains("manzana"));//primera parte del query "tomar en cuenta las cadenas que tengan manzana"
            var ordenadas = manzanas.OrderBy(n => n);//segundo paso despues del anterior query, ahora ordenar de manera alfabetica

            if (mayusculas)//si mayusculas esta en true
            {
                resultado = ordenadas.Select(n => n.ToUpper());//las cadenas son modificadas a mayusculas
            }
            else //del caso contrario estan en mayusculas, asi que se conserva el mismo objeto
            {
                resultado = ordenadas;
            }
            Console.WriteLine("Resultado del query progresivo");
            foreach (string op in resultado)
            {
                Console.WriteLine(op);
            }
            Console.WriteLine("------------- ejemplo 2 ------------------");


            //002
            //into se interpreta de dos formas, aqui lo vemos en una continuacion de query
            //solo se puede usar despues de select o group
            //digamos que reinicia el query permitiendo tener otro where, orderby y select

            //ojo con into las variables de rango salen de ambito, p no sera conocido por el query depays

            //practica
            IEnumerable<string> encontrados = from p in postres
                                              where p.Contains("manzana")
                                              orderby p //orden alfabetico
                                              select p //seleccionar
                                           into pays //into permite continuar con el query
                                              where pays.Contains("pera")//del filtro anterior ahora selecciona a los que contienen a pay
                                              select pays;
            foreach (string op in encontrados)
            {
                Console.WriteLine(op);
            }
            Console.WriteLine("---------------ejemplo 3---------------");
            //003
            //envolver queries 
            //es otra opcion de estructura de un query, importante no confundir con subqueries quecoloca el query en la expresion lambda

            IEnumerable<string> mipay = from p in
                                            (
                                                from p1 in postres
                                                where p1.Contains("manzana")
                                                orderby p1
                                                select p1
                                            )
                                        where p.Contains("pay")//antes de ejecutar la parte exterior (query 1) se tiene que terminar la parte interior(query 2)
                                        select p;
            foreach (string postre in mipay)
            {
                Console.WriteLine(postre);
            }
            Console.WriteLine("-----------------ejemplo 4---------------");

            //004
            //let nospermite colocar una nueva variable junto con la de rango
            IEnumerable<string> mispays = from p in postres//el resultado es guardado mispays
                                          let manzanitas = (//el resultado de este query es guardado en manzanitas
                                              from p1 in postres
                                              where p1.Contains("manzana")
                                              orderby p1
                                              select p1
                                              )
                                          where manzanitas.Contains("pay")//despues de los 2 filtros anteriores se cuple el final con where
                                          select p;
            foreach (string op in mipay)
            {
                Console.WriteLine(op);
            }
            Console.ReadKey();
        }
    }
}
