
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoViaje.Models
{
    public class ListaSeparacionModel
    {

        private int _nroViaje;
        private string _nroViajeCal;
     

        private byte _nomTransportista;

        private byte _codPlaca;
        private decimal _totalCubicaje;
        private byte _codTipoViaje;
        private byte _codTipoAlmacen;
        private string _fechaDespacho;
        private string _observaciones;
        private string _detalle;

        private bool _tieneAnexo;
        private int _nroViajeAnexo;
        private string _nroViajeCalAnexo;


        [Range(1,int.MaxValue,ErrorMessage ="El campo {0} debe ser númerico")]
        public int NroViaje
        { 
            get { return _nroViaje; } 
            set { _nroViaje = value; }
        }

        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NroViajeCal
        {   
            get { return _nroViajeCal; } 
            set { _nroViajeCal = value; }
        }


        [Required(ErrorMessage = "El campo nombre de transportista es requerido")]
        public byte NomTransportista 
        { 
            get { return _nomTransportista; }
            set { _nomTransportista = value; }
        }

        
        public byte CodPlaca 
        { 
            get { return _codPlaca; }
            set { _codPlaca = value; }
        }

        [RegularExpression(@"(?!^0*$)(?!^0*\.0*$)^\d{1,5}(\.\d{1,4})?$",
            ErrorMessage = "El campo metraje debe ser un valor decimal")]
        public decimal TotalCubicaje 
        { 
            get { return _totalCubicaje; }
            set { _totalCubicaje = value; }
        }

       
        public byte CodTipoViaje 
        { 
            get { return _codTipoViaje; }
            set { _codTipoViaje = value; }
        }

        public string FechaDespacho
        { 
            get { return _fechaDespacho; }
            set { _fechaDespacho = value; }
        }

        public byte CodTipoAlmacen
        {
            get { return _codTipoAlmacen; }
            set { _codTipoAlmacen = value; }
        }

    
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

     
        public string Detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }


        public bool TieneAnexo
        {
            get { return _tieneAnexo; }
            set { _tieneAnexo = value; }
        }

        public int NroViajeAnexo
        {
            get { return _nroViajeAnexo; }
            set { _nroViajeAnexo = value; }
        }

        public string NroViajeCalAnexo
        {
            get { return _nroViajeCalAnexo; }
            set { _nroViajeCalAnexo = value; }
        }

    }
}
