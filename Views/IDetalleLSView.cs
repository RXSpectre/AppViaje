using System;
using System.Windows.Forms;

namespace ProyectoViaje.Views
{
    public interface IDetalleLSView
    {
        //Page (Registro de Lista Separación)
        //Properties -  Fields
        string NroViaje { get; set; }
        string NroViajeCal { get; set; }
        string TotalCubicaje { get; set; }
        string FechaDespacho { get; set; }
        string Observaciones { get; set; }
        string Detalle { get; set; }

        bool TieneAnexo { get; set; }
        string NroViajeAnexo { get; set; }
        string NroViajeCalAnexo { get; set; }

        bool PanelState { get; set; }

        //Combos
        object ComboPlaca { get; set; }
        object ComboTransportista { get; set; }
        object ComboTipoViaje { get; set; }
        object ComboTipoAlmacen { get; set; }

        string FechaDespachoFiltro { get; set; }
        string PlacaFiltro { get; set; }

        short FlagMant { get; set; }

        event EventHandler EditLS;
        event EventHandler DisableLS;
        event EventHandler SearchFilterLS;
        event EventHandler SelectedComboPlaca;
        event EventHandler ChangeCheck;
        event EventHandler SelectedRow;

        //BindingSources for Combos
        void SetBSCmbPlaca(BindingSource src);
        void SetBSCmbTransportista(BindingSource src);
        void SetBSCmbTipoViaje(BindingSource src);
        void SetBSCmbTipoAlmacen(BindingSource src);

        void SetBindingSourceFiltro(BindingSource src);

        void Show();
        void Close();

       
    }
}
