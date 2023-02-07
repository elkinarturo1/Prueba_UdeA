using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class clsConsultaEstudiantes : IConsultasDB
    {
      
        ConexionDB_Model conexionDB;

        public clsConsultaEstudiantes(ConexionDB_Model p_conexionDB)
        {
            conexionDB = p_conexionDB;
        }


        public DataSet ejecutar_Consulta()
        {
            SqlConnection sqlConexion = new SqlConnection(conexionDB.strConexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {

                sqlComando.Connection = sqlConexion;
                sqlComando.CommandType = CommandType.StoredProcedure;
                sqlComando.CommandText = conexionDB.sp;
                sqlComando.CommandTimeout = 0;

                sqlAdaptador.SelectCommand = sqlComando;
                sqlAdaptador.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlComando.Parameters.Clear();
                sqlComando.Connection.Close();
            }

            return ds;

        }
    }
}
