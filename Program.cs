using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Sem_10___Guía_de_Laboratorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vendidos1 = 0, vendidos2 = 0, vendidos3 = 0, vendidos4 = 0, devueltos1 = 0, devueltos2 = 0, devueltos3 = 0, devueltos4 = 0;
            float precioV1 = 0, precioV2 = 0, precioV3 = 0, precioV4 = 0, precioD1 = 0, precioD2 = 0, precioD3 = 0, precioD4 = 0;
            int opcion;
            do
            {
                Encabezado(" Tienda de Don Lucas");
                Console.WriteLine(" 1: Registrar venta\n 2: Registrar devolución\n 3: Cerrar caja");
                Espaciado();
                opcion = int.Parse(LeerMensaje(" Ingrese una opción: "));
                OpcionTienda(opcion, ref vendidos1, ref vendidos2, ref vendidos3, ref vendidos4, ref precioV1, ref precioV2, ref precioV3, ref precioV4, ref devueltos1, 
                    ref devueltos2, ref devueltos3, ref devueltos4, ref precioD1, ref precioD2, ref precioD3, ref precioD4);
            } while ((opcion == 1) || (opcion == 2));
        }
        //Generamos la función "LeerMensaje" para escribir y poder leer una variable
        public static string LeerMensaje (string Msje)
        {
            Console.Write(Msje);
            string opcion = Console.ReadLine();
            return opcion;
        }
        //Construimos un método para el encabezado de cada segmento del caso
        public static void Encabezado(string titulo)
        {
            Console.WriteLine($" ===========================================\n{titulo}\n ===========================================");
        }
        //Formamos un método para las divisiones de la información a mostrar
        public static void Espaciado()
        {
            Console.WriteLine(" ===========================================");
        }
        //Producimos un método para las opciones de la Tienda
        public static void OpcionTienda (int opcion, ref int vendidos1, ref int vendidos2, ref int vendidos3, ref int vendidos4, ref float precioV1, ref float precioV2, 
            ref float precioV3, ref float precioV4, ref int devueltos1, ref int devueltos2, ref int devueltos3, ref int devueltos4, ref float precioD1, ref float precioD2, 
            ref float precioD3, ref float precioD4)
        {
            int opcion1;
            switch (opcion)
            {
                case 1:
                    int opcion2;
                    do
                    {
                        Console.Clear();
                        Encabezado(" Registrar Venta de:");
                        Console.WriteLine(" 1: Limpieza\n 2: Abarrotes\n 3: Golosinas\n 4: Electrónicos\n 5: <- Regresar");
                        Espaciado();
                        opcion1 = int.Parse(LeerMensaje(" Ingrese una opción: "));
                        opcion2 = Venta(opcion1, ref vendidos1, ref vendidos2, ref vendidos3, ref vendidos4, ref precioV1, ref precioV2, ref precioV3, ref precioV4);
                    } while (opcion2 == 2);
                    Console.Clear ();
                    break;
                case 2:
                    do
                    {
                        Console.Clear();
                        Encabezado(" Registrar Devolución de:");
                        Console.WriteLine(" 1: Limpieza\n 2: Abarrotes\n 3: Golosinas\n 4: Electrónicos\n 5: <- Regresar");
                        Espaciado();
                        opcion1 = int.Parse(LeerMensaje(" Ingrese una opción: "));
                        opcion2 = Devolucion(opcion1, ref devueltos1, ref devueltos2, ref devueltos3,  ref devueltos4, ref precioD1, ref precioD2, ref precioD3, ref precioD4);
                    } while (opcion2 == 2);
                    Console.Clear ();
                    break;
                case 3:
                    float caja1 = precioV1 - precioD1;
                    float caja2 = precioV2 - precioD2;
                    float caja3 = precioV3 - precioD3;
                    float caja4 = precioV4 - precioD4;
                    Console.Clear();
                    Encabezado(" Tienda de Don Lucas");
                    Console.WriteLine(" 1: Registrar venta\n 2: Registrar devolución\n 3: Cerrar caja");
                    Encabezado(" Cerrando Caja...");
                    Console.ReadKey();
                    Console.WriteLine(" Totales");
                    Espaciado();
                    float TotalQueda = TiposProductos(vendidos1, vendidos2, vendidos3, vendidos4, devueltos1, devueltos2, devueltos3, devueltos4, caja1, caja2, caja3, caja4);
                    Console.WriteLine(" Queda en caja S/. " + TotalQueda.ToString("N2"));
                    break;
            }
        }
        //Función para las opciones que tiene la venta de un producto
        public static int Venta(int opcion1, ref int vendidos1, ref int vendidos2, ref int vendidos3, ref int vendidos4, ref float precioV1, ref float precioV2, 
            ref float precioV3, ref float precioV4)
        {
            string tipo = "Limpieza";
            float precio;
            int opcion, unidades;

            switch (opcion1)
            {
                case 1:
                    tipo = "Limpieza";
                    break;
                case 2:
                    tipo = "Abarrotes";
                    break;
                case 3:
                    tipo = "Golosinas";
                    break;
                case 4:
                    tipo = "Electrónicos";
                    break;
                case 5:
                    return opcion1;
            }
            do
            {
                Console.Clear();
                Encabezado($" Registrar venta de {tipo}");
                unidades = int.Parse(LeerMensaje(" Ingrese cantidad (unidades): "));
                precio = float.Parse(LeerMensaje(" Ingrese precio: S/. "));
                Espaciado();
                Console.WriteLine($" Se han ingresado {unidades} unidades");
                Console.WriteLine($" Se han ingresado S/. {(precio * unidades).ToString("N2")} en caja");
                Encabezado($" 1: Registrar más productos de {tipo}\n 2: <- Regresar");
                opcion = int.Parse(LeerMensaje(" Ingrese una opción: "));

                if (tipo == "Limpieza") { vendidos1 += unidades; precioV1 += (precio * unidades); }
                if (tipo == "Abarrotes") { vendidos2 += unidades; precioV2 += (precio * unidades); }
                if (tipo == "Golosinas") { vendidos3 += unidades; precioV3 += (precio * unidades); }
                if (tipo == "Electrónicos") { vendidos4 += unidades; precioV4 += (precio * unidades); }

            } while (opcion == 1);
            return opcion;
        }
        //Función para las opciones que tiene la devolución de un producto
        public static int Devolucion(int opcion1, ref int devueltos1, ref int devueltos2, ref int devueltos3, ref int devueltos4, ref float precioD1, ref float precioD2, 
            ref float precioD3, ref float precioD4)
        {

            string tipo = "Limpieza";
            float precio;
            int opcion, unidades;

            switch (opcion1)
            {
                case 1:
                    tipo = "Limpieza";
                    break;
                case 2:
                    tipo = "Abarrotes";
                    break;
                case 3:
                    tipo = "Golosinas";
                    break;
                case 4:
                    tipo = "Electrónicos";
                    break;
                case 5:
                    return opcion1;
            }
            do
            {
                Console.Clear();
                Encabezado($" Registrar devolución de {tipo}");
                unidades = int.Parse(LeerMensaje(" Ingrese cantidad (unidades): "));
                precio = float.Parse(LeerMensaje(" Ingrese precio: S/. "));
                Espaciado();
                Console.WriteLine($" Se han regresado {unidades} unidades");
                Console.WriteLine($" Se han devuelto S/. {(precio * unidades).ToString("N2")} de caja");
                Encabezado($" 1: Devolver más productos de {tipo}\n 2: <- Regresar");
                opcion = int.Parse(LeerMensaje(" Ingrese una opción: "));

                if (tipo == "Limpieza") { devueltos1 += unidades; precioD1 += (precio * unidades); }
                if (tipo == "Abarrotes") { devueltos2 += unidades; precioD2 += (precio * unidades); }
                if (tipo == "Golosinas") { devueltos3 += unidades; precioD3 += (precio * unidades); }
                if (tipo == "Electrónicos") { devueltos4 += unidades; precioD4 += (precio * unidades); }

            } while (opcion == 1);
            return opcion;
        }
        //Método para mostrar los resultados (totales)
        public static float TiposProductos(int vendidos1, int vendidos2, int vendidos3, int vendidos4, int devueltos1, int devueltos2, int devueltos3, int devueltos4, 
            float caja1, float caja2, float caja3, float caja4)
            {
            string titulo = " Limpieza   ";
            int vendidos = vendidos1;
            int devueltos = devueltos1;
            float caja = caja1;

            for (int i = 0; i <= 3; i++)
            {
                switch (i)
                {
                    case 1:
                        titulo = " Abarrotes  ";
                        vendidos = vendidos2;
                        devueltos = devueltos2;
                        caja = caja2;
                        break;
                    case 2:
                        titulo = " Golosinas  ";
                        vendidos = vendidos3;
                        devueltos = devueltos3;
                        caja = caja3;
                        break;
                    case 3:
                        titulo = " Electrónico";
                        vendidos = vendidos4;
                        devueltos = devueltos4;
                        caja = caja4;
                        break;
                }
                if (vendidos == 1) { Console.WriteLine($"\t      |   {vendidos} vendido"); }
                else { Console.WriteLine($"\t      |   {vendidos} vendidos"); }
                if (devueltos == 1) { Console.WriteLine($"{titulo}  |   {devueltos} devuelto"); }
                else { Console.WriteLine($"{titulo}  |   {devueltos} devueltos"); }
                Console.WriteLine($"\t      |   {vendidos - devueltos} en total");
                Console.WriteLine($"\t      |   S/. {caja:N2} en caja");
                Espaciado();
            }
            float TotalQueda = caja1 + caja2 + caja3 + caja4;
            return TotalQueda;
            }
    }
}
