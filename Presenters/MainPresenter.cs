using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoViaje.Repositories;
using ProyectoViaje.Repositories.Interfaces;
using ProyectoViaje.Views;


namespace ProyectoViaje.Presenters
{
    public class MainPresenter
    {
        //Fields
        private IMainView _view;
        private IViajesRepo _repo;
        private  ListaSeparacionPresenter _listaSeparacionPresenter=null;
        private  CartaPortePresenter _CartaPortePresenter=null;
        private  CAvsLSPresenter _CAVsLSPresenter = null;
        private  MantParamPresenter _mantParamPresenter = null;

        public MainPresenter(IMainView view, IViajesRepo repo)
        {
            _repo = repo;

            _view = view;
            _view.ShowCartaPorte += ShowCartaPorte;
            _view.ShowListaSeparacion += ShowListaSeparacion;
            _view.ShowCartaPorteVsListaSeparacion += ShowCartaPorteVsListaSeparacion;
            _view.ShowMantParam += ShowMantParam;
            _view.ExitApp += ExitApp;
        }

        private void ShowMantParam(object sender, EventArgs e)
        {
            IMantParamView view = MantParamView.GetInstance((Form)_view);
            if (_mantParamPresenter == null)
                _mantParamPresenter = new MantParamPresenter(view, _repo);
            
        }

        private void ExitApp(object sender, EventArgs e)
        {
            _view.Close();
        }

        private void ShowCartaPorteVsListaSeparacion(object sender, EventArgs e)
        {
            ICAvsLSView view = CAvsLSView.GetInstance((Form)_view);
            if (_CAVsLSPresenter == null)
                _CAVsLSPresenter = new CAvsLSPresenter(view,_repo);
            
        }

        private void ShowListaSeparacion(object sender, EventArgs e)
        {
            
            IListaSeparacionView view = ListaSeparacionView.GetInstance((Form)_view);
            if(_listaSeparacionPresenter==null)
                _listaSeparacionPresenter=new ListaSeparacionPresenter(view, _repo);
            


        }

        private void ShowCartaPorte(object sender, EventArgs e)
        {
           
            ICartaPorteView view = CartaPorteView.GetInstance((Form)_view);
            if (_CartaPortePresenter == null)
                _CartaPortePresenter = new CartaPortePresenter(view, _repo);
           


        }
    }
}
