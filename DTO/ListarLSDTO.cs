using System.ComponentModel;
namespace ProyectoViaje.DTO
{
    public class ListarLSDTO
    {
		[DisplayName("Nro Viaje")]
		public int NroViaje { get; set; }

		[DisplayName("Nro Viaje Cal")]
		public string NroViajeCal { get; set; }

		[Browsable(false)]
		public byte CodTransportista { get; set; }

		[DisplayName("Transportista")]
		public string NomTransportista { get; set; }

		[Browsable(false)]
		public byte CodPlacas { get; set; }

		[DisplayName("Placa")]
		public string DscPlacas { get; set; }

		[Browsable(false)]
		public byte CodTipoAlmacen { get; set; }

		[DisplayName("Tipo de Almacén")]
		public string DscTipoAlmacen { get; set; }

		[Browsable(false)]
		public byte CodTipoViaje { get; set; }

		[DisplayName("Tipo de Viaje")]
		public string DscTipoViaje { get; set; }

		[DisplayName("Total de Cubiaje")]
		public decimal TotalCubicaje { get; set; }

		[DisplayName("Fecha de Despacho")]
		public string FechaDespacho { get; set; }
		public decimal Monto { get; set; }

		[DisplayName("Observación")]
		public string ObsLs { get; set; }
		public string Detalle { get; set; }

		[DisplayName("¿Posse Anexo?")]
		public string TieneAnexo { get; set; }

		[DisplayName("Nro Viaje Anexo")]
		public int NroViajeAnexo { get; set; }

		[DisplayName("Nro Viaje Cal Anexo")]
		public string NroViajeCalAnexo { get; set; }

		[Browsable(false)]
		public bool Habilitado { get; set; }


		[Browsable(false)]
		public string FechaCreacion { get; set; }
		[Browsable(false)]
		public string FechaModificacion { get; set; }

	}
}
