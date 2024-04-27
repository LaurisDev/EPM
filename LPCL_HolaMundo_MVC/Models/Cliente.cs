using LPCL_HolaMundo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPCL_HolaMundo_MVC.Models
{
    public class Cliente
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string PeriodoConsumo { get; set; }
        public int Estrato { get; set; }
        public int MetaAhorroEnergia { get; set; }
        public int ConsumoActualEnergia { get; set; }
        public int PromedioConsumoAgua { get; set; }
        public int ConsumoActualAgua { get; set; }
        public const int TarifaEnergia = 850;
        public const int TarifaAgua = 4600;


        public Cliente(int cedula, string nombre,string apellidos, string periodoConsumo, int estrato, int metaAhorroEnergia, int consumoActualEnergia, int promedioConsumoAgua, int consumoActualAgua)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellidos = apellidos;
            PeriodoConsumo = periodoConsumo;
            Estrato = estrato;
            MetaAhorroEnergia = metaAhorroEnergia;
            ConsumoActualEnergia = consumoActualEnergia;
            PromedioConsumoAgua = promedioConsumoAgua;
            ConsumoActualAgua = consumoActualAgua;

        }

        public static Cliente SolicitarDatosCliente(int cedula, string nombre, string apellidos, string periodoConsumo, int estrato, int metaAhorroEnergia, int consumoActualEnergia, int promedioConsumoAgua, int consumoActualAgua)
        {
            return new Cliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);
        }


        public void ActualizarCedula(int nuevaCedula)
        {
            this.Cedula = nuevaCedula;
        }

        public void ActualizarNombre(string nuevoNombre)
        {
            this.Nombre = nuevoNombre;
        }

        public  void ActualizarApellidos( string nuevoApellidos)
        {
            this.Apellidos = nuevoApellidos;
        }

        public void ActualizarPeriodoConsumo(string nuevoPeriodoConsumo)
        {
            this.PeriodoConsumo = nuevoPeriodoConsumo;
        }

        public void ActualizarEstrato(int nuevoEstrato)
        {
            this.Estrato = nuevoEstrato;
        }

        public  void ActualizarMetaAhorroEnergia(int nuevaMetaAhorro)
        {
            this.MetaAhorroEnergia = nuevaMetaAhorro;
        }

        public void ActualizarConsumoActualEnergia(int nuevoConsumoEnergia)
        {
            this.ConsumoActualEnergia = nuevoConsumoEnergia;
        }

        public void ActualizarPromedioConsumoAgua(int nuevoPromedioAgua)
        {
            this.PromedioConsumoAgua = nuevoPromedioAgua;
        }

        public  void ActualizarConsumoActualAgua( int nuevoConsumoAgua)
        {
            this.ConsumoActualAgua = nuevoConsumoAgua;
        }

        public static void ActualizarInformacionCliente(List<Cliente> clientes)
        {
            Console.Write("Ingrese la cédula del cliente que desea actualizar: ");
            int cedulaClienteActualizar = int.Parse(Console.ReadLine());
            Cliente clienteActualizar = clientes.Find(c => c.Cedula == cedulaClienteActualizar);
            if (clienteActualizar != null)
            {
                Console.WriteLine("Seleccione el dato que desea actualizar:");
                Console.WriteLine("1. Cedula");
                Console.WriteLine("2. Nombre");
                Console.WriteLine("3. Apellidos");
                Console.WriteLine("4. Periodo de consumo");
                Console.WriteLine("5. Estrato");
                Console.WriteLine("6. Meta de ahorro de energía");
                Console.WriteLine("7. Consumo actual de energía");
                Console.WriteLine("8. Promedio de consumo de agua");
                Console.WriteLine("9. Consumo actual de agua");
                Console.Write("Ingrese el número correspondiente a la opción: ");
                string opcionActualizar = Console.ReadLine();

                switch (opcionActualizar)
                {
                    case "1":
                        Console.Write("Ingrese la nueva cédula del usuario: ");
                        int nuevaCedula = int.Parse(Console.ReadLine());
                        clienteActualizar.ActualizarCedula(nuevaCedula);
                        Console.WriteLine("Cédula del usuario actualizada correctamente.");
                        break;
                    case "2":
                        Console.Write("Ingrese el nuevo nombre del usuario: ");
                        string nuevoNombre = Console.ReadLine();
                        clienteActualizar.ActualizarNombre(nuevoNombre);
                        Console.WriteLine("Nombre del usuario actualizado correctamente.");
                        break;
                    case "3":
                        Console.Write("Ingrese los nuevos apellidos del usuario: ");
                        string nuevosApellidos = Console.ReadLine();
                        clienteActualizar.ActualizarApellidos(nuevosApellidos);
                        Console.WriteLine("Apellidos del usuario actualizados correctamente.");
                        break;
                    case "4":
                        Console.Write("Ingrese el nuevo periodo de consumo del usuario: ");
                        string nuevoPeriodoConsumo = Console.ReadLine();
                        clienteActualizar.ActualizarPeriodoConsumo(nuevoPeriodoConsumo);
                        Console.WriteLine("Periodo de consumo actualizado correctamente.");
                        break;
                    case "5":
                        Console.Write("Ingrese el nuevo estrato del usuario: ");
                        int nuevoEstrato = int.Parse(Console.ReadLine());
                        clienteActualizar.ActualizarEstrato(nuevoEstrato);
                        Console.WriteLine("Estrato actualizado correctamente.");
                        break;
                    case "6":
                        Console.Write("Ingrese la nueva meta de ahorro de energía del usuario: ");
                        int nuevaMetaAhorro = int.Parse(Console.ReadLine());
                        clienteActualizar.ActualizarMetaAhorroEnergia(nuevaMetaAhorro);
                        Console.WriteLine("Meta de ahorro de energía actualizada correctamente.");
                        break;
                    case "7":
                        Console.Write("Ingrese el nuevo consumo actual de energía: ");
                        int nuevoConsumoEnergia = int.Parse(Console.ReadLine());
                        clienteActualizar.ActualizarConsumoActualEnergia(nuevoConsumoEnergia);
                        Console.WriteLine("Consumo actual de energía actualizado correctamente.");
                        break;
                    case "8":
                        Console.Write("Ingrese el nuevo promedio de consumo de agua: ");
                        int nuevoPromedioAgua = int.Parse(Console.ReadLine());
                        clienteActualizar.ActualizarPromedioConsumoAgua(nuevoPromedioAgua);
                        Console.WriteLine("Promedio de consumo de agua actualizado correctamente.");
                        break;
                    case "9":
                        Console.Write("Ingrese el nuevo consumo actual de agua: ");
                        int nuevoConsumoAgua = int.Parse(Console.ReadLine());
                        clienteActualizar.ActualizarConsumoActualAgua(nuevoConsumoAgua);
                        Console.WriteLine("Consumo actual de agua actualizado correctamente.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }


        public static void EliminarInformacionCliente(List<Cliente> clientes)
        {
            
                Console.Write("Ingrese la cédula del cliente que desea eliminar: ");
                int cedulaClienteEliminar = int.Parse(Console.ReadLine()); // Lee la entrada del usuario

                Cliente clienteEliminar = clientes.Find(c => c.Cedula == cedulaClienteEliminar);
                if (clienteEliminar != null)
                {
                    clientes.Remove(clienteEliminar);
                    Console.WriteLine("Cliente(s) eliminado(s) correctamente");
                }
                else { Console.WriteLine("Cliente no encontrado"); }  
            
        }


    }

}

