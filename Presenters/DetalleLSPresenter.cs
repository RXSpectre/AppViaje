using ProyectoViaje.DTO;
using ProyectoViaje.Models;
using ProyectoViaje.Presenters.Common;
using ProyectoViaje.Repositories.Interfaces;
using ProyectoViaje.Views;

using System;
using System.Windows.Forms;

namespace ProyectoViaje.Presenters
{
    public class DetalleLSPresenter
    {
        private readonly IDetalleLSView _view;
        private ListaSeparacionPresenter _presenterParent;
        private readonly IViajesRepo _repo;
        private readonly ListarLSDTO _det;
        private BindingSource _bsFiltroLS;
        private ParametroModel _parametroModel = null;

        private BindingSource _bsComboPlaca;
        private BindingSource _bsComboTipoAlmacen;
        private BindingSource _bsComboTipoViaje;
        private BindingSource _bsComboTransportista;

       

        public DetalleLSPresenter(IDetalleLSView view, IViajesRepo repo , ListarLSDTO det, ListaSeparacionPresenter presenterParent)
        {
            _view = view;
            _repo = repo;
            _det = det;
            _presenterParent = presenterParent;
            _view.Show();
            _bsFiltroLS = new BindingSource();
            _parametroModel = new ParametroModel();

            _bsComboPlaca = new BindingSource();
            _bsComboTipoViaje = new BindingSource();
            _bsComboTransportista = new BindingSource();
            _bsComboTipoAlmacen = new BindingSource();

            LoadPlacas();
            LoadTipoAlmacen();
            LoadTipoViaje();
            LoadTipoTrans();

            _view.SetBSCmbPlaca(_bsComboPlaca);
            _view.SetBSCmbTipoAlmacen(_bsComboTipoAlmacen);
            _view.SetBSCmbTransportista(_bsComboTransportista);
            _view.SetBSCmbTipoViaje(_bsComboTipoViaje);
            _view.SetBindingSourceFiltro(_bsFiltroLS);

            
            _view.SearchFilterLS += SearchFilterLS;
            _view.EditLS += EditLS;
            _view.DisableLS += DisableLS;
            _view.SelectedComboPlaca += SelectedComboPlaca;
            _view.ChangeCheck += ChangeCheck;
            _view.SelectedRow += SelectedRow;


            SetDetalle();

        }

        private void SelectedRow(object sender, EventArgs e)
        {
            var LS = (BusquedaLSDTO)_bsFiltroLS.Current;
            if (LS != null)
            {
                _view.NroViajeAnexo = LS.NroViaje.ToString();
                _view.NroViajeCalAnexo = LS.NroViajeCal;
                _bsFiltroLS.DataSource = null;
            }
        }

        private void LoadTipoTrans()
        {
            _parametroModel.CodPrm = "TIPOTRANS";
            _parametroModel.FlagFrm = 1;
            try
            {
                var response = _repo.ObtenerParametros(_parametroModel);
                //Fill data to register combo
                _bsComboTransportista.DataSource = response;

            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error al cargar los nombres de transportistas", MessageBoxIcon.Error);
            }
        }


        private void LoadPlacas()
        {
            _parametroModel.CodPrm = "PLACAS";
            _parametroModel.FlagFrm = 1;
            try
            {
                var response = _repo.ObtenerParametros(_parametroModel);
                //Fill data to register combo
                _bsComboPlaca.DataSource = response;

            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error al cargar las placas", MessageBoxIcon.Error);
            }
        }

        private void LoadTipoAlmacen()
        {

            _parametroModel.CodPrm = "TIPOALMACE";
            _parametroModel.FlagFrm = 1;
            try
            {
                _bsComboTipoAlmacen.DataSource = _repo.ObtenerParametros(_parametroModel);
            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error al cargar los tipos de almacenes", MessageBoxIcon.Error);
            }
        }

        private void LoadTipoViaje()
        {
            ParametroModel model = new ParametroModel();
            model.CodPrm = "TIPOVIAJE";
            model.FlagFrm = 1;
            try
            {
                _bsComboTipoViaje.DataSource = _repo.ObtenerParametros(model);
            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error al cargar los tipos de viaje", MessageBoxIcon.Error);
            }


        }

        private void ChangeCheck(object sender, EventArgs e)
        {
            if (_view.TieneAnexo)
            {
                _view.PanelState = true;
                _view.FechaDespachoFiltro = _view.FechaDespacho;
               
            }
            else
            {
                _view.PanelState = false;
                _view.FechaDespachoFiltro = "";
                _view.PlacaFiltro = "";
                _view.NroViajeAnexo = "";
                _view.NroViajeCalAnexo = "";
            }
        }


        private void DisableLS(object sender, EventArgs e)
        {
            MantLS();
        }

        private void EditLS(object sender, EventArgs e)
        {
            MantLS();
        }

