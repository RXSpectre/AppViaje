using System;

namespace ProyectoViaje.Views
{
    public interface ICartaPorteView
    {
        //Events
        event EventHandler ChooseFilesEntries;
        event EventHandler ProccesFiles;
        event EventHandler ChooseFilesDestinies;

        //Properties - Fields
        string QuantitySelectedFiles { get; set; }
        string PathFilesDestiny { get; set; }

        //Methods
        void Show();

    }
}
