
using System.ComponentModel;

namespace ProyectoViaje.DTO
{
    public class BusquedaLSDTO
    {
        private int _nroViaje;
        private string _fechaDespacho;
      
        private string _placaDsc;
        private string _nroViajeCal;

        [DisplayName("Fecha Despacho")]
        public string FechaDespacho
        {
            get { return _fechaDespacho; }
            set { _fechaDespacho = value; }
        }
      
        [DisplayName("Placa")]
        public string PlacaDsc
        {
            get { return _placaDsc; }
            set { _placaDsc = value; }
        }

        [DisplayName("Nro Viaje")]
        public int NroViaje
        {
            get { return _nroViaje; }
            set { _nroViaje = value; }
        }

        [DisplayName("Nro Viaje Cal")]
        public string NroViajeCal
        { 
            get { return _nroViajeCal; } 
            set { _nroViajeCal = value; }
        }

    }
}
