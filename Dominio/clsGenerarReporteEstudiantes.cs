using Infraestructure;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class clsGenerarReporteEstudiantes: IGenerarReporte
    {

        ConexionDB_Model conexionDB;
        IConsultasDB consultasDB;       
        
        public clsGenerarReporteEstudiantes(ConexionDB_Model p_conexionDB)
        {           
            conexionDB = p_conexionDB;
            consultasDB = new clsConsultaEstudiantes(conexionDB);
        }
        
        /// <summary>
        /// Genera el reporte con los datos traidos de la base de datos
        /// </summary>
        /// <returns></returns>
        public DataSet generarReporte()
        {
           return consultasDB.ejecutar_Consulta();
        }
       
    }
}
