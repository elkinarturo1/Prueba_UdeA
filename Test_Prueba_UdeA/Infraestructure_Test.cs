using Infraestructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Prueba_UdeA
{
    [TestClass]
    public class Infraestructure_Test
    {

        ConexionDB_Model conexionDB = new ConexionDB_Model();

        [TestMethod]
        public void conexionDB_Test()
        {           
            conexionDB.strConexion = "Data Source=107.6.54.20,1433;Initial Catalog=udeaDB;User ID=udea;Password=udea;Integrated Security=False";
            conexionDB.sp = "sp_Consulta";
            clsConsultaEstudiantes infraestructureinfraestructure = new clsConsultaEstudiantes(conexionDB);
            var result = infraestructureinfraestructure.ejecutar_Consulta();
            Assert.IsNotNull(result);           
        }


        [TestMethod]
        public void Tablas_Consulta_Test()
        {           
            conexionDB.strConexion = "Data Source=107.6.54.20,1433;Initial Catalog=udeaDB;User ID=udea;Password=udea;Integrated Security=False";
            conexionDB.sp = "sp_Consulta";
            clsConsultaEstudiantes infraestructureinfraestructure = new clsConsultaEstudiantes(conexionDB);
            var result = infraestructureinfraestructure.ejecutar_Consulta();
            Assert.IsTrue(result.Tables.Count > 0);
        }


        [TestMethod]
        public void Datos_Consulta_Test()
        {           
            conexionDB.strConexion = "Data Source=107.6.54.20,1433;Initial Catalog=udeaDB;User ID=udea;Password=udea;Integrated Security=False";
            conexionDB.sp = "sp_Consulta";
            clsConsultaEstudiantes infraestructureinfraestructure = new clsConsultaEstudiantes(conexionDB);
            var result = infraestructureinfraestructure.ejecutar_Consulta();
            Assert.IsTrue(result.Tables[0].Rows.Count > 0);
        }


    }
}
