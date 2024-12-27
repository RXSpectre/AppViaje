namespace ProyectoViaje.Models
{
    public class CartaPorteModel
    {
        public CartaPorteModel()
        {
            this.CodRuta = "";
            this.CartaDePorte = 0;
            this.OrdenDeCompra = 0;
            this.Lugar = "";
            this.Fecha = "";
            this.NroViajeCal = "";
            this.NivelServicio = "";
            this.TotalFleteExc = 0m;
            this.TotalVolumne = 0m;
            this.Obs = "";
            this.ObsFlag = false;
        }

        public string Obs { get; set; }
        public bool ObsFlag { get; set; }
        public string CodRuta { get; set; }
        public int CartaDePorte { get; set; }
        public int OrdenDeCompra { get; set; }
        public string Lugar { get; set; }
        public string Fecha { get; set; }
        public string NroViajeCal { get; set; }
        public string NivelServicio { get; set; }
        public decimal TotalFleteExc { get; set; }
        public decimal TotalVolumne { get; set; }
        public string ArchivoOrigen { get; set; }

    }
}
