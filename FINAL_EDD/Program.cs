﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections;
using System.IO;

namespace FINAL_EDD
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
            CONSIGNA

            Realizar un programa que por medio de una Cola permita el ingreso de Pedidos.
            Los elementos deberán ser un número entero, validar que el número sea mayor a cero y menor que 999.

            El menú del programa tendrá las siguientes opciones:

            1.	Crear Cola
            2.	Borrar Cola
            3.	Agregar Pedido
            4.	Borrar Pedido
            5.	Listar todos los Pedidos.
            6.	Listar último Pedido.
            7.	Listar primer Pedido.
            8.	Cantidad de Pedido.
            9.	Salir 
            Estas son las opciones básicas del menú, se deberán agregar 2 opciones más.
            Cada elemento que se liste debe aparecer con el formato “1 – elemento”.
            */



            /*
             
            FINAL EDD TEMA 2 - COLA

            Marco teorico:
            El programa se basa en diferentes acciones sobre una COLA de Pedidos, donde cada pedido esta compuesto por "id - nombre".
            Sobre el id recaen las validaciones de entero y de rango entre 0 y 999.
            Solo existe una cola por ejecucion.

            */


            Queue<Pedidos> cola = new Queue<Pedidos>();  //Adv: Me tiraba error porque al crear el queue no aclaraba el tipo de datos pedidos



            List<Queue<Pedidos>> listaCola = new List<Queue<Pedidos>>();  //creo esta lista de colas para validar si la cola NO existe
            List<string> historial = new List<string>(); //Para el archivo log

            string opc = "0";
            while (opc != "12") //Creamos un ciclo para que se repita el menu hasta que el usuario quiera salir
            {
                historial.Add("Menu");

                Console.Clear();
                Console.WriteLine("\nFINAL ESTRUCTURA DE DATOS TEMA 2 - COLA -");
                Console.WriteLine("Carolina Nakasone\n");
                Console.WriteLine("\nMenu Principal\n");
                Console.WriteLine("1)  Crear Cola");
                Console.WriteLine("2)  Borrar Cola");
                Console.WriteLine("3)  Agregar Pedido");
                Console.WriteLine("4)  Borrar Pedido");
                Console.WriteLine("5)  Listar todos los Pedidos");
                Console.WriteLine("6)  Listar ultimo Pedido");
                Console.WriteLine("7)  Listar primer Pedido");
                Console.WriteLine("8)  Cantidad de pedido");
                Console.WriteLine("9)  Modificar descripcion del Pedido ");
                Console.WriteLine("10) Generar documento de Pedidos para imprimir");
                Console.WriteLine("11) Ver historial/log");
                Console.WriteLine("12) Salir");
                Console.Write("\r\nElija una opcion: ");
                opc = Console.ReadLine();


                

                switch (opc) //Menu
                {
                    case "1":
                        historial.Add("Crear Cola");
                        cola = CrearCola(listaCola); // la guardo en la variable que sera usada por los otros cases
                        break;

                    case "2":
                        historial.Add("Borrar Cola");
                        if (!listaCola.Any())  //valida que la cola exista
                        {
                            Console.ForegroundColor = ConsoleColor.Red;  //cambia el color de texto a rojo
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();                      
                        }
                        else
                        {
                            BorrarCola(cola, listaCola);
                        }                        
                        break;

                    case "3":
                        historial.Add("Agregar Pedido");
                        if (!listaCola.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();
                        }
                        else
                        {
                            cola = AgregarPedido(cola);
                        }                            
                        break;

                    case "4":
                        historial.Add("Borrar Pedido");
                        if (!listaCola.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();
                        }
                        else
                        {
                            cola = BorrarPedido(cola);
                        }                            
                        break;

                    case "5":

                        historial.Add("Listar todos los pedidos");
                        if (!listaCola.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();
                        }
                        else
                        {
                            ListarPedidos(cola);
                        }                            
                        break;

                    case "6":
                        historial.Add("Listar ultimo pedido");
                        if (!listaCola.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();
                        }
                        else
                        {
                            ListarUltimoPedido(cola);
                        }                            
                        break;

                    case "7":
                        historial.Add("Listar primer pedido");
                        if (!listaCola.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();
                        }
                        else
                        {
                            ListarPrimerPedido(cola);
                        }                            
                        break;

                    case "8":
                        historial.Add("Cantidad de Pedidos");
                        if (!listaCola.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();
                        }
                        else
                        {
                            CantidadPedido(cola);
                        }                            
                        break;

                    case "9":
                        historial.Add("Modificar Pedido");
                        if (!listaCola.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();
                        }
                        else
                        {
                            cola = ModificarPedido(cola); ;
                        }
                        break;


                    case "10":
                        historial.Add("Generar Documento pero imprimir");
                        if (!listaCola.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No existe la cola.");
                            Console.ResetColor();
                        }
                        else
                        {
                            ImprimirPedido(cola);
                        }                            
                        break;
      
                    
                    case "11":
                        historial.Add("Historial de consultas");
                        Console.WriteLine("\nHistorial de consultas/log:\n");
                        foreach (string cadena in historial)
                        {
                            Console.WriteLine(cadena);
                        }
                        Console.ReadKey();
                        break;

                    case "12":
                        Console.WriteLine("\nNos vemos!");
                        Console.ReadKey();
                        return;


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Esa opcion no es valida.");
                        Console.ResetColor();
                        break;


                }
                Console.WriteLine("\nPresione cualquier tecla para continuar.");
                Console.ReadKey();
            }



            Console.ReadKey();




        }


        public static Queue<Pedidos> CrearCola(List<Queue<Pedidos>>listaCola)
        {

            Queue<Pedidos> nuevaCola = new Queue<Pedidos>();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se creo la cola correctamente.");
            Console.ResetColor();
            listaCola.Add(nuevaCola);
            return nuevaCola;
        }

        public static void BorrarCola(Queue<Pedidos> cola, List<Queue<Pedidos>> listaCola)
        {

            Console.WriteLine("Esta seguro que desea eliminar la cola? Si/no: ");
            string opc = Console.ReadLine().ToLower();


            if (opc == "si")
            {
                cola.Clear();
                listaCola.Remove(cola);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSe elimino la cola correctamente.");
                Console.ResetColor();
                return;
                
            }

            if (opc == "no")
            {
                return;
            }

            if (opc != "si" || opc != "no")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDebe ingresar una respuesta valida.");
                Console.ResetColor();
                return;
            }


        }


        public static Queue<Pedidos> AgregarPedido(Queue<Pedidos> cola)
        {
            List<int> listaID = new List<int>(); //creo esta lista con los id de la cola para verificar si ya existe luego en la validacion

            foreach (Pedidos pedido in cola)
            {
                listaID.Add(pedido.Id);
            }


            Console.WriteLine("Ingrese el id del pedido: ");
            var string_id = Console.ReadLine();

            //valido que el id sea un entero, ente en el rango 0-999 inclusive y que no exista ya

            while (ValidacionIdInt(string_id) == false || ValidacionIdRango(string_id) == false || listaID.Contains(Convert.ToInt32(string_id)) == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSe aceptan solo numeros enteros.");
                Console.WriteLine("Se aceptan numeros entre 0 y 999.");
                Console.WriteLine("Recuerde que no puede haber dos ID iguales.");
                Console.WriteLine("Ingrese un id correcto:");
                Console.ResetColor();
                string_id = Console.ReadLine();

            }
            int id = Convert.ToInt32(string_id);


            Console.WriteLine("\nIngrese el nombre del pedido: ");
            string nombre = Console.ReadLine();

            Pedidos nuevoPedido = new Pedidos(id, nombre);

            cola.Enqueue(nuevoPedido);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSe agrego el pedido correctamente.");
            Console.ResetColor();

            return cola;

        }





        public static Queue<Pedidos> BorrarPedido(Queue<Pedidos> cola)
        {
            List<int> listaID = new List<int>();

            foreach (Pedidos pedido in cola)
            {
                listaID.Add(pedido.Id);
            }

            if (cola.Count() == 0)  //valida que la cola contenga elementos a eliminar
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La cola esta vacia.");
                Console.ResetColor();
                return cola;
            }
            else
            {
                Console.WriteLine("Ingrese el id del pedido: ");
                var string_id = Console.ReadLine();

                while (ValidacionIdInt(string_id) == false || ValidacionIdRango(string_id) == false || listaID.Contains(Convert.ToInt32(string_id)) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSe aceptan solo numeros enteros.");
                    Console.WriteLine("Se aceptan numeros entre 0 y 999.");
                    Console.WriteLine("El id debe existir en la cola.");
                    Console.WriteLine("Ingrese un id correcto:");
                    Console.ResetColor();
                    string_id = Console.ReadLine();

                }

                int id = Convert.ToInt32(string_id);

                //elimina el elemento donde coincide el id
                cola = new Queue<Pedidos>(cola.Where(x => x.Id != id));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSe elimino el pedido correctamente.");
                Console.ResetColor();

                return cola;
            }


        }


        public static void ListarPedidos(Queue<Pedidos> cola)
        {
            if (cola.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La cola esta vacia.");
                Console.ResetColor();
            }
            else
            {
                foreach (Pedidos ped in cola)
                {
                    Console.WriteLine("{0} - {1}", ped.Id, ped.Nombre);
                }
            }
        }


        public static void ListarPrimerPedido(Queue<Pedidos> cola)
        {
            if (cola.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La cola esta vacia.");
                Console.ResetColor();
            }
            else
            {
                Pedidos ped = cola.Peek(); //accede al primer elemento
                Console.WriteLine("{0} - {1}", ped.Id, ped.Nombre);
            }
        }

        public static void ListarUltimoPedido(Queue<Pedidos> cola)
        {
            if (cola.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La cola esta vacia.");
                Console.ResetColor();
            }
            else
            {
                Pedidos ped = cola.Last(); //accede al ultimo
                Console.WriteLine("{0} - {1}", ped.Id, ped.Nombre);
            }
        }


        public static void CantidadPedido(Queue<Pedidos> cola)
        {
            int cantidad = cola.Count();
            Console.WriteLine("\nLa cantidad de pedidos es {0}", cantidad);
        }




        public static Queue<Pedidos> ModificarPedido(Queue<Pedidos> cola)
        {
            List<int> listaID = new List<int>();

            foreach (Pedidos pedido in cola)
            {
                listaID.Add(pedido.Id);
            }

            if (cola.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La cola esta vacia.");
                Console.ResetColor();
                return cola;
            }
            else
            {
                Console.WriteLine("\nIngrese el id del pedido a modificar: ");
                var string_id = Console.ReadLine();

                while (ValidacionIdInt(string_id) == false || ValidacionIdRango(string_id) == false || listaID.Contains(Convert.ToInt32(string_id)) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSe aceptan solo numeros enteros.");
                    Console.WriteLine("Se aceptan numeros entre 0 y 999.");
                    Console.WriteLine("El id debe existir en la cola.");
                    Console.WriteLine("Ingrese un id correcto:");
                    Console.ResetColor();
                    string_id = Console.ReadLine();

                }

                int id = Convert.ToInt32(string_id);



                foreach (Pedidos pedido in cola)
                {
                    if (pedido.Id == id)
                    {
                        Console.WriteLine("\nIngrese el nuevo nombre/descripcion:");
                        pedido.Nombre = Console.ReadLine();
                    }                    
                }



                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSe modifico el pedido correctamente.");
                Console.ResetColor();

                return cola;
            }


        }







        public static void ImprimirPedido(Queue<Pedidos> cola) 
        {
            try
            {
                Console.WriteLine("\nIngrese el nombre del archivo sin extension: "); 

                string fileName = Console.ReadLine() + ".txt";  

                StreamWriter writer = File.CreateText(fileName);
                //De la clase Streamwriter usamos metodo Createtext que crea o abre un archivo con el nombre que indiquemos.

                DateTime today = DateTime.Now;  //Usamos datetime para agregar la fecha al archivo
                DateTime dateonly = today.Date;

                writer.WriteLine("Cola de pedidos del dia {0}.", today.ToString("MM/dd/yyyy HH:mm")); 

                writer.WriteLine("\nTotal pedidos: {0} \n", cola.Count() );

                foreach (Pedidos ped in cola)
                {
                    writer.WriteLine("{0} - {1}", ped.Id, ped.Nombre);
                }

                writer.Close(); 

                FileInfo fi = new FileInfo(fileName); //Uso Clase file info para acceder a informacion del archivo y luego poder consultar el directorio
                DirectoryInfo di = fi.Directory; //Guardo el directorio en una variable para indicarselo al usuario

                Console.WriteLine("\nEl archivo {0} esta listo para imprimir en la ruta {1}.", fileName.ToUpper(), di);
            }

            catch (IOException) 
            {
                Console.WriteLine("\nError con el archivo.");
            }



        }

        public static bool ValidacionIdInt (string id_string) //valida si es entero, si lo es devuelve true, si no, false
        {
            int id;
            if (!int.TryParse(id_string, out id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidacionIdRango(string id_string) //valida si esta en el rango 0-999 inclusive, caso contrario devuelve false
        {
            int id = Convert.ToInt32(id_string);
            if (id < 0 || id > 999)
            {
                return false;
            }
            else
            {
                return true;
            }
        }







    }
}

