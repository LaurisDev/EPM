using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPCL_HolaMundo_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPCL_HolaMundo_MVC.PruebasUnitarias
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void Cliente_Constructor()
        {
            // Arrange
            int cedula = 1234;
            string nombre = "John";
            string apellidos = "Doe";
            string periodoConsumo = "Mes 3";
            int estrato = 3;
            int metaAhorroEnergia = 150;
            int consumoActualEnergia = 180;
            int promedioConsumoAgua = 25;
            int consumoActualAgua = 20;

            // Act
            Cliente cliente = new Cliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);

            // Assert
            // Esta prueba garantiza que el constructor de la clase Cliente inicialice correctamente todas las propiedades del cliente con los valores proporcionados.
            Assert.AreEqual(cedula, cliente.Cedula);
            Assert.AreEqual(nombre, cliente.Nombre);
            Assert.AreEqual(apellidos, cliente.Apellidos);
            Assert.AreEqual(periodoConsumo, cliente.PeriodoConsumo);
            Assert.AreEqual(estrato, cliente.Estrato);
            Assert.AreEqual(metaAhorroEnergia, cliente.MetaAhorroEnergia);
            Assert.AreEqual(consumoActualEnergia, cliente.ConsumoActualEnergia);
            Assert.AreEqual(promedioConsumoAgua, cliente.PromedioConsumoAgua);
            Assert.AreEqual(consumoActualAgua, cliente.ConsumoActualAgua);
        }



        [TestMethod]
        public void SolicitarDatos()
        {
            // Arrange
            var input = new System.IO.StringReader(
                "3145\nRoger\nTorres\nMes 3\n3\n150\n180\n25\n20\n"
            );
            System.Console.SetIn(input);

            // Act
            var cliente = Cliente.SolicitarDatosCliente(3145, "Roger", "Torres", "Mes 3", 3, 150, 180, 25, 20);


            // Assert
            Assert.IsNotNull(cliente);
            Assert.AreEqual(3145, cliente.Cedula);
            Assert.AreEqual("Roger", cliente.Nombre);
            Assert.AreEqual("Torres", cliente.Apellidos);
            Assert.AreEqual("Mes 3", cliente.PeriodoConsumo);
            Assert.AreEqual(3, cliente.Estrato);
            Assert.AreEqual(150, cliente.MetaAhorroEnergia);
            Assert.AreEqual(180, cliente.ConsumoActualEnergia);
            Assert.AreEqual(25, cliente.PromedioConsumoAgua);
            Assert.AreEqual(20, cliente.ConsumoActualAgua);
        }

        [TestMethod]
        public void ActualizarClienteCedula()
        {
            // Arrange
            int cedulaInicial = 1234;
            Cliente cliente = new Cliente(cedulaInicial, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            int nuevaCedula = 3145;

            // Act
            cliente.ActualizarCedula(nuevaCedula);

            // Assert
            Assert.AreEqual(nuevaCedula, cliente.Cedula);
        }


        [TestMethod]
        public void ActualizarClienteNombre()
        {
            // Arrange
            int cedula = 1234;
            string nombreInicial = "Nombre";
            string apellidos = "Apellidos";
            string periodo = "Periodo";
            int estrato = 2;
            int metaAhorro = 100;
            int consumoActualEnergia = 140;
            int promedioConsumoAgua = 30;
            int consumoActualAgua = 25;

            Cliente cliente = new Cliente(cedula, nombreInicial, apellidos, periodo, estrato, metaAhorro, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);
            string nuevoNombre = "NuevoNombre";

            // Act
            cliente.ActualizarNombre(nuevoNombre);

            // Assert
            Assert.AreEqual(nuevoNombre, cliente.Nombre);
        }


        [TestMethod]
        public void ActualizarClienteApellidos()
        {
            // Arrange
            int cedula = 1234;
            string nombre = "Nombre";
            string apellidosInicial = "Apellidos";
            string periodo = "Periodo";
            int estrato = 2;
            int metaAhorro = 100;
            int consumoActualEnergia = 140;
            int promedioConsumoAgua = 30;
            int consumoActualAgua = 25;

            Cliente cliente = new Cliente(cedula, nombre, apellidosInicial, periodo, estrato, metaAhorro, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);
            string nuevosApellidos = "NuevoApellidos";

            // Act
            cliente.ActualizarApellidos(nuevosApellidos);

            // Assert
            Assert.AreEqual(nuevosApellidos, cliente.Apellidos);
        }


        [TestMethod]
        public void ActualizarClientePeriodoConsumo()
        {
            // Arrange
            int cedula = 1234;
            string nombre = "Nombre";
            string apellidos = "Apellidos";
            string periodoConsumoInicial = "Periodo";
            int estrato = 2;
            int metaAhorro = 100;
            int consumoActualEnergia = 140;
            int promedioConsumoAgua = 30;
            int consumoActualAgua = 25;

            Cliente cliente = new Cliente(cedula, nombre, apellidos, periodoConsumoInicial, estrato, metaAhorro, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);
            string nuevoPeriodoConsumo = "NuevoPeriodoConsumo";

            // Act
            cliente.ActualizarPeriodoConsumo(nuevoPeriodoConsumo);

            // Assert
            Assert.AreEqual(nuevoPeriodoConsumo, cliente.PeriodoConsumo);
        }


        [TestMethod]
        public void ActualizarClienteEstrato()
        {
            // Arrange
            int cedula = 1234;
            string nombre = "Nombre";
            string apellidos = "Apellidos";
            string periodoConsumo = "Periodo";
            int estratoInicial = 2;
            int metaAhorro = 100;
            int consumoActualEnergia = 140;
            int promedioConsumoAgua = 30;
            int consumoActualAgua = 25;

            Cliente cliente = new Cliente(cedula, nombre, apellidos, periodoConsumo, estratoInicial, metaAhorro, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);
            int nuevoEstrato = 3;

            // Act
            cliente.ActualizarEstrato(nuevoEstrato);

            // Assert
            Assert.AreEqual(nuevoEstrato, cliente.Estrato);
        }


        [TestMethod]
        public void ActualizarClienteMetaAhorroEnergia()
        {
            // Arrange
            int cedula = 1234;
            string nombre = "Nombre";
            string apellidos = "Apellidos";
            string periodoConsumo = "Periodo";
            int estrato = 2;
            int metaAhorroInicial = 100;
            int consumoActualEnergia = 140;
            int promedioConsumoAgua = 30;
            int consumoActualAgua = 25;

            Cliente cliente = new Cliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroInicial, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);
            int nuevaMetaAhorro = 120;

            // Act
            cliente.ActualizarMetaAhorroEnergia(nuevaMetaAhorro);

            // Assert
            Assert.AreEqual(nuevaMetaAhorro, cliente.MetaAhorroEnergia);
        }


        [TestMethod]
        public void ActualizarClienteConsumoActualEnergia()
        {
            // Arrange
            int cedula = 1234;
            string nombre = "Nombre";
            string apellidos = "Apellidos";
            string periodoConsumo = "Periodo";
            int estrato = 2;
            int metaAhorro = 100;
            int consumoActualEnergiaInicial = 140;
            int promedioConsumoAgua = 30;
            int consumoActualAgua = 25;

            Cliente cliente = new Cliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorro, consumoActualEnergiaInicial, promedioConsumoAgua, consumoActualAgua);
            int nuevoConsumoEnergia = 130;

            // Act
            cliente.ActualizarConsumoActualEnergia(nuevoConsumoEnergia);

            // Assert
            Assert.AreEqual(nuevoConsumoEnergia, cliente.ConsumoActualEnergia);
        }


        [TestMethod]
        public void ActualizarClientePromedioConsumoAgua()
        {
            // Arrange
            int cedula = 1234;
            string nombre = "Nombre";
            string apellidos = "Apellidos";
            string periodoConsumo = "Periodo";
            int estrato = 2;
            int metaAhorro = 100;
            int consumoActualEnergia = 140;
            int promedioConsumoAguaInicial = 30;
            int consumoActualAgua = 25;

            Cliente cliente = new Cliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorro, consumoActualEnergia, promedioConsumoAguaInicial, consumoActualAgua);
            int nuevoPromedioConsumoAgua = 40;

            // Act
            cliente.ActualizarPromedioConsumoAgua(nuevoPromedioConsumoAgua);

            // Assert
            Assert.AreEqual(nuevoPromedioConsumoAgua, cliente.PromedioConsumoAgua);
        }


        [TestMethod]
        public void ActualizarClienteConsumoActualAgua()
        {
            // Arrange
            int cedula = 1234;
            string nombre = "Nombre";
            string apellidos = "Apellidos";
            string periodoConsumo = "Periodo";
            int estrato = 2;
            int metaAhorro = 100;
            int consumoActualEnergia = 140;
            int promedioConsumoAgua = 30;
            int consumoActualAguaInicial = 25;

            Cliente cliente = new Cliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorro, consumoActualEnergia, promedioConsumoAgua, consumoActualAguaInicial);
            int nuevoConsumoAgua = 30;

            // Act
            cliente.ActualizarConsumoActualAgua(nuevoConsumoAgua);

            // Assert
            Assert.AreEqual(nuevoConsumoAgua, cliente.ConsumoActualAgua);
        }


        [TestMethod]
        public void EliminarCliente()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(12345, "Cliente1", "Apellido1", "Mes 3", 25, 123456789, 0, 0, 0),
                new Cliente(54321, "Cliente2", "Apellido2", " Mes 2", 30, 987654321, 0, 0, 0),
                new Cliente(67890, "Cliente3", "Apellido3", " Mes 3", 35, 456789123, 0, 0, 0)
            };

            int cedulaClienteEliminar = 54321; // Cédula del cliente que deseamos eliminar
            var input = new StringReader(cedulaClienteEliminar.ToString() + Environment.NewLine); //simula la entrada de un usuario proporcionando la cédula del cliente a eliminar
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            Cliente.EliminarInformacionCliente(clientes);

            // Assert
            Assert.IsTrue(output.ToString().Contains("Ingrese la cédula del cliente que desea eliminar:"));
            Assert.IsTrue(output.ToString().Contains("Cliente(s) eliminado(s) correctamente"));
        }





    }
}