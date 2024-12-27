using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoViaje.Views
{
    public interface ICAvsLSDetalleView
    {
      

        //Properties - Fields CP
        string NroViajeCP { get; set; }
        string NroViajeCalCP { get; set; }

        string FechaCP { get; set; }
        string NivelServicioCP { get; set; }
        string LugarCP { get; set; }
        string TotalFleteCP { get; set; }

        string TotalVolEntregaCP { get; set; }
        string ObsCP { get; set; }
        string ArchivoOrigenCP { get; set; }

        //LS
        string NroViajeLS { get; set; }
        string NroViajeCalLS { get; set; }
        string TransportistaLS { get; set; }
        string PlacaLS { get; set; }
        string TipoViajeLS { get; set; }
        string MetrajeLS { get; set; }
        string FechaDespachoLS { get; set; }
        string TipoAlmacenLS { get; set; }
        string ObservacionesLS { get; set; }
        string DetalleLS { get; set; }

        string NroViajeAnexoLS { get; set; }
        string NroViajeCalAnexoLS { get; set; }
        string MontoLS { get; set; }

        string Verificacion { get; set; }
        
        //Methods
        void Show();




    }
}
