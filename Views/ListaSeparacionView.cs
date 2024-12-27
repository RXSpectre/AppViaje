using System;
using System.Windows.Forms;


namespace ProyectoViaje.Views
{
    public partial class ListaSeparacionView : Form , IListaSeparacionView
    {
        
        public ListaSeparacionView()
        {
            InitializeComponent();
            InitEvents();
        }

        private static ListaSeparacionView _instance = null;

        private short _flagMant;

        public static ListaSeparacionView GetInstance(Form form) 
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new ListaSeparacionView();
                _instance.MdiParent = form;
                _instance.FormBorderStyle = FormBorderStyle.None;
                _instance.Dock = DockStyle.Fill;
            }
            else 
                _instance.BringToFront();
         

            return _instance;
        }


        private void InitEvents()
        {
            btnRegistrarLS.Click += delegate {
                 FlagMant = 1;
                 RegisterLS?.Invoke(this, EventArgs.Empty);
            };
            chkAnexo.CheckedChanged += delegate { ChangeCheck?.Invoke(this, EventArgs.Empty);};
            btnSeleccionar.Click += delegate { SelectedRow?.Invoke(this, EventArgs.Empty);};

            cmbPlaca.SelectedIndexChanged += delegate { SelectedComboPlaca?.Invoke(this, EventArgs.Empty);};

            dtpFechaDespacho.ValueChanged+= delegate { DtpChangeValue?.Invoke(this, EventArgs.Empty); };
            btnBuscarFiltro.Click += delegate { SearchFilter?.Invoke(this, EventArgs.Empty); };

            btnAnterior.Click += delegate { GoBack?.Invoke(this, EventArgs.Empty); };
            btnSiguente.Click += delegate { GoNext?.Invoke(this, EventArgs.Empty); };
            btnBuscarLS.Click += delegate { Search?.Invoke(this, EventArgs.Empty); };
            btnExportar.Click += delegate { ExportExcelLS?.Invoke(this, EventArgs.Empty); };

            tabControl1.SelectedIndexChanged+= delegate { ChangeTabPage?.Invoke(this, EventArgs.Empty); };

            dgvListaLS.CellContentDoubleClick += delegate { GetDetail?.Invoke(this, EventArgs.Empty); };

            //txtTamanio.KeyUp+=delegate { ; };


            txtTamanio.KeyPress += (o, e) => {
                ChangeTamanioValue?.Invoke(this, e);
            };

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
       
        public object ComboTransportista
        {
            get { return cmbTransportista.SelectedItem; }
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
            get { return txtObs.Text;  }
            set { txtObs.Text = value; }
        }
        public string Detalle
        {
            get { return txtDetalle.Text; }
            set { txtDetalle.Text = value; }
        }

        

        public object ComboPlacaData
        {
            get { return cmbPlaca.SelectedItem; }
        }

        public string CodTipoViaje
        {
            get { return cmbTipoViaje.SelectedValue.ToString(); }
        }

        public string CodTipoAlmacen
        {
            get { return cmbTipoAlmacen.SelectedValue.ToString(); }
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

        public string NroViajeCalAnexo
        {
            get { return txtNroViajeCalAnexo.Text; }
            set { txtNroViajeCalAnexo.Text = value; }
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

        

        public bool PanelState
        {
            get { return panelFiltroAnexo.Visible; }
            set { panelFiltroAnexo.Visible = value; }
        }

        public string PaginaActual
        {
            get { return lblAct.Text; }
            set { lblAct.Text = value; }
        }
        public string TotalPagina
        {
            get { return lblTotal.Text; }
            set { lblTotal.Text = value; }
        }

        public string TotalRegistros
        {
            get { return lblTotalRegistros.Text; }
            set { lblTotalRegistros.Text = value; }
        }


        public string FechaDespachoFiltroInicio
        {
            get { return dtpFDespachoInicio.Text; }
            set { dtpFDespachoInicio.Text = value; }
        }

        public string FechaDespachoFiltroFinal
        {
            get { return dtpFDespachoFinal.Text; }
            set { dtpFDespachoFinal.Text = value; }
        }



        public object ComboPlaca
        {
            get
            {
                return cmbPlacaFiltro.SelectedItem;
            }
        }

        public short FlagMant
        {
            get { return _flagMant; }
            set { _flagMant = value; }
        }

        public bool HabilitarFiltro
        {
            get { return chkHabilitado.Checked; }
            set { chkHabilitado.Checked = value; }
        }

        public string Tamanio
        {
            get { return txtTamanio.Text; }
            set { txtTamanio.Text = value; }
        }

        public event EventHandler RegisterLS;
   
        public event EventHandler ChangeCheck;
        public event EventHandler SelectedRow;
        public event EventHandler SelectedComboPlaca;
        public event EventHandler DtpChangeValue;

        public event EventHandler SearchFilter;
        public event EventHandler GoBack;
        public event EventHandler GoNext;
        public event EventHandler Search;
        public event EventHandler ChangeTabPage;
        public event EventHandler GetDetail;
        public event EventHandler ExportExcelLS;
        public event EventHandler ChangeTamanioValue;

        public void SetBindingSourceAlmacen(BindingSource src)
        {
            cmbTipoAlmacen.DataSource = src;
            cmbTipoAlmacen.DisplayMember = "Valor1";
            cmbTipoAlmacen.ValueMember = "CodIden";
        }

        public void SetBindingSourcePlaca(BindingSource src)
        {

            cmbPlaca.DataSource = src;
            cmbPlaca.DisplayMember = "Valor1";
            cmbPlaca.ValueMember = "CodIden";
        }

        public void SetBindingSourceTipoViaje(BindingSource src)
        {
            cmbTipoViaje.DataSource = src;
            cmbTipoViaje.DisplayMember = "Valor1";
            cmbTipoViaje.ValueMember = "CodIden";
            
        }

        public void SetBindingSourceFiltro(BindingSource src)
        {
            dtGridFiltroLS.DataSource = src;
        }


        public void SetBindingSourceListaLS(BindingSource src)
        {
            dgvListaLS.DataSource = src;
        }

        public void SetBindingSourcePlacaFiltroLS(BindingSource src)
        {
            cmbPlacaFiltro.DataSource = src;
            cmbPlacaFiltro.DisplayMember = "Valor1";
            cmbPlacaFiltro.ValueMember = "CodIden";
        }

        public void SetBindingSourceNomTransportistas(BindingSource src)
        {
            cmbTransportista.DataSource = src;
            cmbTransportista.DisplayMember = "Valor1";
            cmbTransportista.ValueMember = "CodIden";
        }

       
    }
}
