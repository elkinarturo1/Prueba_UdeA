using Dominio;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prueba_UdeA
{
    public partial class Principal : Form
    {

        ConexionDB_Model conexionDB_Model;
        IGenerarReporte generarReporte;
        public DataSet ds;

        public Principal()
        {

            InitializeComponent();

            try
            {
                ds = new DataSet();
                conexionDB_Model = new ConexionDB_Model();
                conexionDB_Model.strConexion = Properties.Settings.Default.strConexion;
                conexionDB_Model.sp = Properties.Settings.Default.sp;
            }
            catch (Exception ex)
            {
                resultado(ex.Message);
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            realizarConsulta();
        }


        private void btnGenerarXLS_Click(object sender, EventArgs e)
        {
            realizarConsulta();
            generarExcel();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            resultado("");
        }




        /// <summary>
        /// Realiza la consulta a base da datos
        /// </summary>
        private void realizarConsulta()
        {
            try
            {
                generarReporte = new clsGenerarReporteEstudiantes(conexionDB_Model);

                ds = generarReporte.generarReporte();

                dgvDatos.DataSource = ds;
                dgvDatos.DataMember = ds.Tables[0].ToString();
                resultado("Consulta realizada Exitosamente");
            }
            catch (Exception ex)
            {
                resultado(ex.Message);
            }
        }

        /// <summary>
        /// Genera un archivo de Excel
        /// </summary>
        private void generarExcel()
        {
            try
            {
                generarReporte = new clsGenerarReporteExcel(ds);
                generarReporte.generarReporte();
                resultado("Proceso Terminado");
            }
            catch (Exception ex)
            {
                resultado(ex.Message);
            }

        }

        //public void definirRutaArchivo()
        //{
        //    try
        //    {
        //        OpenFileDialog openFileDialog = new OpenFileDialog();
        //        openFileDialog.ShowDialog();
        //        rutaArchivo = openFileDialog.FileName.ToString();               
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado(ex.Message);
        //    }
        //}

        /// <summary>
        /// Muestra en pantalla el resultado de cada proceso
        /// </summary>
        /// <param name="mensaje"></param>
        public void resultado(string mensaje)
        {
            txtResultado.Text = mensaje;
        }

    }
}
