using System.ComponentModel.DataAnnotations;
namespace ProyectoViaje.DTO
{
    public class ListaSeparacionReqDTO
    {
        private int _nroViaje;
        private string _nroViajeCal;
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
        private byte _codTransportista;
        private short _flagMant;

        public ListaSeparacionReqDTO()
        {
            _nroViaje = 0;
            _nroViajeCal = "";
            _codPlaca = 0;
            _totalCubicaje = 0;
            _codTipoViaje = 0;
            _codTipoAlmacen = 0;
            _fechaDespacho = "";
            _observaciones = "";
            _detalle = "";
            _tieneAnexo = false;
            _nroViajeAnexo = 0;
            _nroViajeCalAnexo = "";
            _codTransportista = 0;
            _flagMant = 0;
        }

        
        [Range(1, int.MaxValue, ErrorMessage = "El campo Nro Viaje debe ser númerico")]
        public int NroViaje
        {
            get { return _nroViaje; }
            set { _nroViaje = value; }
        }

        [Required(ErrorMessage = "El campo Nro Viaje Cal es requerido")]
        public string NroViajeCal
        {
            get { return _nroViajeCal; }
            set { _nroViajeCal = value; }
        }


        public byte CodTransportista
        {
            get { return _codTransportista; }
            set { _codTransportista = value; }
        }


        public byte CodPlaca
        {
            get { return _codPlaca; }
            set { _codPlaca = value; }
        }

        [Required(ErrorMessage = "El campo Total cubiaje es requerido")]
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

        public short FlagMant
        {
            get { return _flagMant; }
            set { _flagMant = value; }
        }
    }
}
