using ProyectoViaje.DTO;
using ProyectoViaje.Models;
using System.Collections.Generic;

namespace ProyectoViaje.Repositories.Interfaces
{
    public interface IViajesRepo
    {
        ResponseModel InsertarCA(CartaPorteModel req);
       

        ResponseModel MantLS(ListaSeparacionReqDTO req);


        List<ListarCAvsLSCabDTO> ListarCAvsLS(ListarLSRequestDTO req,
                                           int actualPag,
                                           int tamanio,
                                           out int totalPaginas,
                                           out int totalFilas);


        ListarCAvsLSDetDTO ListarCAvsLSDet(ListarCAvsLSReqDTO req);


        List<ParametroModel> ObtenerParametros(ParametroModel req);

        List<BusquedaLSDTO> BusquedaLS(BusquedaLSReqDTO req);
        List<ListarLSDTO> ListarLS(ListarLSRequestDTO req,
                                           int actualPag,
                                           int tamanio,
                                           out int totalPaginas,
                                           out int totalFilas);

        ResponseModel ParametroMant(ParametroMantReqDTO req);

    }
}
