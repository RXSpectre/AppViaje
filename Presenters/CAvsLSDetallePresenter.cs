using ProyectoViaje.DTO;
using ProyectoViaje.Presenters.Common;
using ProyectoViaje.Views;

namespace ProyectoViaje.Presenters
{
    public class CAvsLSDetallePresenter
    {
        private readonly ICAvsLSDetalleView _view;
        private readonly ListarCAvsLSDetDTO _det;


        public CAvsLSDetallePresenter(ICAvsLSDetalleView view, ListarCAvsLSDetDTO det)
        {
            _view = view;
            _det = det;
            _view.Show();
           
            SetDetalle();
        }

        public void SetDetalle()
        {
            //Data Carta Porte
            _view.NroViajeCP = _det.NroViajeCA.ToString();
            _view.NroViajeCalCP = _det.NroViajeCalCA;
            _view.FechaCP = _det.FechaCA;
            _view.NivelServicioCP = _det.NivelServicioCA;
            _view.LugarCP = _det.LugarCA;
            _view.TotalFleteCP = _det.TotalFleteCA.ToString();
            _view.TotalVolEntregaCP = _det.TotalVolEntregaCA.ToString();
            _view.ObsCP = _det.ObsCA;
            _view.ArchivoOrigenCP = _det.ArchivoOrigenCA;
            //Lista Separación
            _view.NroViajeLS = _det.NroViajeLS.ToString();
            _view.NroViajeCalLS = _det.NroViajeCalLS;
            _view.TransportistaLS = _det.TransportistaLS;
            _view.PlacaLS = _det.PlacaLS;
            _view.TipoViajeLS = _det.TipoViajeLS;
            _view.MetrajeLS = _det.TotalCubiajeLS.ToString();
            _view.FechaDespachoLS = _det.FechaDespachoLS;
            _view.TipoAlmacenLS = _det.AlmacenLS;
            _view.MontoLS = _det.MontoLS.ToString();
            _view.ObservacionesLS = _det.ObsLS;
            _view.DetalleLS = _det.DetalleLS;
            _view.NroViajeAnexoLS = _det.NroViajeAnexoLS.ToString();
            _view.NroViajeCalAnexoLS = _det.NroViajeCalAnexoLS;
            _view.Verificacion = _det.Verificacion;
            
        }


    }
}
