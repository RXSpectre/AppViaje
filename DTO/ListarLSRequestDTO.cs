namespace ProyectoViaje.DTO
{
    public class ListarLSRequestDTO
    {
        

        public string FechaDespachoInicio { get; set; }
        public string FechaDespachoFinal { get; set; }
        public byte CodPlaca { get; set; }

        public bool Habilitado { get; set; }



    }
}
