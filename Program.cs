using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Integrantes: Carrasco Marcelo Mateo Y Sotomayor Maria Gabriela

namespace Práctica_6_Ejercicio_2_CarrascoMarcelo_SotomayorGabriela
{
    class Cola
    {
        private string[] elemento = new string[3]; //Contenido del nodo 
        private Cola sig;
        public Cola(string[] dato = null) //Constructor, tanto para nodos vacíos como para nodos con algún dato
        {
            elemento = dato;
            sig = null;
        }
        public bool Vacia() //Devuelve true si la cola está vacía
        {
            bool resultado = false;
            if (this.elemento == null && this.sig == null)
                resultado = true;
            return resultado;
        }
        public void Colocar(string[] dato) //Inserta a dato como nuevo nodo al final de la cola
        {
            Cola p, nuevo;
            p = this;
            if (Vacia()) //Se va a insertar el primer nodo
            {
                this.elemento = dato;
                this.sig = null;
            }
            else        //Para el segundo nodo en adelante
            {
                nuevo = new Cola(dato);
                while (p.sig != null)
                    p = p.sig;
                p.sig = nuevo;
            }
        }
        public string[] Retirar()
        {
            Cola p = this.sig;
            string[] resultado = null;
            if (!Vacia())
            {
                resultado = this.elemento;
                if (p != null)  //Hay 2 nodos o más
                {
                    this.elemento = p.elemento;
                    this.sig = p.sig;
                }
                else            //Solo queda un nodo con datos, p apunta a null
                    this.elemento = null;
            }
            return resultado;
        }
        public double Remuneracion()
        //Calcula los salarios de cada cola. Devuelve la suma de los sueldos.
        {
            double valor = 0;
            Cola p;
            if (!Vacia())
            {
                valor = double.Parse(this.elemento[2]);
                p = this.sig;
                while (p != null)
                {
                    valor = valor + double.Parse(p.elemento[2]);
                    p = p.sig;
                }
            }
            return valor;
        }
        public void Ver()
        {
            Cola p = this;
            if (!Vacia())
            {
                while (p != null)
                {
                    for (int i = 0; i < p.elemento.Length; i++)
                    {
                        if (p.elemento[i] == "Docente")
                            Console.Write(p.elemento[i] + "\t\t\t");
                        else if (p.elemento[i] == "Administrativo")
                            Console.Write(p.elemento[i] + "\t\t");
                        else
                            Console.Write(p.elemento[i] + " \t");
                    }
                    if (p.sig != null)
                        Console.WriteLine();
                    p = p.sig;
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static string Area(string num)
        //Devuelve el área en el que trabaja el empleado
        {
            string resultado = "";
            if (num == "1")
                resultado = "Administrativo";
            else if (num == "2")
                resultado = "Docente";
            else if (num == "3")
                resultado = "Servicios Generales";
            return resultado;
        }
        static string Sueldos(string area)
        {
            double salario = 0, horas = 0;
            string resultado = "";
            if (area == "1")
            {
                double sueldo;
                Console.WriteLine("Ingrese su salario básico.");
                salario = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese las horas extras.");
                horas = int.Parse(Console.ReadLine());
                sueldo = salario / 30;
                sueldo = sueldo / 8;
                sueldo = sueldo * 1.5;
                sueldo = sueldo * horas;
                salario = salario + sueldo;
            }
            else if (area == "2")
            {
                Console.WriteLine("¿Cuánto cobra por una hora clase? ");
                salario = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese las horas trabajadas a la semana. ");
                horas = int.Parse(Console.ReadLine());
                if (horas > 40)
                    horas = 40;
                salario = salario * horas;
            }
            else if (area == "3")
            {
                double sueldo;
                Console.WriteLine("¿Cuánto cobra por una hora normal? ");
                salario = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese las horas trabajadas a la semana. ");
                horas = int.Parse(Console.ReadLine());
                if (horas > 40)
                {
                    sueldo = salario * 1.25;
                    salario = sueldo * horas;
                }
                else
                    salario = salario * horas;
            }
            resultado = Convert.ToString(salario);
            return resultado;
        }
        static void Main(string[] args)
        {
            string[] datos = new string[3];
            int persona = 1, f = 0, m = 0;
            double sum = 0;
            string fin = "0";
            Cola Administrativo = new Cola();
            Cola Docente = new Cola();
            Cola ServiciosGenerales = new Cola();
            do
            {
                Console.Write("\nIngrese el sexo (F/M) de la persona #{0}: ", persona);
                datos[0] = Console.ReadLine();
                //Femenino o Masculino
                if (datos[0] == "F" || datos[0] == "f")
                {
                    datos[0] = "Femenino";
                    f++;
                }
                else if (datos[0] == "M" || datos[0] == "m")
                {
                    datos[0] = "Masculino";
                    m++;
                }
                Console.WriteLine("Ingrese el área de trabajo (1/2/3) de la persona #{0}): ", persona);
                Console.WriteLine("1. Administrativo.");
                Console.WriteLine("2. Docente.");
                Console.WriteLine("3. Servicios Generales.");
                datos[1] = Console.ReadLine();
                datos[2] = Sueldos(datos[1]);
                //Se guarda los datos en cada cola según su área de trabajo 
                if (datos[1] == "1")
                {
                    datos[1] = Area(datos[1]);
                    Administrativo.Colocar(datos);
                }
                else if (datos[1] == "2")
                {
                    datos[1] = Area(datos[1]);
                    Docente.Colocar(datos);
                }
                else if (datos[1] == "3")
                {
                    datos[1] = Area(datos[1]);
                    ServiciosGenerales.Colocar(datos);
                }
                persona++;
                datos = new string[3];
                Console.WriteLine("Desea seguir ingresando empleados S/N");
                fin = Console.ReadLine();
                fin = fin.ToLower();
            }
            while (fin != "n");
            Console.WriteLine("\nSexo\t\t\tÁrea\t\tSueldo");
            Docente.Ver();
            Administrativo.Ver();
            ServiciosGenerales.Ver();
            Console.WriteLine("\nRESUMEN DE EMPLEADO");
            Console.Write("\nHombres: " + m);
            Console.Write("\nMujeres: " + f);
            Console.Write("\nTotal: {0}", m + f);
            Console.WriteLine("\n\nNREMUNERACIONES POR AREA");
            sum = Administrativo.Remuneracion() + Docente.Remuneracion() + ServiciosGenerales.Remuneracion();
            Console.WriteLine("\nAdministrativo: $" + Administrativo.Remuneracion());
            Console.WriteLine("Servicios Generales: $" + ServiciosGenerales.Remuneracion());
            Console.WriteLine("Docente: $" + Docente.Remuneracion());
            Console.WriteLine("Total: $" + sum);
            Console.ReadKey();
        }
    }
}
