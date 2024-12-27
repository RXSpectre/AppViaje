using System.ComponentModel;

namespace ProyectoViaje.DTO
{
    public class ListarCAvsLSCabDTO
    {
        public int NroCartaPorte { get; set; }
        public string NroViajeCal { get; set; }
        public string Fecha { get; set; }

        [DisplayName("Total Flete")]
        public decimal TotalFlete { get; set; }
        public string Placa { get; set; }
        public string Verificacion { get; set; }
    }
}
