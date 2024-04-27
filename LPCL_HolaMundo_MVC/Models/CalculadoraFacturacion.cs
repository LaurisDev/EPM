using LPCL_HolaMundo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPCL_HolaMundo_MVC.Models
{
    public class CalculadoraFacturacion
    {
        public double CalcularValorPagar(int metaAhorroEnergia, int consumoActualEnergia, int promedioConsumoAgua, int consumoActualAgua)
        {
            // Calcular incentivo de energía
            double valorIncentivoEnergia = (metaAhorroEnergia - consumoActualEnergia) * Cliente.TarifaEnergia;

            // Calcular valor a pagar por energía
            double valorParcialEnergia = consumoActualEnergia * Cliente.TarifaEnergia;
            double valorPagarEnergia = valorParcialEnergia - valorIncentivoEnergia;

            // Inicialización de las variables
            double valorParcialAgua;
            double valorPagarAgua;

            // Calcular valor a pagar por agua
            if (consumoActualAgua > promedioConsumoAgua)
            {
                double valorExcesoAgua = (consumoActualAgua - promedioConsumoAgua) * 2 * Cliente.TarifaAgua;
                valorParcialAgua = promedioConsumoAgua * Cliente.TarifaAgua;
                valorPagarAgua = valorParcialAgua + valorExcesoAgua;
            }
            else
            {
                valorParcialAgua = consumoActualAgua * Cliente.TarifaAgua;
                valorPagarAgua = valorParcialAgua;
            }

            double valorTotalPagar = valorPagarEnergia + valorPagarAgua;
            return valorTotalPagar;
        }

        //case 3

        public static double CalcularValorPagar(List<Cliente> clientes)
        {
            Console.Write("Ingrese la cédula del cliente: ");
            int cedulaCliente = int.Parse(Console.ReadLine());
            Cliente cliente = clientes.Find(c => c.Cedula == cedulaCliente);
            if (cliente != null)
            {
                CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
                double valorPagar = calculadora.CalcularValorPagar(cliente.MetaAhorroEnergia, cliente.ConsumoActualEnergia, cliente.PromedioConsumoAgua, cliente.ConsumoActualAgua);
                return valorPagar;
            }
            else
            {
                Console.Write("Ingrese la cédula del cliente: ");
                throw new Exception("Cliente no encontrado.");
            }
        }


        //case 4
        public static double CalcularPromedioConsumoEnergia(List<Cliente> clientes)
        {
            int sumaConsumoEnergia = 0;
            foreach (Cliente c in clientes)
            {
                sumaConsumoEnergia += c.ConsumoActualEnergia;
            }
            double promedioConsumoEnergia = (double)sumaConsumoEnergia / clientes.Count;
            return promedioConsumoEnergia;
        }

        //case 5
        public static double CalcularTotalDescuentos(List<Cliente> clientes)
        {
            double totalDescuentos = 0;
            foreach (Cliente c in clientes)
            {
                double descuentoCliente = (c.MetaAhorroEnergia - c.ConsumoActualEnergia) * Cliente.TarifaEnergia;
                if (descuentoCliente > 0)
                    totalDescuentos += descuentoCliente;
            }
            return totalDescuentos;
        }

        //case 6
        public static double CalcularTotalExcesoAgua(List<Cliente> clientes)
        {
            double totalExcesoAgua = 0;
            foreach (Cliente c in clientes)
            {
                totalExcesoAgua += Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
            }
            return totalExcesoAgua;
        }

        // case 7
        public static Dictionary<int, double> CalcularPorcentajeConsumoExcesoAguaPorEstrato(List<Cliente> clientes)
        {
            Dictionary<int, int> totalConsumoAguaPorEstrato = new Dictionary<int, int>();
            Dictionary<int, int> totalExcesoAguaPorEstrato = new Dictionary<int, int>();
            Dictionary<int, double> porcentajeExcesoPorEstrato = new Dictionary<int, double>();

            foreach (Cliente c in clientes)
            {
                if (!totalConsumoAguaPorEstrato.ContainsKey(c.Estrato))
                {
                    totalConsumoAguaPorEstrato[c.Estrato] = 0;
                }
                if (!totalExcesoAguaPorEstrato.ContainsKey(c.Estrato))
                {
                    totalExcesoAguaPorEstrato[c.Estrato] = 0;
                }

                totalConsumoAguaPorEstrato[c.Estrato] += c.ConsumoActualAgua;
                totalExcesoAguaPorEstrato[c.Estrato] += Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
            }

            foreach (KeyValuePair<int, int> kvp in totalExcesoAguaPorEstrato)
            {
                int estrato = kvp.Key;
                int totalExcesoAguaEstrato = kvp.Value;
                int totalConsumoAguaEstrato = totalConsumoAguaPorEstrato[estrato];
                double porcentajeExceso = (double)totalExcesoAguaEstrato / totalConsumoAguaEstrato * 100;
                porcentajeExcesoPorEstrato[estrato] = porcentajeExceso;
            }

            return porcentajeExcesoPorEstrato;

        }

        // case 8

        public static Dictionary<int, int> CalcularMayorAhorroAguaPorEstrato(List<Cliente> clientes)
        {
            Dictionary<int, int> TotalAhorroDeAguaPorEstrato = new Dictionary<int, int>();

            foreach (Cliente c in clientes)
            {
                int excesoAgua = Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
                if (!TotalAhorroDeAguaPorEstrato.ContainsKey(c.Estrato))
                {
                    TotalAhorroDeAguaPorEstrato[c.Estrato] = 0;
                }
                TotalAhorroDeAguaPorEstrato[c.Estrato] += excesoAgua;
            }

            // Encontrar el estrato con el mayor ahorro de agua
            KeyValuePair<int, int> mayorAhorroAgua = TotalAhorroDeAguaPorEstrato.OrderByDescending(x => x.Value).FirstOrDefault();
            Dictionary<int, int> resultado = new Dictionary<int, int>();

            if (mayorAhorroAgua.Key != 0)
            {
                resultado[mayorAhorroAgua.Key] = mayorAhorroAgua.Value;
            }
            else
            {
                resultado[-1] = -1;
            }

            return resultado;
        }
        //case 9
        public static Dictionary<string, int> CalcularConsumoEnergiaPorEstrato(List<Cliente> clientes)
        {
            Dictionary<int, int> consumoEnergiaPorEstrato = new Dictionary<int, int>();

            // Calcular el consumo de energía por estrato
            foreach (Cliente c in clientes)
            {
                if (!consumoEnergiaPorEstrato.ContainsKey(c.Estrato))
                {
                    consumoEnergiaPorEstrato[c.Estrato] = 0;
                }
                consumoEnergiaPorEstrato[c.Estrato] += c.ConsumoActualEnergia;
            }

            // Encontrar el estrato con el mayor y menor consumo de energía
            int estratoMayorConsumoEnergia = consumoEnergiaPorEstrato.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            int estratoMenorConsumoEnergia = consumoEnergiaPorEstrato.OrderBy(x => x.Value).FirstOrDefault().Key;

            // Crear un diccionario para almacenar el resultado
            Dictionary<string, int> resultadoCalcularConsumoEnergiaPorEstrato = new Dictionary<string, int>();
            resultadoCalcularConsumoEnergiaPorEstrato["MayorConsumoEnergia"] = estratoMayorConsumoEnergia;
            resultadoCalcularConsumoEnergiaPorEstrato["MenorConsumoEnergia"] = estratoMenorConsumoEnergia;

            // Devolver el resultado
            return resultadoCalcularConsumoEnergiaPorEstrato;
        }

        //case 10
        public static int ContarClientesConConsumoMayorPromedio(List<Cliente> clientes)
        {
            int clientesConConsumoMayorPromedio = 0;
            foreach (Cliente c in clientes)
            {
                if (c.ConsumoActualAgua > c.PromedioConsumoAgua)
                {
                    clientesConConsumoMayorPromedio++;
                }
            }
            return clientesConConsumoMayorPromedio;
        }

        //case 11
        public static Cliente ObtenerClienteMayorDesfase(List<Cliente> clientes)
        {
            Cliente clienteMayorDesfase = clientes.OrderByDescending(c => Math.Abs(c.ConsumoActualEnergia - c.MetaAhorroEnergia)).FirstOrDefault();
            return clienteMayorDesfase;
        }

        //case 12
        public static double  CalcularTotalPagadoEnergia(List<Cliente> clientes)
        {
            double totalPagadoEnergia = 0;


            foreach (Cliente c in clientes)
            {
                CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
                double valorPagarEnergia = calculadora.CalcularValorPagar(c.MetaAhorroEnergia, c.ConsumoActualEnergia, c.PromedioConsumoAgua, c.ConsumoActualAgua);
                totalPagadoEnergia += valorPagarEnergia;

              
            }

            return totalPagadoEnergia;
        }

        public static double CalcularTotalPagadoAgua(List<Cliente> clientes)
        {
            double totalPagadoAgua = 0;

            foreach (Cliente c in clientes)
            {
                CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
                double valorPagarAgua = c.ConsumoActualAgua * Cliente.TarifaAgua;
                totalPagadoAgua += valorPagarAgua;
            }
            return totalPagadoAgua;
        }


    }
}