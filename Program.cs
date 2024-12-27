using ProyectoViaje.Views;
using ProyectoViaje.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ProyectoViaje.Repositories.Interfaces;
using ProyectoViaje.Repositories;

namespace ProyectoViaje
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainView view = new MainView();
            string connectionString = ConfigurationManager.ConnectionStrings["ConexCartaPorte"].ConnectionString;
            IViajesRepo repo = new ViajesRepo(connectionString);
            new MainPresenter(view, repo);
            Application.Run((Form)view);
        }
    }
}
