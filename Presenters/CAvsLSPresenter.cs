using ProyectoViaje.DTO;
using ProyectoViaje.Models;
using ProyectoViaje.Presenters.Common;
using ProyectoViaje.Repositories.Interfaces;
using ProyectoViaje.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoViaje.Presenters
{
    public class CAvsLSPresenter
    {
        private readonly IViajesRepo _repo;
        private readonly ICAvsLSView _view;
        private CAvsLSDetallePresenter _CAvsLSDetallePresenter = null;
        private BindingSource _BSdtgvCAvsLS;
        private BindingSource _bsComboPlaca;

        private ListarCAvsLSReqDTO _reqDetailDTO;
        private ListarLSRequestDTO _reqListarLsDto ;


        //Modal
        public CAvsLSPresenter(ICAvsLSView view,IViajesRepo repo)
        {
            _BSdtgvCAvsLS = new BindingSource();
            _bsComboPlaca = new BindingSource();
            _reqDetailDTO = new ListarCAvsLSReqDTO();
            _reqListarLsDto = new ListarLSRequestDTO();


            _repo = repo;
            _view = view;
          
            _view.Show();
            _view.Tamanio = "60";

            LoadPlacas();
            SetFechas();
            _view.SetBindingSourceCombo(_bsComboPlaca);

            _view.GoBack += GoBack;
            _view.GoNext += GoNext;
            _view.Search += Search;
            _view.GetDetail += GetDetail;
            _view.ChangeTamanioValue += ChangeTamanioValue;

            GetAllCaVsLS();
          
            _view.SetBindingSourceDtgvCAvsLS(_BSdtgvCAvsLS);
            
        }

        private void ChangeTamanioValue(object sender, EventArgs e)
        {
            KeyPressEventArgs evTarget = (KeyPressEventArgs)e;
            char valKey = (evTarget).KeyChar;
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
        }

        private void GetDetail(object sender, EventArgs e)
        {
            ListarCAvsLSCabDTO headerData = (ListarCAvsLSCabDTO)_BSdtgvCAvsLS.Current;
            CAvsLsDetalleView _viewDetalle = CAvsLsDetalleView.GetInstance();

            _reqDetailDTO.NroCartaPorteCA = headerData.NroCartaPorte;
            _reqDetailDTO.NroViajeCalCA = headerData.NroViajeCal;

            var response =_repo.ListarCAvsLSDet(_reqDetailDTO);
            if(_CAvsLSDetallePresenter==null)
                _CAvsLSDetallePresenter=new CAvsLSDetallePresenter(_viewDetalle, response);

            _CAvsLSDetallePresenter = null;
        }

        private void LoadPlacas()
        {
            ParametroModel model = new ParametroModel();
            model.CodPrm = "PLACAS";
            model.FlagFrm = 0;
            try
            {
               var response =_repo.ObtenerParametros(model);
                _bsComboPlaca.DataSource = response;
            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un problema al carga las placas", MessageBoxIcon.Error);
            }
        }

        private void Search(object sender, EventArgs e)
        {
            ListarCAvsLS();
        }


        public void ListarCAvsLS() 
        {
            int totalPaginas = 0;
            int totalFilas = 0;
            int tamanio = 0;
            try
            {
                _reqListarLsDto.FechaDespachoInicio = _view.FechaDespachoFiltroInicio;
                _reqListarLsDto.FechaDespachoFinal = _view.FechaDespachoFiltroFinal;
                _reqListarLsDto.CodPlaca = Convert.ToByte(((ParametroModel)_view.ComboPlaca).CodIden);

                if (!Int32.TryParse(_view.Tamanio, out tamanio))
                {
                    Alerts.BuilAlerts("Ingrese un valor númerico en el campo mostrar", MessageBoxIcon.Warning);
                    return;
                }

                List<ListarCAvsLSCabDTO> response = _repo.ListarCAvsLS(_reqListarLsDto,
                                                  Convert.ToInt32(_view.PaginaActual),
                                                  tamanio,
                                                  out totalPaginas,
                                                  out totalFilas);
                _BSdtgvCAvsLS.DataSource = response;

                _view.TotalPagina = totalPaginas.ToString();
                _view.TotalRegistros = totalFilas.ToString();

                if (totalFilas == 0)
                    Alerts.BuilAlerts("No hay registros", MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                Alerts.BuilAlerts("Ocurrio un problema al carga la data", MessageBoxIcon.Error);
            }


        }


        private void GetAllCaVsLS()
        {
            ListarCAvsLS();
        }

        private void GoNext(object sender, EventArgs e)
        {
            int paginaActual = Convert.ToInt32(_view.PaginaActual);
            int totalPagina = Convert.ToInt32(_view.TotalPagina);

            if (paginaActual<totalPagina)
            {
                paginaActual++;
                _view.PaginaActual = paginaActual.ToString();
                GetAllCaVsLS();
            }
            else
            {
                if (Convert.ToInt32(_view.TotalPagina) == 0)
                    _view.PaginaActual = "1";
                else
                    _view.PaginaActual = _view.TotalPagina;
            }

            //GetAllCaVsLS();
        }

        private void GoBack(object sender, EventArgs e)
        {
            int paginaActual =Convert.ToInt32(_view.PaginaActual);

            if (paginaActual > 1)
            {
                paginaActual--;
                _view.PaginaActual = paginaActual.ToString();
                GetAllCaVsLS();
            }
            else
            {
                _view.PaginaActual = "1";
            }

           
        }

        private void SetFechas() 
        {
            string mes =  DateTime.Now.Month.ToString();
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
