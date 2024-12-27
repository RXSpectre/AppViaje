using System;
using System.Windows.Forms;

namespace ProyectoViaje.Views
{
    public partial class DetalleLSView : Form , IDetalleLSView
    {
        private short _flagMant;


        //private static DetalleLSView _instance = null;
       

        //public static DetalleLSView GetInstance()
        //{
        //    if (_instance == null || _instance.IsDisposed)
        //    {
        //        _instance = new DetalleLSView();
        //    }
        //    else
        //        _instance.BringToFront();

        //    return _instance;
        //}

        public DetalleLSView()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            
                btnEditLS.Click += delegate {
                    FlagMant = 2;
                    EditLS?.Invoke(this, EventArgs.Empty);
                };

                btnDeshabilitarLS.Click += delegate {
                    FlagMant = 3;
                    DisableLS?.Invoke(this, EventArgs.Empty);

                };

                btnBuscarFiltro.Click += delegate {
                    SearchFilterLS?.Invoke(this, EventArgs.Empty);
                };

                cmbPlaca.SelectedIndexChanged += delegate { SelectedComboPlaca?.Invoke(this, EventArgs.Empty); };

                chkAnexo.CheckedChanged += delegate { ChangeCheck?.Invoke(this, EventArgs.Empty); };
                btnSeleccionar.Click += delegate { SelectedRow?.Invoke(this, EventArgs.Empty); };


        }

        public void SetBSCmbPlaca(BindingSource src)
        {
            cmbPlaca.DataSource = src;
            cmbPlaca.DisplayMember = "Valor1";
            cmbPlaca.ValueMember = "CodIden";
        }

        public void SetBSCmbTransportista(BindingSource src)
        {
            cmbTransportista.DataSource = src;
            cmbTransportista.DisplayMember = "Valor1";
            cmbTransportista.ValueMember = "CodIden";
        }

        public void SetBSCmbTipoViaje(BindingSource src)
        {
            cmbTipoViaje.DataSource = src;
            cmbTipoViaje.DisplayMember = "Valor1";
            cmbTipoViaje.ValueMember = "CodIden";
        }

        public void SetBSCmbTipoAlmacen(BindingSource src)
        {
            cmbTipoAlmacen.DataSource = src;
            cmbTipoAlmacen.DisplayMember = "Valor1";
            cmbTipoAlmacen.ValueMember = "CodIden";
        }

        public void SetBindingSourceFiltro(BindingSource src)
        {
            dtGridFiltroLS.DataSource = src;
        }

        public string NroViaje
        {
            get { return txtNroViaje.Text; }
            set { txtNroViaje.Text = value; }
        }

        public string NroViajeCal
        {
            get { return txtNroViajeCal.Text; }
            set { txtNroViajeCal.Text = value; }
        }


        public string TotalCubicaje
        {
            get { return txtTotalCubiaje.Text; }
            set { txtTotalCubiaje.Text = value; }
        }
        public string FechaDespacho
        {
            get { return dtpFechaDespacho.Text; }
            set { dtpFechaDespacho.Text = value; }
        }

        public string Observaciones
        {
            get { return txtObs.Text; }
            set { txtObs.Text = value; }
        }
        public string Detalle
        {
            get { return txtDetalle.Text; }
            set { txtDetalle.Text = value; }
        }

        public bool TieneAnexo
        {
            get { return chkAnexo.Checked; }
            set { chkAnexo.Checked = value; }
        }
        public string NroViajeAnexo
        {
            get { return txtNroViajeAnexo.Text; }
            set { txtNroViajeAnexo.Text = value; }
        }

        public bool PanelState
        {
            get { return panelFiltroAnexo.Visible; }
            set { panelFiltroAnexo.Visible = value; }
        }


        public string NroViajeCalAnexo
        {
            get { return txtNroViajeCalAnexo.Text; }
            set { txtNroViajeCalAnexo.Text = value; }
        }

        public short FlagMant
        {
            get { return _flagMant; }
            set { _flagMant = value; }
        }

        public object ComboPlaca
        {
            get { return cmbPlaca.SelectedItem; }
            set { cmbPlaca.SelectedValue = value.ToString(); }
        }


        public object ComboTransportista
        {
            get { return cmbTransportista.SelectedItem; }
            set { cmbTransportista.SelectedValue = value.ToString(); }
        }
        public object ComboTipoViaje
        {
            get { return cmbTipoViaje.SelectedItem; }
            set { cmbTipoViaje.SelectedValue = value.ToString(); }
        }

        public object ComboTipoAlmacen
        {
            get { return cmbTipoAlmacen.SelectedItem; }
            set { cmbTipoAlmacen.SelectedValue = value.ToString(); }
        }

        public string FechaDespachoFiltro
        {
            get { return txtFechaDespachoFiltro.Text; }
            set { txtFechaDespachoFiltro.Text = value; }
        }

        public string PlacaFiltro
        {
            get { return txtPlacaFiltro.Text; }
            set { txtPlacaFiltro.Text = value; }
        }

        public event EventHandler EditLS;
        public event EventHandler DisableLS;
        public event EventHandler SearchFilterLS;
        public event EventHandler SelectedComboPlaca;
        public event EventHandler ChangeCheck;
        public event EventHandler SelectedRow;
    }
}
