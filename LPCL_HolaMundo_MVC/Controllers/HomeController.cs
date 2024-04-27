using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LPCL_HolaMundo_MVC.Models;

namespace LPCL_HolaMundo_MVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult Clientes()
        {
            return View(clientes);
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(int cedula, string nombre, string apellidos, string periodoConsumo, int estrato, int metaAhorroEnergia, int consumoActualEnergia, int promedioConsumoAgua, int consumoActualAgua)
        {
            Cliente cliente = Cliente.SolicitarDatosCliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);
            clientes.Add(cliente);
            ViewBag.Mensaje = "Cliente agregado correctamente";
            return RedirectToAction("Contact");
        }

        public ActionResult Contact()
        {
            return View(clientes);
        }

        public ActionResult EliminarCliente()
        {
            return View(clientes);
        }

        [HttpPost]
        public ActionResult EliminarCliente(int cedula)
        {
            Cliente clienteEliminar = clientes.Find(c => c.Cedula == cedula);
            if (clienteEliminar != null)
            {
                clientes.Remove(clienteEliminar);
                ViewBag.Message = "Cliente eliminado correctamente";
            }
            else
            {
                ViewBag.Message = "Cliente no encontrado";
            }

            return View(clientes);
        }

        public ActionResult ActualizarCliente()
        {
            return View();
        }

   
        [HttpPost]
        public ActionResult ActualizarCliente(int cedulaClienteActualizar)
        {
            var clienteActualizar = clientes.Find(c => c.Cedula == cedulaClienteActualizar);

            if (clienteActualizar != null)
            {
                ViewBag.Cliente = clienteActualizar;
                return View("ActualizarInformacionCliente", clienteActualizar);
            }
            else
            {
                ViewBag.ErrorMessage = "Cliente no encontrado.";
                return View();
            }
        }

        [HttpPost]
        public ActionResult ActualizarInformacionCliente(int cedula, string campo, string valor)
        {
            var cliente = clientes.Find(c => c.Cedula == cedula);

            if (cliente != null)
            {
                switch (campo)
                {
                    case "Nombre":
                        cliente.Nombre = valor; 
                        break;
                    case "Apellidos":
                        cliente.Apellidos = valor;
                        break;
                    case "PeriodoConsumo":
                        cliente.PeriodoConsumo = valor;
                        break;
                    case "Estrato":
                        cliente.Estrato = int.Parse(valor);
                        break;
                    case "MetaAhorroEnergia":
                        cliente.MetaAhorroEnergia = int.Parse(valor);
                        break;
                    case "ConsumoActualEnergia":
                        cliente.ConsumoActualEnergia = int.Parse(valor);
                        break;
                    case "PromedioConsumoAgua":
                        cliente.PromedioConsumoAgua = int.Parse(valor);
                        break;
                    case "ConsumoActualAgua":
                        cliente.ConsumoActualAgua = int.Parse(valor);
                        break;
                    default:
                        ViewBag.ErrorMessage = "Campo no válido.";
                        return View("ActualizarCliente", cliente);
                }

                ViewBag.SuccessMessage = $"{campo} actualizado correctamente.";
                return View("ActualizarCliente", cliente); 
            }
            else
            {
                ViewBag.ErrorMessage = "Cliente no encontrado.";
                return View("ActualizarCliente");
            }
        }



        [HttpPost]
        public ActionResult CalcularValorPagar(int cedula)
        {
            Cliente cliente = clientes.Find(c => c.Cedula == cedula);
            if (cliente != null)
            {
                CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
                double valorPagar = calculadora.CalcularValorPagar(cliente.MetaAhorroEnergia, cliente.ConsumoActualEnergia, cliente.PromedioConsumoAgua, cliente.ConsumoActualAgua);
                ViewBag.ValorPagar = valorPagar;
                return View("ResultadoFacturacion");
            }
            else
            {
                ViewBag.ErrorMessage = "Cliente no encontrado.";
                return View("CalcularFactura");

            }
        }

        public ActionResult CalcularFactura()
        {
            return View();
        }

        public ActionResult ResultadoFacturacion()
        {
            return View();
        }


        public ActionResult Calculadora(string option)
        {
            //case 4
            if (option == "CalcularPromedioConsumoEnergia")
            {
                double promedio = CalculadoraFacturacion.CalcularPromedioConsumoEnergia(clientes);
                ViewBag.PromedioConsumoEnergia = promedio;
            }
            //case 5
            if (option == "CalcularTotalDescuentos")
            {
                double descuentoCliente = CalculadoraFacturacion.CalcularTotalDescuentos(clientes);
                ViewBag.TotaldecuestosCliente = descuentoCliente;
            }
            //case 6
            if (option == "CalcularTotalExcesoAgua")
            {
                double ExcesoAgua = CalculadoraFacturacion.CalcularTotalExcesoAgua(clientes);
                ViewBag.TotalExcesoAgua = ExcesoAgua;
            }
            //case 7
            if (option == "CalcularPorcentajeConsumoExcesoAguaPorEstrato")
            {
                Dictionary<int, double> TotalPorcentajeExcesoAguaPorEstrato = CalculadoraFacturacion.CalcularPorcentajeConsumoExcesoAguaPorEstrato(clientes);
                ViewBag.porcentajeExcesoPorEstrato = TotalPorcentajeExcesoAguaPorEstrato;
            }
      
            //caso 8

            if (option == "CalcularMayorAhorroAguaPorEstrato")
            {
                Dictionary<int, int> TotalCalcularMayorAhorroAguaPorEstrato = CalculadoraFacturacion.CalcularMayorAhorroAguaPorEstrato(clientes);
                ViewBag.resultado = TotalCalcularMayorAhorroAguaPorEstrato;

            }
            //caso 9

            if (option == "CalcularConsumoEnergiaPorEstrato")
            {
                Dictionary<string, int> TotalCalcularConsumoEnergiaPorEstrato = CalculadoraFacturacion.CalcularConsumoEnergiaPorEstrato(clientes);
                ViewBag.resultadoCalcularConsumoEnergiaPorEstrato = TotalCalcularConsumoEnergiaPorEstrato;

            }

            //case 10
            if (option == "ContarClientesConConsumoMayorPromedio")
            {
                int clientesConConsumoMayorPromedio = CalculadoraFacturacion.ContarClientesConConsumoMayorPromedio(clientes);
                ViewBag.clientesConConsumoMayorPromedio = clientesConConsumoMayorPromedio;
            }
            //case 11
            if (option == "MostrarClienteMayorDesfase")
            {
                Cliente clienteMayorDesfase = CalculadoraFacturacion.ObtenerClienteMayorDesfase(clientes);

                if (clienteMayorDesfase != null)
                {
                    
                    ViewBag.ClienteMayorDesfase = clienteMayorDesfase;
                }
                
            }
            //case 12

            if (option == "CalcularTotalPagadoEnergia")
            {
                double totalPagadoEnergia = CalculadoraFacturacion.CalcularTotalPagadoEnergia(clientes);
                ViewBag.TotalPagadoEnergia = totalPagadoEnergia;
               
            }
            //case 13
            if (option == "CalcularTotalPagadoAgua")
            {
                double totalPagadoAgua = CalculadoraFacturacion.CalcularTotalPagadoAgua(clientes);
                ViewBag.TotalPagadoAgua = totalPagadoAgua;

            }

            return View();
        }

       




    }
}
