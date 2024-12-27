using System;
using ProyectoViaje.Models;
using System.Collections.Generic;
using ClosedXML.Excel;
using ProyectoViaje.DTO;

namespace ProyectoViaje.Presenter.Common
{
    public class ExcelUtil
    {
        public static string GenerateCartaPorteExcel(List<CartaPorteModel> rutas, string rutaDestino, string nombreArchivo)
        {
            string result = String.Empty;
            string rango = String.Empty;
            //nombreArchivo = @"\"+ nombreArchivo + DateTime.Now.Millisecond.ToString()+".xlsx";
            nombreArchivo = @"\" + nombreArchivo + ".xlsx";
            rutaDestino = rutaDestino + nombreArchivo;
            try
            {
                XLWorkbook wk = new XLWorkbook();
                IXLWorksheet ws = wk.AddWorksheet("CartaAporte");

                int x = 1;
                int y = 1;

                string titulo = nombreArchivo.Split('-')[0] + " " + nombreArchivo.Split('-')[2];
                titulo = titulo.Split('.')[0];
                titulo = titulo.Split('\\')[1];

                //Columnas
                ws.Cell(y, x++).Value = titulo;

                y ++;
                x = 1;

                ws.Cell(y, x++).Value = "AGENCIA";
                ws.Cell(y, x++).Value = "CARTA DE PORTE";
                ws.Cell(y, x++).Value = "VIAJE";
                ws.Cell(y, x++).Value = "ORDEN DE COMPRA";
                ws.Cell(y, x++).Value = "FLETE";

                rango = "A1:E1";
                ws.Range(rango).Style.Font.SetFontSize(24);
                ws.Range(rango).Style.Font.SetBold();

                rango = "A2:E2";
                ws.Range(rango).Style.Font.SetBold();

                y++;
                //Filas
                decimal sumatoria = 0m;
                foreach (var r in rutas)
                {
                    x = 1;
                    ws.Cell(y, x++).Value = "TRANSPORTES Y SERVICIOS GELAI";
                    ws.Cell(y, x++).Value = r.CartaDePorte;
                    ws.Cell(y, x++).Value = r.NroViajeCal;
                    ws.Cell(y, x++).Value = r.OrdenDeCompra;
                    ws.Cell(y, x++).Value = r.TotalFleteExc;
                    sumatoria+= r.TotalFleteExc;
                    y++;
                }

                ws.Cell(y, 5).Value = sumatoria;

                


                int ultimaCelda = rutas.Count + 2;
                rango = "A2:E" + ultimaCelda.ToString();

                //Centramos el contenido
                ws.Range(rango).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                //Ajustamos texto en caso supere el tamaño establecido de la celda
                ws.Range(rango).Style.Alignment.SetWrapText(true);
                //Crear Tabla
                IXLTable table = ws.Range(rango).CreateTable();
                table.Theme = XLTableTheme.TableStyleLight9;

                ultimaCelda++;
                rango = "E" + ultimaCelda;
                ws.Range(rango).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Range(rango).Style.Alignment.SetWrapText(true);
                ws.Range(rango).Style.Font.SetBold();

                ws.ColumnWidth = 45;

                wk.SaveAs(rutaDestino);

                wk.Dispose();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }


        public static string GenerateExcelLS(List<ListarLSDTO> ls, string rutaDestino)
        {
            string result = String.Empty;
            string rango = String.Empty;
            string nombreArchivo = "ListaSeparacion"+DateTime.Now.Millisecond.ToString();
            nombreArchivo = @"\" + nombreArchivo + ".xlsx";
            rutaDestino = rutaDestino + nombreArchivo;
            try
            {
                XLWorkbook wk = new XLWorkbook();
                IXLWorksheet ws = wk.AddWorksheet("ListaSeparacion");

                int x = 1;
                int y = 1;

                //Columnas
                ws.Cell(y, x++).Value = "NRO VIAJE";
                ws.Cell(y, x++).Value = "NRO VIAJE CAL";
                ws.Cell(y, x++).Value = "TRANSPORTISTA";
                ws.Cell(y, x++).Value = "PLACA";
                ws.Cell(y, x++).Value = "TIPO DE VIAJE";
                ws.Cell(y, x++).Value = "TOTAL DE CUBICAJE"; 
                ws.Cell(y, x++).Value = "FECHA DESPACHO";
                ws.Cell(y, x++).Value = "MONTO";
                ws.Cell(y, x++).Value = "ALMACEN";
                ws.Cell(y, x++).Value = "OBSERVACION";
                ws.Cell(y, x++).Value = "DETALLE";
                ws.Cell(y, x++).Value = "TIENE ANEXO";
                ws.Cell(y, x++).Value = "NRO VIAJE ANEXO";
                ws.Cell(y, x++).Value = "NRO VIAJE CAL ANEXO";
                ws.Cell(y, x++).Value = "HABILITADO";
                //ws.Cell(y, x++).Value = "FECHA CREACIÓN";
                //ws.Cell(y, x++).Value = "FECHA MODIFICACIÓN";


                rango = "A1:O1";
                ws.Range(rango).Style.Font.SetBold();

                y++;
                //Filas
                foreach (var r in ls)
                {
                    x = 1;
                    ws.Cell(y, x++).Value = r.NroViaje.ToString();
                    ws.Cell(y, x++).Value = r.NroViajeCal;
                    ws.Cell(y, x++).Value = r.NomTransportista;
                    ws.Cell(y, x++).Value = r.DscPlacas;
                    ws.Cell(y, x++).Value = r.DscTipoViaje;
                    ws.Cell(y, x++).Value = r.TotalCubicaje;
                    ws.Cell(y, x++).Value = r.FechaDespacho;
                    ws.Cell(y, x++).Value = r.Monto;
                    ws.Cell(y, x++).Value = r.DscTipoAlmacen;
                    ws.Cell(y, x++).Value = r.ObsLs;
                    ws.Cell(y, x++).Value = r.Detalle;
                    ws.Cell(y, x++).Value = r.TieneAnexo;
                    ws.Cell(y, x++).Value = r.NroViajeAnexo;
                    ws.Cell(y, x++).Value = r.NroViajeCalAnexo;
                    ws.Cell(y, x++).Value = r.Habilitado ? "SÍ":"NO";
                    //ws.Cell(y, x++).Value = r.FechaCreacion;
                    //ws.Cell(y, x++).Value = r.FechaModificacion;

                    y++;
                }

                int ultimaCelda = ls.Count + 1;
                rango = "A1:O" + ultimaCelda.ToString();

                //Centramos el contenido
                ws.Range(rango).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                //Ajustamos texto en caso supere el tamaño establecido de la celda
                ws.Range(rango).Style.Alignment.SetWrapText(true);
                //Crear Tabla
                IXLTable table = ws.Range(rango).CreateTable();
                table.Theme = XLTableTheme.TableStyleLight9;

                ws.ColumnWidth = 38;

                wk.SaveAs(rutaDestino);

                wk.Dispose();
                result="ok";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

    }
}
