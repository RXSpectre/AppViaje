using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ProyectoViaje.Models
{
    public class ParametroModel
    {
        private string _codPrm;
        private string _valor1;
        private string _valor2;
        private string _codIden;
        private string _habilitado;
        private byte _flagFrm;

        [DisplayName("Código Parámetro")]
        public string CodPrm 
        { 
            get { return _codPrm; }
            set { _codPrm = value; }
        }

        [DisplayName("Código Identificador")]
        public string CodIden
        {
            get { return _codIden; }
            set { _codIden = value; }
        }

        [DisplayName("Valor 1")]
        public string Valor1
        {
            get { return _valor1; }
            set { _valor1 = value; }
        }

        [DisplayName("Valor 2")]
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

        [Browsable(false)]
        public byte FlagFrm
        {
            get { return _flagFrm; }
            set { _flagFrm = value; }
        }


    }
}
