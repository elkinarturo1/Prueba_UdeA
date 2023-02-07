﻿using Dominio;
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

                generarReporte = new clsGenerarReporteEstudiantes(conexionDB_Model);
            }
            catch (Exception ex)
            {
                resultado(ex.Message);
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            try
            {
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


        public void resultado(string mensaje)
        {
            txtResultado.Text = mensaje;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            resultado("");
        }
    }
}
