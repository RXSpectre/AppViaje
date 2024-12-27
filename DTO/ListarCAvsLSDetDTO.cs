
namespace ProyectoViaje.DTO
{
    public class ListarCAvsLSDetDTO
	{
		//Datos Carta Porte
		public int NroViajeCA { get; set; }
		public string NroViajeCalCA { get; set; }
		public string NivelServicioCA { get; set; }
		public string FechaCA { get; set; }
		public decimal TotalFleteCA { get; set; }
		public string ObsCA { get; set; }
		public string LugarCA { get; set; }
		public decimal TotalVolEntregaCA { get; set; }
		public string ArchivoOrigenCA { get; set; }

		//Lista Separación
		public int NroViajeLS { get; set; }
		public string NroViajeCalLS { get; set; }
		public string TransportistaLS { get; set; }
		public string FechaDespachoLS { get; set; }
		public string PlacaLS { get; set; }
		public string TipoViajeLS { get; set; }

		public string AlmacenLS { get; set; }
		public string ObsLS { get; set; }
		public string DetalleLS { get; set; }
		public decimal TotalCubiajeLS { get; set; }
		public decimal MontoLS { get; set; }

		public int NroViajeAnexoLS { get; set; }
		public string NroViajeCalAnexoLS { get; set; }

		public string Verificacion { get; set; }
		
		

	}
}
