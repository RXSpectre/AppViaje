using ProyectoViaje.Views;
using ProyectoViaje.Models;
using ProyectoViaje.Presenters.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ProyectoViaje.Presenter.Common;
using ProyectoViaje.Repositories.Interfaces;

namespace ProyectoViaje.Presenters
{
    public class CartaPortePresenter
    {
        private ICartaPorteView _view;
        private IViajesRepo _repo;
        private string[] selectedFiles = null;


        public CartaPortePresenter(ICartaPorteView view, IViajesRepo repo)
        {
            _view = view;
            _repo = repo;

            _view.ChooseFilesEntries += ChooseFilesEntries;
            _view.ProccesFiles += ProccesFiles;
            _view.ChooseFilesDestinies += ChooseFilesDestinies;

            view.Show();
        }

        private void ChooseFilesDestinies(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) 
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _view.PathFilesDestiny = fbd.SelectedPath;
                }

            } 

        }

        private void ProccesFiles(object sender, EventArgs e)
        {
            int savedFiles = 0;
            int notSavedFiles = 0;

            if (selectedFiles == null)
                Alerts.BuilAlerts("¡Tiene que escoger minimo un archivo (*Pdf)!", MessageBoxIcon.Warning);
            else if (String.IsNullOrEmpty(_view.PathFilesDestiny))
                Alerts.BuilAlerts("¡La ruta destino es obligatorio!", MessageBoxIcon.Warning);
            else if (!Directory.Exists(_view.PathFilesDestiny))
                Alerts.BuilAlerts("¡La ruta destino no existe!", MessageBoxIcon.Warning);
            else
            {
                FileInfo[] filesSource = new FileInfo[selectedFiles.Length];
                for (int i = 0; i < selectedFiles.Length; i++)
                    filesSource[i] = new FileInfo(selectedFiles[i]);
                

                try
                {
                    foreach (var files in filesSource)
                    {
                        string fileName = files.Name.Split('.')[0];
                        List<CartaPorteModel> resPdf = PDFUtil.ProcessDataPdf(files.FullName, fileName);

                        if (resPdf.Count == 0)
                            throw new Exception($"No se pudo leer el PDF :{fileName}");

                      
                        var resExcel = ExcelUtil.GenerateCartaPorteExcel(resPdf, _view.PathFilesDestiny, fileName);
                        if (!String.IsNullOrEmpty(resExcel))
                            throw new Exception(resExcel);

                        //Save in Bd
                        if (resPdf.Count > 0)
                        {
                            foreach (CartaPorteModel item in resPdf)
                            {
                                ResponseModel resultInsert = _repo.InsertarCA(item);
                                if (resultInsert.CodResult == 200)
                                    savedFiles++;
                                else
                                    notSavedFiles++;
                            }
                        }
                    }
                    string resultMsg = $"Registros Guardados:{savedFiles} \nRegistros No Guardados:{notSavedFiles}";
                    Alerts.BuilAlerts(resultMsg, MessageBoxIcon.Information);
                    ResetControls();
                }
                catch (Exception ex)
                {
                    Alerts.BuilAlerts(ex.Message, MessageBoxIcon.Error);
                }
            }
        }

        private void ChooseFilesEntries(object sender, EventArgs e)
        {
          
            using (OpenFileDialog ofd = new OpenFileDialog()) 
            {
                //Can choose many files
                ofd.Multiselect = true;
                //Only can choose pdf files
                ofd.Filter = "Pdf Files|*.pdf";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFiles = ofd.FileNames;
                    _view.QuantitySelectedFiles = $"{selectedFiles.Length}  archivos seleccionados";
                }
                else
                {
                    ResetControls();
                }
            }

        }

        void ResetControls()
        {
            selectedFiles = null;
            _view.QuantitySelectedFiles = "...";
            _view.PathFilesDestiny = "";
        }


    }
}
