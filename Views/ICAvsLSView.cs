using System;
using System.Windows.Forms;

namespace ProyectoViaje.Views
{
    public interface ICAvsLSView
    {
        //Properties -  Fields
        string PaginaActual { get; set; }
        string TotalPagina { get; set; }
        string TotalRegistros { get; set; }

        string FechaDespachoFiltroInicio { get; set; }
        string FechaDespachoFiltroFinal { get; set; }
        string Tamanio { get; set; }
     
        object ComboPlaca { get; }

        //Events
        event EventHandler GoBack;
        event EventHandler GoNext;
        event EventHandler Search;
        event EventHandler GetDetail;
        event EventHandler ChangeTamanioValue;


        //Methods
        void SetBindingSourceDtgvCAvsLS(BindingSource src);
        void SetBindingSourceCombo(BindingSource src);
        void Show();

    }
}
