using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_Yariela_Padilla
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaración de variables
                string cedula = string.Empty;
                string nombre = string.Empty;
                byte tipo = 0;
                int cantidahoras = 0;
                double precio = 0.0;

                double salarioordinario = 0.0;
                double aumento = 0.0;
                double porcentajeAumento = 0.0;
                double salariobruto = 0.0;
                double deduccionCCSS = 0.0;
                double salarioneto = 0.0;

                const double CCSS = 0.0917;

                // Contadores y acumuladores
                int cantidadempleados = 0;
                int cantidadtipo1 = 0;
                int cantidadtipo2 = 0;
                int cantidadtipo3 = 0;

                double acumuladoSalarioOrdinario1 = 0.0;
                double acumuladoSalarioNeto1 = 0.0;

                double acumuladoSalarioOrdinario2 = 0.0;
                double acumuladoSalarioNeto2 = 0.0;

                double acumuladoSalarioOrdinario3 = 0.0;
                double acumuladoSalarioNeto3 = 0.0;

                char opcion = 's';

                do
                {
                    Console.WriteLine("\n--- INGRESO DE DATOS DEL EMPLEADO ---");
                    Console.WriteLine("Ingrese la cedula:");
                    cedula = Console.ReadLine();

                    Console.WriteLine("Ingrese el nombre:");
                    nombre = Console.ReadLine();

                    Console.WriteLine("Tipo de Empleado:");
                    Console.WriteLine("1. Operario (Aumento 15%)");
                    Console.WriteLine("2. Tecnico (Aumento 10%)");
                    Console.WriteLine("3. Profesional (Aumento 5%)");
                    Console.WriteLine("Ingrese el tipo:");
                    tipo = byte.Parse(Console.ReadLine());

                    porcentajeAumento = 0.0;

                    switch (tipo)
                    {
                        case 1:
                            porcentajeAumento = 0.15;
                            cantidadtipo1++;
                            break;
                        case 2:
                            porcentajeAumento = 0.10;
                            cantidadtipo2++;
                            break;
                        case 3:
                            porcentajeAumento = 0.05;
                            cantidadtipo3++;
                            break;
                        default:
                            Console.WriteLine("Tipo de empleado incorrecto.");
                            break;
                    }

                    Console.WriteLine("Ingrese la cantidad de horas trabajadas:");
                    cantidahoras = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el precio por hora:");
                    precio = double.Parse(Console.ReadLine());

                    if ((tipo >= 1 && tipo <= 3) && cantidahoras > 0 && precio > 0 && !string.IsNullOrEmpty(cedula) && !string.IsNullOrEmpty(nombre))
                    {
                        cantidadempleados++;

                        salarioordinario = cantidahoras * precio;
                        aumento = salarioordinario * porcentajeAumento;
                        salariobruto = salarioordinario + aumento;
                        deduccionCCSS = salariobruto * CCSS;
                        salarioneto = salariobruto - deduccionCCSS;

                        if (tipo == 1)
                        {
                            acumuladoSalarioOrdinario1 += salarioordinario;
                            acumuladoSalarioNeto1 += salarioneto;
                        }
                        else if (tipo == 2)
                        {
                            acumuladoSalarioOrdinario2 += salarioordinario;
                            acumuladoSalarioNeto2 += salarioneto;
                        }
                        else if (tipo == 3)
                        {
                            acumuladoSalarioOrdinario3 += salarioordinario;
                            acumuladoSalarioNeto3 += salarioneto;
                        }

                        Console.WriteLine("\n==== DESGLOSE DE SALARIO ====");
                        Console.WriteLine("Cedula: " + cedula);
                        Console.WriteLine("Nombre Empleado: " + nombre);
                        Console.WriteLine("Tipo Empleado: " + tipo);
                        Console.WriteLine("Salario por Hora: " + precio);
                        Console.WriteLine("Cantidad de Horas: " + cantidahoras);
                        Console.WriteLine("Salario Ordinario: " + salarioordinario);
                        Console.WriteLine("Aumento: " + aumento);
                        Console.WriteLine("Salario Bruto: " + salariobruto);
                        Console.WriteLine("Deduccion CCSS: " + deduccionCCSS);
                        Console.WriteLine("Salario Neto: " + salarioneto);
                        Console.WriteLine("=============================");
                    }
                    else
                    {
                        Console.WriteLine("Datos incorrectos. No se procesó el registro.");
                    }

                    Console.WriteLine("\n¿Desea ingresar otro empleado? (s/n)");
                    opcion = char.Parse(Console.ReadLine());

                } while (opcion == 's' || opcion == 'S');

                // Promedios
                double promedioOrdinario1 = cantidadtipo1 > 0 ? acumuladoSalarioOrdinario1 / cantidadtipo1 : 0.0;
                double promedioNeto1 = cantidadtipo1 > 0 ? acumuladoSalarioNeto1 / cantidadtipo1 : 0.0;

                double promedioOrdinario2 = cantidadtipo2 > 0 ? acumuladoSalarioOrdinario2 / cantidadtipo2 : 0.0;
                double promedioNeto2 = cantidadtipo2 > 0 ? acumuladoSalarioNeto2 / cantidadtipo2 : 0.0;

                double promedioOrdinario3 = cantidadtipo3 > 0 ? acumuladoSalarioOrdinario3 / cantidadtipo3 : 0.0;
                double promedioNeto3 = cantidadtipo3 > 0 ? acumuladoSalarioNeto3 / cantidadtipo3 : 0.0;

                // Reporte final
                Console.WriteLine("\n================ REPORTE GENERAL ================");
                Console.WriteLine("Cantidad de Empleados procesados: " + cantidadempleados);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Cantidad Operarios Tipo 1: " + cantidadtipo1);
                Console.WriteLine("Acumulado Salario Ordinario Tipo 1: " + acumuladoSalarioOrdinario1);
                Console.WriteLine("Promedio Salario Ordinario Tipo 1: " + promedioOrdinario1);
                Console.WriteLine("Acumulado Salario Neto Tipo 1: " + acumuladoSalarioNeto1);
                Console.WriteLine("Promedio Salario Neto Tipo 1: " + promedioNeto1);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Cantidad Tecnicos Tipo 2: " + cantidadtipo2);
                Console.WriteLine("Acumulado Salario Ordinario Tipo 2: " + acumuladoSalarioOrdinario2);
                Console.WriteLine("Promedio Salario Ordinario Tipo 2: " + promedioOrdinario2);
                Console.WriteLine("Acumulado Salario Neto Tipo 2: " + acumuladoSalarioNeto2);
                Console.WriteLine("Promedio Salario Neto Tipo 2: " + promedioNeto2);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Cantidad Profesionales Tipo 3: " + cantidadtipo3);
                Console.WriteLine("Acumulado Salario Ordinario Tipo 3: " + acumuladoSalarioOrdinario3);
                Console.WriteLine("Promedio Salario Ordinario Tipo 3: " + promedioOrdinario3);
                Console.WriteLine("Acumulado Salario Neto Tipo 3: " + acumuladoSalarioNeto3);
                Console.WriteLine("Promedio Salario Neto Tipo 3: " + promedioNeto3);
                Console.WriteLine("=================================================");

            }
        }
    }
