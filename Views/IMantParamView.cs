using System;
using System.Windows.Forms;
namespace ProyectoViaje.Views
{
    public interface IMantParamView
    {

        event EventHandler Search;
        event EventHandler Mant;
        event EventHandler Edit;
        event EventHandler New;


        //Filtro
        string CodParamFiltro { get; set; }
        string CodIdenFiltro { get; set; }

        bool HabilitadoFiltro { get; set; }

        //Mantenimiento
        string CodParamMant { get; set; }
        string CodIdenMant { get; set; }
        string Valor1Mant { get; set; }
        string Valor2Mant { get; set; }
        bool HabilitadoMant { get; set; }

        //Etiquetas
        string tituloEtiqueta { get; set; }
        //Botones
        string tituloBoton { get; set; }

        //flag
        char FlagMant { get; set; }

        void SetBindingSourceDgvParametros(BindingSource src);

        void Show();
    }
}