        private void SearchFilterLS(object sender, EventArgs e)
        {
            BusquedaLSReqDTO req=new BusquedaLSReqDTO();
            try
            {
                req.FechaDespacho = Convert.ToDateTime(_view.FechaDespachoFiltro).ToString("yyyyMMdd");
                req.CodPlaca = Convert.ToByte(((ParametroModel)_view.ComboPlaca).CodIden);
                req.NroViaje = Convert.ToInt32(_view.NroViaje);
                req.NroViajeCal = "CAL-".Trim()+_view.NroViajeCal.Trim();
                req.FlagMant = 2;

                var response = _repo.BusquedaLS(req);
                if (response.Count == 0)
                    Alerts.BuilAlerts("No existen registro con esos filtro", MessageBoxIcon.Warning);

                _bsFiltroLS.DataSource = response;

            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error al buscar el filtro de lista de separación", MessageBoxIcon.Error);
            }
            finally 
            {
                req = null;
            }
        }



        private void SelectedComboPlaca(object sender, EventArgs e)
        {
            _view.PlacaFiltro = ((ParametroModel)_view.ComboPlaca)?.Valor1;
        }

       

        private void SetDetalle()
        {

            //Lista Separación
            _view.NroViaje = _det.NroViaje.ToString()== "0" ? "": _det.NroViaje.ToString();
            _view.NroViajeCal = _det.NroViajeCal;
            _view.FechaDespacho = _det.FechaDespacho;
            _view.TotalCubicaje = _det.TotalCubicaje.ToString();
            _view.Observaciones = _det.ObsLs;
            _view.Detalle = _det.Detalle;
            _view.TieneAnexo = _det.TieneAnexo == "SI" ? true : false;
            _view.PanelState= _det.TieneAnexo == "SI" ? true : false;
            _view.NroViajeAnexo = _det.NroViajeAnexo.ToString() == "0" ? "" : _det.NroViajeAnexo.ToString();
            _view.NroViajeCalAnexo = _det.NroViajeCalAnexo;
           
            //Set Combos
            _view.ComboPlaca = _det.CodPlacas;
            _view.ComboTransportista = _det.CodTransportista;
            _view.ComboTipoAlmacen = _det.CodTipoAlmacen;
            _view.ComboTipoViaje = _det.CodTipoViaje;

            _view.PlacaFiltro = ((ParametroModel)_bsComboPlaca.Current).Valor1;
        }



        private void MantLS()
        {
            ListaSeparacionReqDTO req = new ListaSeparacionReqDTO();
            string msgVal = "";
            try
            {

                req.NroViaje = Convert.ToInt32(_view.NroViaje);
                req.NroViajeCal = _view.NroViajeCal;
                req.FlagMant = _view.FlagMant;

                if (req.FlagMant == 2) 
                {
                    bool resultAlert = Alerts.BuilAlertsQuestion("¿Estás seguro que deseas editar el registro?");

                    if (!resultAlert)
                        return;


                    req.FechaDespacho =Convert.ToDateTime(_view.FechaDespacho).ToString("yyyyMMdd");
                    req.TotalCubicaje = Convert.ToDecimal(_view.TotalCubicaje);
                    req.Observaciones = _view.Observaciones;
                    req.Detalle = _view.Detalle;
                    req.TieneAnexo = _view.TieneAnexo;
                    req.NroViajeAnexo = _view.NroViajeAnexo == "" ? 0 : Convert.ToInt32(_view.NroViajeAnexo);
                    req.NroViajeCalAnexo = _view.NroViajeCalAnexo;


                    //Combos
                    req.CodPlaca = Convert.ToByte(((ParametroModel)_view.ComboPlaca).CodIden);
                    req.CodTipoAlmacen = Convert.ToByte(((ParametroModel)_view.ComboTipoAlmacen).CodIden);
                    req.CodTipoViaje = Convert.ToByte(((ParametroModel)_view.ComboTipoViaje).CodIden);
                    req.CodTransportista = Convert.ToByte(((ParametroModel)_view.ComboTransportista).CodIden);

                    msgVal = DataValidations.ValidationModel(req);

                    //Validation of anexos
                    if (req.TieneAnexo && (req.NroViajeAnexo == 0 || req.NroViajeCalAnexo == ""))
                        msgVal += "*Tiene que seleccionar un registros de Anexo";


                    if (!String.IsNullOrEmpty(msgVal))
                    {
                        Alerts.BuilAlerts("Alertas:\n" + msgVal, MessageBoxIcon.Warning);
                        return;
                    }

                }

                if (req.FlagMant == 3) 
                {
                    bool resultAlert=Alerts.BuilAlertsQuestion("¿Estás seguro que deseas deshabilitar el registro?");
                    if (!resultAlert)
                        return;
                }

                ResponseModel res =_repo.MantLS(req);

                if (res.CodResult == 200)
                {
                    Alerts.BuilAlerts(res.Msg, MessageBoxIcon.Information);
                    _presenterParent.SearchLS();
                    _view.Close();
                   
                }

                if (res.CodResult == 0)
                    Alerts.BuilAlerts(res.Msg, MessageBoxIcon.Warning);

                if (res.CodResult == 500)
                    throw new Exception(res.Msg);


            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error en el mantenimiento de lista de separación", MessageBoxIcon.Error);
            }
            finally
            {
                req = null;
                _presenterParent = null;
            }
        }

    }
}
