using Dominio;
using Infraestructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Prueba_UdeA
{
    [TestClass]
    public class Dominio_Test
    {

        ConexionDB_Model conexionDB = new ConexionDB_Model();

        [TestMethod]
        public void conexionDB_Test()
        {
            conexionDB.strConexion = "Data Source=107.6.54.20,1433;Initial Catalog=udeaDB;User ID=udea;Password=udea;Integrated Security=False";
            conexionDB.sp = "sp_Consulta";
            clsGenerarReporteEstudiantes GenerarReporteEstudiantes = new clsGenerarReporteEstudiantes(conexionDB);
            var result = GenerarReporteEstudiantes.generarReporte();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Tablas_Consulta_Test()
        {
            conexionDB.strConexion = "Data Source=107.6.54.20,1433;Initial Catalog=udeaDB;User ID=udea;Password=udea;Integrated Security=False";
            conexionDB.sp = "sp_Consulta";
            clsGenerarReporteEstudiantes GenerarReporteEstudiantes = new clsGenerarReporteEstudiantes(conexionDB);
            var result = GenerarReporteEstudiantes.generarReporte();
            Assert.IsTrue(result.Tables.Count > 0);
        }


        [TestMethod]
        public void Datos_Consulta_Test()
        {
            conexionDB.strConexion = "Data Source=107.6.54.20,1433;Initial Catalog=udeaDB;User ID=udea;Password=udea;Integrated Security=False";
            conexionDB.sp = "sp_Consulta";
            clsGenerarReporteEstudiantes GenerarReporteEstudiantes = new clsGenerarReporteEstudiantes(conexionDB);
            var result = GenerarReporteEstudiantes.generarReporte();
            Assert.IsTrue(result.Tables[0].Rows.Count > 0);
        }


    }
}
