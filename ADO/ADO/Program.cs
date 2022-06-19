using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ADOEstatus aDOEstatus = new ADOEstatus();

            string opcion = null;
            do
            {

                Console.WriteLine("1.-Consultar Todos");
                Console.WriteLine("2.-Consultar Solo uno");
                Console.WriteLine("3.-Agregar");
                Console.WriteLine("4.-Actualizar");
                Console.WriteLine("5.-Eliminar");
                Console.WriteLine("6.-Terminar");
                opcion = Console.ReadLine();

                Console.Clear();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("1.-Consultar Todos");
                        aDOEstatus.Consultar();
                        
                        break;
                    case "2":
                        Console.WriteLine("2. Consultar Solo uno");
                        Console.WriteLine("Agrega el Id del estado que deseas buscar");
                        int id = Convert.ToInt32(Console.ReadLine());
                        //aDOEstatus.Consultar(id);
                        Estatus estatus = aDOEstatus.Consultar(id);
                        Console.WriteLine($"{estatus.id.ToString()}, {estatus.nombre.ToString()}");
                     
                        break;
                    case "3":
                        Estatus estat = new Estatus();
                        Console.WriteLine("3.- Ingresa el nombre para Agregara Estatus");
                        Console.WriteLine("Clave");
                        estat.clave = Console.ReadLine(); 
                        Console.WriteLine("Nombre");
                        estat.nombre = Console.ReadLine();
                        int idre =  aDOEstatus.Agregar(estat);
                        Console.WriteLine(idre.ToString());
                        break;
                    case "4":
                        Estatus est = new Estatus();
                        Console.WriteLine("4.-Coloca el Id del estado que quieres Actualizar");
                        Console.WriteLine("ID");
                        est.id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Clave");
                        est.clave = Console.ReadLine();
                        Console.WriteLine("Nombre");
                        est.nombre = Console.ReadLine();
                         aDOEstatus.Actulizar(est);
                        break;
                    case "5":
                        Estatus estata = new Estatus();
                        Console.WriteLine("5.-Eliminar");
                        Console.WriteLine("Agrega el Id del estado que deseas buscar");
                        estata.id = Convert.ToInt32(Console.ReadLine());
                        aDOEstatus.Eliminar(estata);
                       
                        break;
                    case "6":
                        opcion = "F";
                        break;
                    default:
                        Console.WriteLine("No seleciono Opcion valida intentelo de Nuevo");
                        break;
                }
            }
            while (opcion != "F");
        }
    }
}
