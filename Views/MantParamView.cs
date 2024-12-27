using System;
using System.Windows.Forms;

namespace ProyectoViaje.Views
{
    public partial class MantParamView : Form, IMantParamView
    {
        public MantParamView()
        {
            InitializeComponent();
            InitEvents();

        }

        private void InitEvents()
        {
            btnBuscar.Click += delegate { Search?.Invoke(this, EventArgs.Empty); };
            btnEditar.Click += delegate
            {
                FlagMant = 'E';
                txtCodParamMant.ReadOnly = true;
                txtCodIdenMant.ReadOnly = true;
                Edit?.Invoke(this, EventArgs.Empty);
            };
            btnMant.Click += delegate { Mant?.Invoke(this, EventArgs.Empty); };
            btnNuevo.Click += delegate
            {
                FlagMant = 'I';
                txtCodParamMant.ReadOnly = false;
                txtCodIdenMant.ReadOnly = false;
                New?.Invoke(this, EventArgs.Empty);
            };
            
        }

        private static MantParamView _instance = null;
        private char _flagMant;

        public string CodParamFiltro 
        {
            get { return txtFiltroCodParam.Text; }
            set { txtFiltroCodParam.Text = value; }
        }
        public string CodIdenFiltro
        {
            get { return txtFiltroCodIden.Text; }
            set { txtFiltroCodIden.Text = value; }
        }
       
        public string CodParamMant
        {
            get { return txtCodParamMant.Text; }
            set { txtCodParamMant.Text = value; }
        }
        public string CodIdenMant
        {
            get { return txtCodIdenMant.Text; }
            set { txtCodIdenMant.Text = value; }
        }
        public string Valor1Mant
        {
            get { return txtValor1Mant.Text; }
            set { txtValor1Mant.Text = value; }
        }
        public string Valor2Mant
        {
            get { return txtValor2Mant.Text; }
            set { txtValor2Mant.Text = value; }
        }
        public bool HabilitadoMant
        {
            get { return chkHabilitadoMant.Checked; }
            set { chkHabilitadoMant.Checked = value; }
        }

        public bool HabilitadoFiltro
        {
            get { return chkHabiltaFiltro.Checked; }
            set { chkHabiltaFiltro.Checked = value; }
        }

        public string tituloEtiqueta
        {
            get { return lblMant.Text; }
            set { lblMant.Text = value; }
        }

        public string tituloBoton
        {
            get { return btnMant.Text; }
            set { btnMant.Text = value; }
        }

        public char FlagMant
        {
            get { return _flagMant; }
            set { _flagMant = value; }
        }

        public event EventHandler Search;
        public event EventHandler Mant;
        public event EventHandler Edit;
        public event EventHandler New;

        public static MantParamView GetInstance(Form form)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new MantParamView();
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

        public void SetBindingSourceDgvParametros(BindingSource src)
        {
            dgvParametros.DataSource = src;
        }

     
    }
}
