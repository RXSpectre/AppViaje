using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoViaje.DTO
{
    public class BusquedaLSReqDTO
    {
        public BusquedaLSReqDTO()
        {
            FechaDespacho = "";
            CodPlaca = 0;
            NroViaje = 0;
            NroViajeCal = "";
            FlagMant = 1;
        }

        public string FechaDespacho { get; set; }
        public byte CodPlaca { get; set; }
        public int NroViaje { get; set; }
        public string NroViajeCal { get; set; }
        public short FlagMant { get; set; }

    }
}
