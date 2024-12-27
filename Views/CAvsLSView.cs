using System;
using System.Windows.Forms;

namespace ProyectoViaje.Views
{
    public partial class CAvsLSView : Form, ICAvsLSView
    {
        public CAvsLSView()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            btnAnterior.Click += delegate { GoBack?.Invoke(this, EventArgs.Empty); };
            btnSiguente.Click += delegate { GoNext?.Invoke(this, EventArgs.Empty); };
            btnBuscar.Click += delegate { Search?.Invoke(this, EventArgs.Empty); };
            dtgvCAvsLS.CellContentDoubleClick += delegate { GetDetail?.Invoke(this, EventArgs.Empty); };
            txtTamanio.KeyPress += (o, e) => {
                ChangeTamanioValue?.Invoke(this, e);
            };
        }

        private static CAvsLSView _instance = null;
        public static CAvsLSView GetInstance(Form form)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new CAvsLSView();
                _instance.MdiParent = form;
                _instance.Dock = DockStyle.Fill;
                _instance.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                _instance.BringToFront();
            }


            return _instance;
        }

        public void SetBindingSourceDtgvCAvsLS(BindingSource src)
        {
            dtgvCAvsLS.DataSource = src;
        }

        public void SetBindingSourceCombo(BindingSource src)
        {
            cmbPlacaFiltro.DataSource = src;
            cmbPlacaFiltro.DisplayMember = "Valor1";
            cmbPlacaFiltro.ValueMember = "CodIden";
        }

        public event EventHandler GoBack;
        public event EventHandler GoNext;
        public event EventHandler Search;
        public event EventHandler GetDetail;
        public event EventHandler ChangeTamanioValue;

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

        public string Tamanio
        {
            get { return txtTamanio.Text; }
            set { txtTamanio.Text = value; }
        }
    }
}