using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dominio
{
    public class clsGenerarReporteExcel : IGenerarReporte
    {

        DataSet ds = new DataSet();
        string directorio = "";

        public clsGenerarReporteExcel(DataSet p_dsDatos)
        {
            ds = p_dsDatos;
        }

        /// <summary>
        /// Rutina para generar el archivo con los datos de la consulta
        /// </summary>
        /// <returns></returns>
        public DataSet generarReporte()
        {
            try
            {
                definirRutaArchivo();
                generarExcel();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;

        }


        /// <summary>
        /// Abre un cuadro de dialogo para permitir guardar un archivo
        /// </summary>
        public void definirRutaArchivo()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();             
                saveFileDialog.AddExtension = true;
                saveFileDialog.ShowDialog();
                directorio = saveFileDialog.FileName.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Genera un archivo de excel partiendo de un DataSet
        /// </summary>
        private void generarExcel()
        {
            try
            {              
                int columnaExcel = 0;
                int filaExcel = 0;

                FileInfo file = new FileInfo(Path.Combine(directorio + ".xlsx"));

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                string documentacionLicencia = "https://www.epplussoftware.com/Developers/LicenseException;";


                ExcelPackage libro = new ExcelPackage(file);
                using (libro)
                {


                    libro.Workbook.Properties.Author = "Elkin Muñoz";
                    libro.Workbook.Properties.Company = "Universidad de las Americas";
                    libro.Workbook.Properties.Keywords = "Excel,Epplus";

                    ExcelWorksheet hoja = libro.Workbook.Worksheets.Add("Resultado");


                    //Encabezados
                    columnaExcel = 1;
                    filaExcel = 1;
                    for (int columnaDataSet = 0; columnaDataSet < ds.Tables[0].Columns.Count; columnaDataSet++)
                    {                                             
                        hoja.Cells[1, columnaExcel].Value = ds.Tables[0].Columns[columnaDataSet].ToString();
                        columnaExcel++;
                    }


                    //Datos
                    filaExcel = 2;                   
                    for (int filaDataSet = 0; filaDataSet < ds.Tables[0].Rows.Count; filaDataSet++)
                    {
                        columnaExcel = 1;
                        for (int columnaDataSet = 0; columnaDataSet < ds.Tables[0].Columns.Count; columnaDataSet++)
                        {
                            hoja.Cells[filaExcel, columnaExcel].Value = ds.Tables[0].Rows[filaDataSet][columnaDataSet].ToString();
                            columnaExcel++;
                        }
                        
                        filaExcel++;                       
                    }


                   

                    libro.Save(); //Save the workbook.
                    MessageBox.Show($"Archivo {file} Guardado Exitosamente");

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        public void crearExcel()
        {

            //string sWebRootFolder = _hostingEnvironment.WebRootPath;
            //Path.Combine(sWebRootFolder, sFileName)

            //string directorio = "D:\\Repositorios\\GestorModular\\Presentacion\\wwwroot\\Excel\\";
            //string nombreArchivo = @"demo.xlsx";

            //FileInfo file = new FileInfo(Path.Combine(directorio, nombreArchivo));
            FileInfo file = new FileInfo("demo.xlsx");

            try
            {

                //ExcelPackage.LicenseContext = System.ComponentModel.LicenseContext.NonCommercial;
                //ExcelPackage.LicenseContext = LicenseContext.Commercial;
                string documentacionLicencia = "https://www.epplussoftware.com/Developers/LicenseException;";


                ExcelPackage libro = new ExcelPackage(file);
                using (libro)
                {

                    libro.Workbook.Properties.Author = "Benjamín Camacho";
                    libro.Workbook.Properties.Company = "aspnetcoremaster.com";
                    libro.Workbook.Properties.Keywords = "Excel,Epplus";

                    ExcelWorksheet hoja = libro.Workbook.Worksheets.Add("MiHoja de Excel");
                    //Para copiar una Hoja
                    ExcelWorksheet copiaHoja = libro.Workbook.Worksheets.Add("copia", hoja);


                    //First add the headers
                    hoja.Cells[1, 1].Value = "ID";
                    hoja.Cells[1, 2].Value = "Name";
                    hoja.Cells[1, 3].Value = "Gender";
                    hoja.Cells[1, 4].Value = "Salary (in $)";

                    //Add values
                    hoja.Cells["A2"].Value = 1000;
                    hoja.Cells["B2"].Value = "Jon";
                    hoja.Cells["C2"].Value = "M";
                    hoja.Cells["D2"].Value = 5000;

                    hoja.Cells["A3"].Value = 1001;
                    hoja.Cells["B3"].Value = "Graham";
                    hoja.Cells["C3"].Value = "M";
                    hoja.Cells["D3"].Value = 10000;

                    hoja.Cells["A4"].Value = 1002;
                    hoja.Cells["B4"].Value = "Jenny";
                    hoja.Cells["C4"].Value = "F";
                    hoja.Cells["D4"].Value = 5000;

                    libro.Save(); //Save the workbook.


                    //hoja.Cells["A1"].Value = "Valor asignado desde C#";
                    ////hoja.Cells["A1"].Style.Font.Color.SetColor(Red);
                    //hoja.Cells["A1"].Style.Font.Name = "Calibri";
                    //hoja.Cells["A1"].Style.Font.Size = 40;

                    //hoja.Cells["B1"].Value = "2020/03/07";
                    //hoja.Cells["B1"].Style.Numberformat.Format = "dd/mm/aaaa";

                }

                //return File(libro.GetAsByteArray(), excelContentType, "Productos.xlsx");
            }
            catch (Exception ex)
            {
                string res = "";
                res = ex.Message;
            }

        }


        //public string generar_ArchivoPlano_Siesa(List<PlantillasSeccionesModel> listado_Secciones_Plantilla, List<PlantillasCamposModel> listado_Campos_Plantilla, List<ExcelHojasModel> listadoHojasExcel, ref bool bitError, ref string resultado)
        //{

        //    string strNombreArchivo = "";
        //    string strPlano = "";
        //    string seccionError = "";
        //    string campoError = "";
        //    string strLineaPlano = "";
        //    int numeroTotalRegistros = 0;

        //    int numero_Fila = 0;
        //    int numRegistro;

        //    if (bitError == false)
        //    {
        //        try
        //        {

        //            numRegistro = 1;


        //            //===============================================================================================================
        //            /////Controlas el numero total de registros que se generaran en el plano 

        //            /////Filtrar las hojas de excel sin la seccion inicial ni final
        //            //List<ExcelHojasModel> listadoHojasExcelFiltradas = listadoHojasExcel.Where(x => (x.nombreHoja != "Inicial") || (x.nombreHoja != "Final")).ToList();

        //            if (listadoHojasExcel.Count == 0)
        //            {
        //                bitError = true;
        //                resultado = "La plantilla de excel no tiene hojas validas para procesar";
        //            }

        //            //sumo los registros de la plantilla
        //            if (!bitError)
        //            {

        //                foreach (PlantillasSeccionesModel seccionPlantilla in listado_Secciones_Plantilla)
        //                {
        //                    if ((seccionPlantilla.idSeccion == 0) || (seccionPlantilla.idSeccion == 9999))
        //                    {
        //                        numeroTotalRegistros += 1;
        //                    }
        //                }
        //                foreach (ExcelHojasModel hoja in listadoHojasExcel)
        //                {
        //                    numeroTotalRegistros += hoja.listado_Filas.Count;
        //                }

        //            }
        //            //===============================================================================================================




        //            //===============================================================================================================
        //            //Recorro la plantilla creada
        //            if (!bitError)
        //            {
        //                foreach (PlantillasSeccionesModel seccionPlantilla in listado_Secciones_Plantilla)
        //                {
        //                    if (!bitError)
        //                    {


        //                        //Identifico en la seccion que se esta trabajando para reportarla si ocurre un error
        //                        seccionError = seccionPlantilla.seccion;

        //                        //=========================================================================================================================
        //                        //Filtro la seccion de la plantilla vs el excel
        //                        ExcelHojasModel hojaExcel = new ExcelHojasModel();
        //                        hojaExcel = listadoHojasExcel.FirstOrDefault(x => x.nombreHoja.Trim() == seccionPlantilla.seccion.Trim());

        //                        //Filtro los campos de la seccion
        //                        List<PlantillasCamposModel> listados_Campos_Seccion_Plantilla = new List<PlantillasCamposModel>();
        //                        listados_Campos_Seccion_Plantilla = listado_Campos_Plantilla.Where(x => x.idSeccion == seccionPlantilla.idSeccion).ToList();
        //                        //=========================================================================================================================





        //                        numero_Fila = 1;
        //                        //===============================================================================================================
        //                        //===============================================================================================================
        //                        //Si la seccion no tiene campos variables o no aparece en el excel
        //                        if ((hojaExcel == null) && ((seccionPlantilla.idSeccion == 0) || (seccionPlantilla.idSeccion == 9999)))
        //                        {

        //                            strLineaPlano = "";

        //                            //Recorro los campos de la plantilla
        //                            foreach (var campo_Seccion_Plantilla in listados_Campos_Seccion_Plantilla)
        //                            {

        //                                //Identifico el campo que se esta trabajando para reportarlo si ocurre un error
        //                                campoError = campo_Seccion_Plantilla.campo;

        //                                string strTipoCampo = campo_Seccion_Plantilla.tipo;
        //                                int strTamano = campo_Seccion_Plantilla.tamaño;
        //                                string strValor = campo_Seccion_Plantilla.valor;

        //                                if ((campo_Seccion_Plantilla.inicio == 1) && (campo_Seccion_Plantilla.sistema == "Siesa")) //Si el campo es el primero el sistema cacula el numero de registro
        //                                {
        //                                    strValor = numRegistro.ToString();
        //                                }
        //                                else //Si el campo es variable se asigna el valor del excel
        //                                {
        //                                    strValor = campo_Seccion_Plantilla.valor;
        //                                }

        //                                //Se formatea el campo
        //                                strLineaPlano += formatoCampo(strTipoCampo, strTamano, strValor, campo_Seccion_Plantilla.observaciones);

        //                            }


        //                            //se añade un salto de linea menos en la ultima linea
        //                            if (numRegistro < numeroTotalRegistros)
        //                            {
        //                                strLineaPlano += Environment.NewLine;
        //                            }

        //                            //Se añade la fila al plano
        //                            strPlano += strLineaPlano;

        //                            numero_Fila++;
        //                            numRegistro++;

        //                        }
        //                        else if (hojaExcel == null)
        //                        {
        //                            //Si la hoja de excel no es inicial ni final y no concuerda con la plantilla no se generara ninguna linea
        //                        }
        //                        //===============================================================================================================
        //                        //===============================================================================================================





        //                        //===============================================================================================================
        //                        //===============================================================================================================
        //                        //Si la plantila si tiene campos variables
        //                        else
        //                        {
        //                            //Recorro el listado de fila en excel
        //                            foreach (var filaExcel in hojaExcel.listado_Filas)
        //                            {
        //                                if (!bitError)
        //                                {

        //                                    //======================================================================================
        //                                    //Filtro las columnas de la fila en excel trae los !!!!ENCABEZADOS DEL EXCEL!!!!
        //                                    List<ExcelColumnasModel> listadoColumnaExcel = new List<ExcelColumnasModel>();
        //                                    listadoColumnaExcel = hojaExcel.listado_Filas.FirstOrDefault(x => x.numeroFila == numero_Fila).listado_Columnas;

        //                                    strLineaPlano = "";
        //                                    //======================================================================================



        //                                    //======================================================================================
        //                                    //======================================================================================
        //                                    //Recorro los campos de la plantilla
        //                                    foreach (var campo_Seccion_Plantilla in listados_Campos_Seccion_Plantilla)
        //                                    {
        //                                        if (!bitError)
        //                                        {


        //                                            campoError = campo_Seccion_Plantilla.campo;

        //                                            string strTipoCampo = campo_Seccion_Plantilla.tipo;
        //                                            int strTamano = campo_Seccion_Plantilla.tamaño;
        //                                            string strValor = campo_Seccion_Plantilla.valor;

        //                                            if ((campo_Seccion_Plantilla.inicio == 1) && (campo_Seccion_Plantilla.sistema == "Siesa"))  //Si el campo es el primero el sistema cacula el numero de registro
        //                                            {
        //                                                strValor = numRegistro.ToString();
        //                                            }
        //                                            else if (campo_Seccion_Plantilla.variable) //Si el campo es variable se asigna el valor del excel
        //                                            {


        //                                                //Match entre el campo de la plantilla y el encabezado de excel
        //                                                //=====================================================================================================
        //                                                try
        //                                                {
        //                                                    strValor = listadoColumnaExcel.FirstOrDefault(x => x.nombre_columna.Trim() == campo_Seccion_Plantilla.valor.Trim()).valor.ToString().Trim();

        //                                                    if (
        //                                                        strValor.Contains("$") ||
        //                                                        strValor.Contains("%") ||
        //                                                        strValor.Contains("&") ||
        //                                                        strValor.Contains("(") ||
        //                                                        strValor.Contains(")") ||
        //                                                        strValor.Contains("=") ||
        //                                                        strValor.Contains("*") ||
        //                                                        strValor.Contains("?") ||
        //                                                        strValor.Contains("¿") ||
        //                                                        strValor.Contains("!") ||
        //                                                        strValor.Contains("¡") ||
        //                                                        strValor.Contains("Á") ||
        //                                                        strValor.Contains("É") ||
        //                                                        strValor.Contains("Í") ||
        //                                                        strValor.Contains("Ó") ||
        //                                                        strValor.Contains("Ú") ||
        //                                                        strValor.Contains("á") ||
        //                                                        strValor.Contains("é") ||
        //                                                        strValor.Contains("í") ||
        //                                                        strValor.Contains("ó") ||
        //                                                        strValor.Contains("ú") ||
        //                                                        strValor.Contains("ü") ||
        //                                                        strValor.Contains("ñ") ||
        //                                                        strValor.Contains("Ñ")
        //                                                        )
        //                                                    {
        //                                                        bitError = true;
        //                                                        resultado = $"Ocurrio un error al generar el plano en la seccion {seccionError} - campo {campoError} - Fila Excel {numero_Fila + 1} : el campo tiene caracteres especiales"; ;
        //                                                        break;
        //                                                    }

        //                                                }
        //                                                catch (Exception)
        //                                                {
        //                                                    bitError = true;
        //                                                    resultado = $"Ocurrio un error al generar el plano en la seccion {seccionError} - campo {campoError} - Fila Excel {numero_Fila + 1} : No se encontro el campo en el excel probablemente no tiene el mismo nombre que la plantilla"; ;
        //                                                    break;
        //                                                }
        //                                                //=====================================================================================================


        //                                            }

        //                                            //Se formatea el campo
        //                                            if (!bitError)
        //                                            {
        //                                                strLineaPlano += formatoCampo(strTipoCampo, strTamano, strValor, campo_Seccion_Plantilla.observaciones);
        //                                            }

        //                                        }
        //                                    }
        //                                    //======================================================================================
        //                                    //======================================================================================




        //                                    //======================================================================================
        //                                    if (!bitError)
        //                                    {
        //                                        //Se añade un salto de linea
        //                                        if (numRegistro < numeroTotalRegistros)
        //                                        {
        //                                            strLineaPlano += Environment.NewLine;
        //                                        }

        //                                        //Se añade la fila al plano
        //                                        strPlano += strLineaPlano;

        //                                        numero_Fila++;
        //                                        numRegistro++;
        //                                    }
        //                                    //======================================================================================


        //                                }
        //                            }
        //                        }
        //                        //===============================================================================================================
        //                        //===============================================================================================================



        //                    }
        //                }
        //            }
        //            //Fin recorrido de la plantilla creada
        //            //===============================================================================================================


        //            //===============================================================================================================
        //            //Crear  el archivo
        //            if (!bitError)
        //            {
        //                strNombreArchivo = crearArchivo(strPlano);
        //            }
        //            //===============================================================================================================

        //        }
        //        catch (Exception ex)
        //        {
        //            bitError = true;
        //            resultado = $"Ocurrio un error al generar el plano en la seccion {seccionError} - campo {campoError} - Fila Excel {numero_Fila + 1} : {ex.Message}";
        //        }
        //    }

        //    return strNombreArchivo;

        //}



    }
}
