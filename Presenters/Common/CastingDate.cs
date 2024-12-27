using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoViaje.Presenter.Common
{
    public class CastingDate
    {
        public string FormatDate(string fecha)
        {
            string resultado = String.Empty;
            string[] fechaProceso = fecha.Split(',');
            string lugar = String.Empty;
            string fechaValida = String.Empty;
            string[] fechaPartes = null;
            string dia = String.Empty;
            string mes = String.Empty;
            string anio = String.Empty;
            try
            {
                lugar = fechaProceso[0];
                fechaValida = fechaProceso[1];
                fechaPartes = fechaValida.Split(' ');
                mes = fechaPartes[1].Trim();
                dia = fechaPartes[2].Trim();
                anio = fechaPartes[4].Trim();

                switch (mes)
                {
                    case "Enero":
                        mes = "01";
                        break;
                    case "Febrero":
                        mes = "02";
                        break;
                    case "Marzo":
                        mes = "03";
                        break;
                    case "Abril":
                        mes = "04";
                        break;
                    case "Mayo":
                        mes = "05";
                        break;
                    case "Junio":
                        mes = "06";
                        break;
                    case "Julio":
                        mes = "07";
                        break;
                    case "Agosto":
                        mes = "08";
                        break;
                    case "Septiembre":
                        mes = "09";
                        break;
                    case "Octubre":
                        mes = "10";
                        break;
                    case "Noviembre":
                        mes = "11";
                        break;
                    case "Diciembre":
                        mes = "12";
                        break;
                }

                dia = dia.Length < 2 ? "0" + dia : dia;

                fechaValida = anio + mes + dia;
                resultado = lugar + ";" + fechaValida;
            }
            catch (Exception ex)
            {

                resultado = ex.Message;
            }



            return resultado;

        }

    }
}
