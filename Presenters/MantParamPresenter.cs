using ProyectoViaje.DTO;
using ProyectoViaje.Models;
using ProyectoViaje.Presenters.Common;
using ProyectoViaje.Repositories.Interfaces;
using ProyectoViaje.Views;
using System;
using System.Windows.Forms;

namespace ProyectoViaje.Presenters
{
    public class MantParamPresenter
    {

        private IMantParamView _view;
        private IViajesRepo _repo;
        private BindingSource _bsDgParametros;


        private ParametroModel _model;

        public MantParamPresenter(IMantParamView view, IViajesRepo repo)
        {
            _view = view;
            _repo = repo;
            _bsDgParametros = new BindingSource();
            _model = new ParametroModel();

            _view.Show();

            _view.FlagMant = 'I';
            _view.Mant += Mant;
            _view.Edit += Edit;
            _view.Search += Search;
            _view.New += New;

            _view.SetBindingSourceDgvParametros(_bsDgParametros);



        }

        private void New(object sender, EventArgs e)
        {
            ClearForm();

            _view.tituloEtiqueta = "Registro";
            _view.tituloBoton = "Insertar Registro";

        }

        private void Edit(object sender, EventArgs e)
        {
            ParametroModel model =(ParametroModel)_bsDgParametros.Current;
            if (model != null)
            {
                _view.CodParamMant = model.CodPrm;
                _view.CodIdenMant = model.CodIden;
                _view.Valor1Mant = model.Valor1;
                _view.Valor2Mant = model.Valor2;
                _view.HabilitadoMant = model.Habilitado == "1" ? true : false;

                _view.tituloEtiqueta = "Edición";
                _view.tituloBoton = "Editar Registro";
            }
            else
            {
                Alerts.BuilAlerts("¡Selecciona un registro por favor!", MessageBoxIcon.Warning);
                ClearForm();
            }
        }

        public void ClearForm()
        {
            _view.CodParamMant = "";
            _view.CodIdenMant = "";
            _view.Valor1Mant = "";
            _view.Valor2Mant = "";
            _view.HabilitadoMant = true;
        }



        private void Search(object sender, EventArgs e)
        {
            SearchMant();
        }


        public void SearchMant() 
        {
            _model.CodPrm = _view.CodParamFiltro;
            _model.CodIden = _view.CodIdenFiltro;
            _model.Habilitado = _view.HabilitadoFiltro ? "1" : "0";
            _model.FlagFrm = 0;
            try
            {
                var response = _repo.ObtenerParametros(_model);
                _bsDgParametros.DataSource = response;
            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un problema al carga los datos", MessageBoxIcon.Error);
            }
        }

        private void Mant(object sender, EventArgs e)
        {
            ParametroMantReqDTO request = new ParametroMantReqDTO();
            request.CodPrm = _view.CodParamMant;
            request.CodIden = _view.CodIdenMant;
            request.Valor1 = _view.Valor1Mant;
            request.Valor2 = _view.Valor2Mant;
            request.Habilitado = _view.HabilitadoMant ? "1" : "0";
            request.FlagMant = _view.FlagMant;
            string msgValidations = "";

            msgValidations=DataValidations.ValidationModel(request);

            if (msgValidations.Length > 0) 
            {
                Alerts.BuilAlerts(msgValidations, MessageBoxIcon.Warning);
                return;
            }
               

            try
            {
                var response = _repo.ParametroMant(request);

                if (response.CodResult == 200) 
                {
                    Alerts.BuilAlerts(response.Msg, MessageBoxIcon.Information);
                    SearchMant();
                }
                    
                if (response.CodResult == 500)
                    Alerts.BuilAlerts(response.Msg, MessageBoxIcon.Warning);

            }
            catch (Exception)
            {
                Alerts.BuilAlerts("Ocurrio un problema al carga los datos de los parametros", MessageBoxIcon.Error);
            }



        }
    }
}
