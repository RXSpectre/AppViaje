using ProyectoViaje.DTO;
using ProyectoViaje.Models;
using ProyectoViaje.Presenter.Common;
using ProyectoViaje.Presenters.Common;
using ProyectoViaje.Repositories.Interfaces;
using ProyectoViaje.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoViaje.Presenters
{
    public class ListaSeparacionPresenter
    {
        private IListaSeparacionView _view;
        private IDetalleLSView _viewModal;
        private IViajesRepo _repo;
        private BindingSource _bsPlaca;
        private BindingSource _bsTipoViaje;
        private BindingSource _bsTipoAlmacen;
        private BindingSource _bsTipoTrans;

        private BindingSource _bsFiltroLS;
        private BindingSource _bsFiltroPlacaLS;
        private BindingSource _bsListarLSGrid;


        private readonly ParametroModel _parametroModel;

        private DetalleLSPresenter _modalPresenter = null;

        public ListaSeparacionPresenter(IListaSeparacionView view, IViajesRepo repo)
        {
            _view = view;
            _repo = repo;


            _view.Show();

            _parametroModel = new ParametroModel();
         

            _bsPlaca = new BindingSource();
            _bsTipoViaje = new BindingSource();
            _bsTipoAlmacen = new BindingSource();
            _bsFiltroLS = new BindingSource();
            _bsFiltroPlacaLS = new BindingSource();
            _bsListarLSGrid = new BindingSource();
            _bsTipoTrans = new BindingSource();

            _view.Tamanio = "60";
            //Load data to DataSources

            LoadFiltroPlacaLS();

            LoadComboData("TIPOTRANS", _bsTipoTrans,"Error al cargar los datos de transportistas");
            LoadComboData("TIPOVIAJE", _bsTipoViaje, "Error al cargar los tipos de viajes");
            LoadComboData("TIPOALMACE", _bsTipoAlmacen, "Error al cargar los tipos de almacenes");
            LoadComboData("PLACAS", _bsPlaca, "Error al cargar los datos de placas");

            SetFechas();

            //Pass Datasources to forms controls
            _view.SetBindingSourcePlaca(_bsPlaca);
            _view.SetBindingSourceTipoViaje(_bsTipoViaje);
            _view.SetBindingSourceAlmacen(_bsTipoAlmacen);
            _view.SetBindingSourceFiltro(_bsFiltroLS);
            _view.SetBindingSourcePlacaFiltroLS(_bsFiltroPlacaLS);
            _view.SetBindingSourceListaLS(_bsListarLSGrid);

            _view.SetBindingSourceNomTransportistas(_bsTipoTrans);


            _view.RegisterLS += RegisterLS;
            _view.ChangeCheck += ChangeCheck;
            _view.SelectedRow += SelectedRow;
            _view.SelectedComboPlaca += SelectedComboPlaca;
            _view.DtpChangeValue += DtpChangeValue;
            _view.SearchFilter += SearchFiltroLS;
            _view.GetDetail += GetDetail;
            _view.ExportExcelLS += ExportExcelLS;

            _view.ChangeTabPage += ChangeTabPage;

            _view.GoBack += GoBack;
            _view.GoNext += GoNext;
            _view.Search += Search;
            _view.ChangeTamanioValue += ChangeTamanioValue;



        }

        private void ChangeTamanioValue(object sender, EventArgs e)
        {
            KeyPressEventArgs  evTarget= (KeyPressEventArgs)e;
            char valKey= (evTarget).KeyChar;
            //Permite ingresar numeros
            if (valKey != '\b') 
            {
                if (!Int32.TryParse(valKey.ToString(), out _)) 
                {
                    evTarget.Handled = true;
                    _view.Tamanio = "60";
                    _view.PaginaActual = "1";
                    _view.TotalPagina = "0";
                    return;
                }
            }

            _view.PaginaActual = "1";
            _view.TotalPagina = "0";

            //Alerts.BuilAlerts(valKey.ToString(), MessageBoxIcon.Information);
        }

        private void ExportExcelLS(object sender, EventArgs e)
        {
            int totalPaginas = 0;
            int totalFilas = 0;
            string result = "";
            try
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    DialogResult dialogResult=fbd.ShowDialog();

                    if (dialogResult == DialogResult.OK) 
                    {
                        ListarLSRequestDTO req = new ListarLSRequestDTO();
                        req.FechaDespachoInicio = _view.FechaDespachoFiltroInicio;
                        req.FechaDespachoFinal = _view.FechaDespachoFiltroFinal;
                        req.CodPlaca = Convert.ToByte(((ParametroModel)_view.ComboPlaca).CodIden);
                        req.Habilitado = _view.HabilitarFiltro;

                        List<ListarLSDTO> response = _repo.ListarLS(req,
                                                                     1,
                                                                     6000,
                                                                     out totalPaginas,
                                                                     out totalFilas);

                        if (totalFilas == 0)
                        {
                            Alerts.BuilAlerts("No hay registros para generar el excel", MessageBoxIcon.Warning);
                            return;
                        }
                           
                        result =ExcelUtil.GenerateExcelLS(response, fbd.SelectedPath.Trim());

                        if (result == "ok")
                            Alerts.BuilAlerts("Se genero el excel en la ruta solicitada ", MessageBoxIcon.Information);
                        else
                            throw new Exception("");
                          
                    }
                }

            }
            catch (Exception ex)
            {
                Alerts.BuilAlerts("Ocurrio un problema al exportar la data", MessageBoxIcon.Error);
            }
        }

        private void GetDetail(object sender, EventArgs e)
        {
            ListarLSDTO headerData = (ListarLSDTO)_bsListarLSGrid.Current;
            //DetalleLSView _viewDetalle = DetalleLSView.GetInstance();
            _viewModal = new DetalleLSView();
            if (_modalPresenter == null)
                _modalPresenter = new DetalleLSPresenter(_viewModal, _repo, headerData,this);

            _modalPresenter = null;
            _viewModal = null;

        }

        private void LoadComboData(string codPrm,BindingSource src,string msgError)
        {
            _parametroModel.CodPrm = codPrm;
            _parametroModel.FlagFrm = 1;
            try
            {
                var response = _repo.ObtenerParametros(_parametroModel);
                //Fill data to register combo
                src.DataSource = response;

            }
            catch (Exception)
            {
                Alerts.BuilAlerts(msgError, MessageBoxIcon.Error);
            }

        }

        private void ChangeTabPage(object sender, EventArgs e)
        {
            ClearFormControls();
        }

        private void Search(object sender, EventArgs e)
        {
            SearchLS();
        }


        public void SearchLS()
        {
            int totalPaginas = 0;
            int totalFilas = 0;
            int tamanio = 0;

            try
            {
                ListarLSRequestDTO req = new ListarLSRequestDTO();
                req.FechaDespachoInicio = _view.FechaDespachoFiltroInicio;
                req.FechaDespachoFinal = _view.FechaDespachoFiltroFinal;
                req.CodPlaca = Convert.ToByte(((ParametroModel)_view.ComboPlaca).CodIden);
                req.Habilitado = _view.HabilitarFiltro;


                if (!Int32.TryParse(_view.Tamanio,out tamanio)) 
                {
                    Alerts.BuilAlerts("Ingrese un valor númerico en el campo mostrar", MessageBoxIcon.Warning);
                    return;
                }


                List<ListarLSDTO> response = _repo.ListarLS(req,
                                                             Convert.ToInt32(_view.PaginaActual),
                                                             tamanio,
                                                             out totalPaginas,
                                                             out totalFilas);
                _bsListarLSGrid.DataSource = response;

                _view.TotalPagina = totalPaginas.ToString();
                _view.TotalRegistros = totalFilas.ToString();

                if (totalFilas == 0)
                    Alerts.BuilAlerts("No hay registros", MessageBoxIcon.Warning);

            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un problema al carga la data", MessageBoxIcon.Error);
            }
        }




        private void LoadFiltroPlacaLS()
        {

            _parametroModel.CodPrm = "PLACAS";
            _parametroModel.FlagFrm = 0;
            try
            {
                var response = _repo.ObtenerParametros(_parametroModel);
                //Fill data to register combo
                _bsFiltroPlacaLS.DataSource = response;

            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error al cargar las placas", MessageBoxIcon.Error);
            }
        }



        private void DtpChangeValue(object sender, EventArgs e)
        {
            _view.FechaDespachoFiltro = _view.FechaDespacho;
        }

        private void SelectedComboPlaca(object sender, EventArgs e)
        {

            _view.PlacaFiltro = ((ParametroModel)_view.ComboPlacaData)?.Valor1;
        }

        private void SelectedRow(object sender, EventArgs e)
        {

            var LS=(BusquedaLSDTO)_bsFiltroLS.Current;
            if (LS != null) 
            {
                _view.NroViajeAnexo = LS.NroViaje.ToString();
                _view.NroViajeCalAnexo = LS.NroViajeCal;
                _bsFiltroLS.DataSource = null;
            }
           
        }

        private void ChangeCheck(object sender, EventArgs e)
        {
            if (_view.TieneAnexo) 
            {
                _view.PanelState = true;
                _view.FechaDespachoFiltro = _view.FechaDespacho;
                _view.PlacaFiltro = ((ParametroModel)_bsPlaca.Current).Valor1;
            }
            else
            {
                _view.PanelState = false;
                ClearControlAnexos();
            }
        }

        private void SearchFiltroLS(object sender, EventArgs e)
        {
            BusquedaLSReqDTO req = new BusquedaLSReqDTO();
            try
            {
                req.FechaDespacho = Convert.ToDateTime(_view.FechaDespachoFiltro).ToString("yyyyMMdd");
                req.CodPlaca = Convert.ToByte(((ParametroModel)_view.ComboPlacaData).CodIden);
                req.NroViaje =  Int32.TryParse(_view.NroViaje,out _) ? Convert.ToInt32(_view.NroViaje):0;
                req.NroViajeCal = _view.NroViajeCal;
                req.FlagMant = 1;

                var response= _repo.BusquedaLS(req);
                if (response.Count == 0)
                    Alerts.BuilAlerts("No existen registro con esos filtro", MessageBoxIcon.Warning);

                _bsFiltroLS.DataSource = response;

            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error al buscar el filtro de lista de separación", MessageBoxIcon.Error);
            }
        }

        private void RegisterLS(object sender, EventArgs e)
        {
            string msgVal = "";
            ListaSeparacionReqDTO req =new ListaSeparacionReqDTO();
            try
            {

                req.NroViaje = Int32.TryParse(_view.NroViaje, out _) ? Convert.ToInt32(_view.NroViaje) : 0;
                req.NroViajeCal = _view.NroViajeCal;

                req.TotalCubicaje = Decimal.TryParse(_view.TotalCubicaje, out _) ? Convert.ToDecimal(_view.TotalCubicaje) : 0;
                req.FechaDespacho = Convert.ToDateTime(_view.FechaDespacho).ToString("yyyyMMdd");
                req.Observaciones = _view.Observaciones;
                req.Detalle = _view.Detalle;
                //Values from Combos
                req.CodTransportista = Convert.ToByte(((ParametroModel)_view.ComboTransportista)?.CodIden);
                req.CodPlaca = Convert.ToByte(((ParametroModel)_view.ComboPlacaData).CodIden);
                req.CodTipoAlmacen = Convert.ToByte(_view.CodTipoAlmacen);
                req.CodTipoViaje = Convert.ToByte(_view.CodTipoViaje);

                //Values from anexo part
                req.TieneAnexo = _view.TieneAnexo;
                req.NroViajeAnexo = Int32.TryParse(_view.NroViajeAnexo, out _) ? Convert.ToInt32(_view.NroViajeAnexo) : 0;
                req.NroViajeCalAnexo = _view.NroViajeCalAnexo.Trim();

                msgVal = DataValidations.ValidationModel(req);

                //Validation of anexos
                if (req.TieneAnexo && (req.NroViajeAnexo == 0 || req.NroViajeCalAnexo == ""))
                    msgVal += "*Tiene que seleccionar un registros de Anexo";


                if (!String.IsNullOrEmpty(msgVal))
                {
                    Alerts.BuilAlerts("Alertas:\n"+ msgVal, MessageBoxIcon.Warning);
                    return;
                }

                req.FlagMant = _view.FlagMant;
                //Save in the database
                var resMantLS=_repo.MantLS(req);

                if (resMantLS.CodResult == 200) 
                {
                    Alerts.BuilAlerts(resMantLS.Msg, MessageBoxIcon.Information);
                    ClearFormControls();
                }
                    
                if (resMantLS.CodResult == 0)
                    Alerts.BuilAlerts(resMantLS.Msg, MessageBoxIcon.Warning);

                if (resMantLS.CodResult == 500)
                    throw new Exception("");


            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un error al registrar la lista de separación", MessageBoxIcon.Error);
            }

        }

        private void ClearFormControls() 
        {
            //Pagina de registro
            _view.NroViaje = "";
            _view.NroViajeCal = "";
        
            _view.TotalCubicaje = "";
            _view.Observaciones = "";
            _view.Detalle = "";
            _view.FechaDespacho = DateTime.Now.ToString("dd/MM/yyyy");
            _view.TieneAnexo = false;
            _view.PanelState = false;

            //Reset Combo
            _bsPlaca.DataSource = null;
            _bsTipoAlmacen.DataSource = null;
            _bsTipoViaje.DataSource = null;
            _bsTipoTrans.DataSource = null;

            LoadComboData("TIPOTRANS", _bsTipoTrans, "Error al cargar los datos de transportistas");
            LoadComboData("TIPOVIAJE", _bsTipoViaje, "Error al cargar los tipos de viajes");
            LoadComboData("TIPOALMACE", _bsTipoAlmacen, "Error al cargar los tipos de almacenes");
            LoadComboData("PLACAS", _bsPlaca, "Error al cargar los datos de placas");



            ClearControlAnexos();

            //Pagina de lista
            _bsListarLSGrid.DataSource = null;
            SetFechas();
            //Reset Combo Placa Filtro
            _bsFiltroPlacaLS.DataSource = null;
            LoadFiltroPlacaLS();
        }


        private void ClearControlAnexos() 
        {
            _view.NroViajeAnexo = "";
            _view.NroViajeCalAnexo = "";
            _view.FechaDespachoFiltro= DateTime.Now.ToString("dd/MM/yyyy");
            _bsFiltroLS.DataSource = null;
        }


        private void GoNext(object sender, EventArgs e)
        {
            int paginaActual = Convert.ToInt32(_view.PaginaActual);
            int totalPagina = Convert.ToInt32(_view.TotalPagina);

            if (paginaActual < totalPagina)
            {
                paginaActual++;
                _view.PaginaActual = paginaActual.ToString();
                SearchLS();
            }
            else
            {
                if (Convert.ToInt32(_view.TotalPagina) == 0)
                    _view.PaginaActual = "1";
                else
                    _view.PaginaActual = _view.TotalPagina;
            }

            
        }

        private void GoBack(object sender, EventArgs e)
        {
            int paginaActual = Convert.ToInt32(_view.PaginaActual);

            if (paginaActual > 1)
            {
                paginaActual--;
                _view.PaginaActual = paginaActual.ToString();
                SearchLS();
            }
            else
            {
                _view.PaginaActual = "1";
            }
          
        }


        private void SetFechas()
        {
            string mes = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            mes = mes.Length == 1 ? "0" + mes : mes;
            string fechaIniS = $"01/{mes}/{year}";
            DateTime fechaIniD = Convert.ToDateTime(fechaIniS);
            _view.FechaDespachoFiltroInicio = fechaIniD.ToString("dd/MM/yyyy");
            DateTime fechaFinal = fechaIniD.AddMonths(1).AddDays(-1);
            _view.FechaDespachoFiltroFinal = fechaFinal.ToString("dd/MM/yyyy");

        }


    }
}
