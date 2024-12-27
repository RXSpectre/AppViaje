using System;
using System.Windows.Forms;

namespace ProyectoViaje.Views
{
    public partial class CartaPorteView : Form,ICartaPorteView
    {
        public CartaPorteView()
        {
            InitializeComponent();
            EventInit();
        }

        //Pattern Singleton
        private static CartaPorteView _instance = null;
        public static CartaPorteView GetInstance(Form form)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new CartaPorteView();
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




        private void EventInit()
        {
            btnChooseFiles.Click += delegate { ChooseFilesEntries?.Invoke(this, EventArgs.Empty); };
            btnProcessFiles.Click += delegate { ProccesFiles?.Invoke(this, EventArgs.Empty); };
            btnSelecDestino.Click += delegate { ChooseFilesDestinies?.Invoke(this, EventArgs.Empty); };
        }

        public string QuantitySelectedFiles {
            get { return lbFilesSources.Text; }
            set { lbFilesSources.Text = value; }
        }
        public string PathFilesDestiny
        {
            get { return txtPathFileDestiny.Text; }
            set { txtPathFileDestiny.Text = value; }
        }

        public event EventHandler ChooseFilesEntries;
        public event EventHandler ProccesFiles;
        public event EventHandler ChooseFilesDestinies;
    }
}
