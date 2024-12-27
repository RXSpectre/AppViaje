using System;
using System.Windows.Forms;

namespace ProyectoViaje.Views
{
    public partial class MainView : Form,IMainView
    {
        public MainView()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            //+= Suscriberse a un evento
            btnCartaPorte.Click += delegate { ShowCartaPorte?.Invoke(this, EventArgs.Empty); };
            btnListaSeparacion.Click += delegate { ShowListaSeparacion?.Invoke(this, EventArgs.Empty); };
            btnCartaPorteVsListaSeparacion.Click += delegate { ShowCartaPorteVsListaSeparacion?.Invoke(this, EventArgs.Empty); };
            btnCerrar.Click += delegate { ExitApp?.Invoke(this, EventArgs.Empty); };
            btnMantParam.Click += delegate { ShowMantParam?.Invoke(this, EventArgs.Empty);};
        }

        public event EventHandler ShowCartaPorte;
        public event EventHandler ShowListaSeparacion;
        public event EventHandler ShowCartaPorteVsListaSeparacion;
        public event EventHandler ExitApp;
        public event EventHandler ShowMantParam;
    }
}
