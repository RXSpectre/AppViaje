
using ProyectoViaje.Views;
using System;
using System.Windows.Forms;

namespace ProyectoViaje
{
    public partial class CAvsLsDetalleView : Form, ICAvsLSDetalleView
    {
        public CAvsLsDetalleView()
        {
            InitializeComponent();
        }

       

        public static CAvsLsDetalleView GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new CAvsLsDetalleView();
            else
                _instance.BringToFront();

            return _instance;
        }

        private static CAvsLsDetalleView _instance = null;

        public string NroViajeCP 
        {
            get { return txtNroViajeCP.Text; }
            set { txtNroViajeCP.Text = value; }
        }
        public string NroViajeCalCP
        {
            get { return txtNroViajeCalCP.Text; }
            set { txtNroViajeCalCP.Text = value; }
        }
        public string FechaCP
        {
            get { return txtFechaCP.Text; }
            set { txtFechaCP.Text = value; }
        }
        public string NivelServicioCP
        {
            get { return txtNivelServicioCP.Text; }
            set { txtNivelServicioCP.Text = value; }
        }
        public string LugarCP
        {
            get { return txtLugarCP.Text; }
            set { txtLugarCP.Text = value; }
        }
        public string TotalFleteCP
        {
            get { return txtTotalFleteCP.Text; }
            set { txtTotalFleteCP.Text = value; }
        }
        public string TotalVolEntregaCP
        {
            get { return txtTotalVolEntregaCP.Text; }
            set { txtTotalVolEntregaCP.Text = value; }
        }

        public string ObsCP
        {
            get { return txtObsCP.Text; }
            set { txtObsCP.Text = value; }
        }
        public string ArchivoOrigenCP
        {
            get { return txtAOrigenCP.Text; }
            set { txtAOrigenCP.Text = value; }
        }


        public string NroViajeLS
        {
            get { return txtNroViajeLS.Text; }
            set { txtNroViajeLS.Text = value; }
        }
        public string NroViajeCalLS
        {
            get { return txtNroViajeCalLS.Text; }
            set { txtNroViajeCalLS.Text = value; }
        }
      
        public string TransportistaLS
        {
            get { return txtTransportistaLS.Text; }
            set { txtTransportistaLS.Text = value; }
        }
        public string PlacaLS
        {
            get { return txtPlacaLS.Text; }
            set { txtPlacaLS.Text = value; }
        }
        public string TipoViajeLS
        {
            get { return txtTipoViajeLS.Text; }
            set { txtTipoViajeLS.Text = value; }
        }
        public string MetrajeLS
        {
            get { return txtMetrajeLS.Text; }
            set { txtMetrajeLS.Text = value; }
        }
        public string FechaDespachoLS
        {
            get { return txtFechaDespachoLS.Text; }
            set { txtFechaDespachoLS.Text = value; }
        }
        public string TipoAlmacenLS
        {
            get { return txtTipoAlmacenLS.Text; }
            set { txtTipoAlmacenLS.Text = value; }
        }
        public string ObservacionesLS
        {
            get { return txtObsLS.Text; }
            set { txtObsLS.Text = value; }
        }
        public string DetalleLS
        {
            get { return txtDetalleLS.Text; }
            set { txtDetalleLS.Text = value; }
               
        }
        public string NroViajeAnexoLS
        {
            get { return txtNroViajeAnexoLS.Text; }
            set { txtNroViajeAnexoLS.Text = value; }

        }
        public string NroViajeCalAnexoLS
        {
            get { return txtNroViajeCalAnexo.Text; }
            set { txtNroViajeCalAnexo.Text = value; }

        }

        public string MontoLS
        {
            get { return txtMontoLS.Text; }
            set { txtMontoLS.Text = value; }
        }

        public string Verificacion
        {
            get { return lblVerificacion.Text; }
            set { lblVerificacion.Text = value; }

        }

  


        

    }
}
