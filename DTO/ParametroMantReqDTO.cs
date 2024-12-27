using System.ComponentModel.DataAnnotations;

namespace ProyectoViaje.DTO
{
    public class ParametroMantReqDTO
    {
        private string _codPrm;
        private string _valor1;
        private string _valor2;
        private string _codIden;
        private string _habilitado;
        private char _flagMant;

       [Required(ErrorMessage ="El código del parametro es obligatorio")]
        public string CodPrm
        {
            get { return _codPrm; }
            set { _codPrm = value; }
        }

        [Required(ErrorMessage = "El código del identificador es obligatorio")]
        public string CodIden
        {
            get { return _codIden; }
            set { _codIden = value; }
        }

        [Required(ErrorMessage = "El valor 1 es obligatorio")]
        public string Valor1
        {
            get { return _valor1; }
            set { _valor1 = value; }
        }

       
        public string Valor2
        {
            get { return _valor2; }
            set { _valor2 = value; }
        }


        public string Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }

        public char FlagMant
        {
            get { return _flagMant; }
            set { _flagMant = value; }
        }


    }
}
