using System;
using System.Windows.Forms;

namespace ProyectoViaje.Views
{
    public interface IListaSeparacionView
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

        string FechaDespachoFiltro { get; set; }
        string PlacaFiltro { get; set; }

        bool PanelState { get; set; }

        //Paginacion
        string PaginaActual { get; set; }
        string TotalPagina { get; set; }
        string TotalRegistros { get; set; }

        //Filtros pestaña Lista
        string FechaDespachoFiltroInicio { get; set; }
        string FechaDespachoFiltroFinal { get; set; }

        string Tamanio { get; set; }

        bool HabilitarFiltro { get; set; }

        short FlagMant { get; set; }


        object ComboPlaca { get; }

        event EventHandler GoBack;
        event EventHandler GoNext;
        event EventHandler Search;


        //Values from Combo
        object ComboPlacaData { get; }
        string CodTipoViaje { get; }
        string CodTipoAlmacen { get; }
        object ComboTransportista { get;  }


        //Events
        event EventHandler RegisterLS;
        event EventHandler ChangeCheck;
        event EventHandler SelectedRow;
        event EventHandler SelectedComboPlaca;
        event EventHandler DtpChangeValue;
        event EventHandler SearchFilter;
        event EventHandler ChangeTabPage;
        event EventHandler GetDetail;
        event EventHandler ExportExcelLS;
        event EventHandler ChangeTamanioValue;


        //Methods
        void SetBindingSourceFiltro(BindingSource src);
        void SetBindingSourcePlaca(BindingSource src);
        void SetBindingSourceTipoViaje(BindingSource src);
        void SetBindingSourceAlmacen(BindingSource src);


        void SetBindingSourcePlacaFiltroLS(BindingSource src);
        void SetBindingSourceListaLS(BindingSource src);

        void SetBindingSourceNomTransportistas(BindingSource src);

        void Show();

        void BringToFront();

    }
}
