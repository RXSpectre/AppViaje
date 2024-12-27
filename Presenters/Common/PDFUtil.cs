using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using ProyectoViaje.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoViaje.Presenter.Common
{
    public class PDFUtil
    {

        public static List<CartaPorteModel> ProcessDataPdf(string fileSource, string fileName)
        {
            
            List<string[]> data = new List<string[]>();
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(@fileSource));

            List<CartaPorteModel> result = new List<CartaPorteModel>();
            int ultPosiRutas = 0;
            int OrdenDeCompra = 0;
            string CodRuta = "";
            bool serializar = false;
            string text = "";

            //Read the data of pdf
            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i), strategy);
                data.Add(text.Split('\n'));
            }

            //Process data 
            foreach (var txtArray in data)
            {
                var sArray = txtArray;
                serializar = false;
                CartaPorteModel rut = null;
                //Datos Fijos
                ultPosiRutas = sArray.Length - 1;
                if (sArray[ultPosiRutas].Contains("ORDEN DE COMPRA"))
                    OrdenDeCompra = Convert.ToInt32(sArray[ultPosiRutas].Split('.')[1]);
                else
                    break;


                CodRuta = sArray[ultPosiRutas - 2].Trim();

                if (result.Count == 0)
                {
                    rut = new CartaPorteModel();
                    serializar = true;
                    rut.CodRuta = CodRuta;
                    rut.OrdenDeCompra = OrdenDeCompra;


                }
                else
                {
                  
                    CartaPorteModel ultRuta = result[result.Count - 1];

                    if (ultRuta.CodRuta.Trim() != CodRuta)
                    {
                        rut = new CartaPorteModel();
                        serializar = true;
                        rut.CodRuta = CodRuta;
                        rut.OrdenDeCompra = OrdenDeCompra;
                    }

                    if (!ultRuta.ObsFlag)
                    {
                        //Recorremos la segundo pagina para coger la observacion
                        for (int x = 0; x < sArray.Length; x++)
                        {
                            //Obtener Observaciones
                            if (sArray[x].Trim() == "En representación de la TRANSPORTADORA, el conductor:  - C.C.")
                            {
                                ultRuta.ObsFlag = true;
                                if (sArray[x + 1].Trim() != "El vehículo REGRISTRADO para TRANSPORTAR la mercancía es:")
                                {
                                    ultRuta.Obs = sArray[x + 1].Trim();
                                    //Actualizamos
                                    result[result.Count - 1] = ultRuta;
                                }
                            }
                        }
                    }

                }

                if (serializar)
                {
                    //Serializa una hoja
                    for (int i = 0; i < sArray.Length; i++)
                    {

                        //Obtencion por puntos
                        if (sArray[i].Split('.')[0].Trim() == "CARTA DE PORTE No")
                            rut.CartaDePorte = Convert.ToInt32(sArray[i].Split('.')[1]);

                        if (sArray[i].Split('.')[0].Trim() == "VIAJE No")
                            rut.NroViajeCal = sArray[i].Split('.')[1].Trim();

                        //Obtencion por posición
                        if (sArray[i].Trim() == "NIVEL DE SERVICIO")
                            rut.NivelServicio = sArray[i - 1].Trim();

                        //Obtencion por referencia
                        if (sArray[i].Trim() == "Total Flete-Exc:")
                            rut.TotalFleteExc = Convert.ToDecimal(sArray[i + 4].Trim());

                        if (sArray[i].Trim() == "Total Volumen Entrega(s) (M3):")
                            rut.TotalVolumne = Convert.ToDecimal(sArray[i + 3].Trim());

                        //Funciona siempre y cuando se la primera ojo ,por lo tanto tenemos controlar primer recorrido
                        if (sArray[i].Trim() == "Peruana De Moldeados S.A.C.")
                        {
                            var resultFecha = new CastingDate().FormatDate(sArray[i + 1].Trim());
                            if (resultFecha.Contains(';'))
                            {
                                rut.Lugar = resultFecha.Split(';')[0];
                                rut.Fecha = resultFecha.Split(';')[1];
                            }
                            else
                            {
                                rut.Lugar = "";
                                rut.Fecha = "";
                            }
                        }
                        //Observaciones
                        if (sArray[i].Trim() == "En representación de la TRANSPORTADORA, el conductor:  - C.C.")
                        {
                            rut.ObsFlag = true;
                            int o = 0;
                            o = i;
                            while (sArray[o + 1].Trim() != "El vehículo REGRISTRADO para TRANSPORTAR la mercancía es:")
                            {
                                rut.Obs += sArray[o + 1].Trim();
                                o++;
                            }
                                
                            //if (sArray[i + 1].Trim() != "El vehículo REGRISTRADO para TRANSPORTAR la mercancía es:")
                            //    rut.Obs = sArray[i + 1].Trim();

                        }
                    }

                    rut.ArchivoOrigen = fileName;
                    //Registramos elementos
                    result.Add(rut);
                }

            }

            return result;
        }





    }
}
