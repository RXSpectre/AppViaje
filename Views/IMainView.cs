using System;

namespace ProyectoViaje.Views
{
    public interface IMainView
    {
        //Eventos
        event EventHandler ShowCartaPorte;
        event EventHandler ShowListaSeparacion;
        event EventHandler ShowCartaPorteVsListaSeparacion;
        event EventHandler ShowMantParam;
        event EventHandler ExitApp;


        //Methods
        void Close();
    }
}
