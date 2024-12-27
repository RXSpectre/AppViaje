using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProyectoViaje.Repositories.Interfaces;
using ProyectoViaje.Models;
using ProyectoViaje.DTO;

namespace ProyectoViaje.Repositories
{
    public class ViajesRepo:BaseRepo,IViajesRepo
    {
        public ViajesRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<BusquedaLSDTO> BusquedaLS(BusquedaLSReqDTO req)
        {
            List<BusquedaLSDTO> result = new List<BusquedaLSDTO>();

            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_BusquedaLS", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaDespacho", SqlDbType.VarChar, 8).Value = req.FechaDespacho;
                cmd.Parameters.Add("@CodPlaca", SqlDbType.TinyInt).Value = req.CodPlaca;
                cmd.Parameters.Add("@NroViaje", SqlDbType.Int).Value = req.NroViaje;
                cmd.Parameters.Add("@NroViajeCal", SqlDbType.VarChar,15).Value = req.NroViajeCal;
                cmd.Parameters.Add("@FlagMant", SqlDbType.SmallInt).Value = req.FlagMant;

                sqlCon.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int i = 0;
                        var item = new BusquedaLSDTO();
                        item.FechaDespacho = rd.GetString(i++);
                        item.PlacaDsc = rd.GetString(i++);
                        item.NroViaje = rd.GetInt32(i++);
                        item.NroViajeCal = rd.GetString(i++);
                        result.Add(item);
                    }
                }
                return result;
            }
        }

        public ResponseModel InsertarCA(CartaPorteModel req)
        {
            //Encapsulamos nuestra conexion 
            ResponseModel response = new ResponseModel();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //Creamos y configuramos nuestro comando a ejecutar
                SqlCommand cmd = new SqlCommand("Usp_InsertarCartaPorte", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NroCartaPorte", SqlDbType.Int).Value = req.CartaDePorte;
                cmd.Parameters.Add("@NroViajeCal", SqlDbType.VarChar, 15).Value = req.NroViajeCal;
                cmd.Parameters.Add("@NroOrdenCompra", SqlDbType.Int).Value = req.OrdenDeCompra;
                cmd.Parameters.Add("@NivelServicio", SqlDbType.VarChar, 15).Value = req.NivelServicio;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 8).Value = req.Fecha;
                cmd.Parameters.Add("@Lugar", SqlDbType.VarChar, 20).Value = req.Lugar;
                cmd.Parameters.Add("@TotalFlete", SqlDbType.Decimal).Value = req.TotalFleteExc;
                cmd.Parameters.Add("@TotalVolEntrega", SqlDbType.Decimal).Value = req.TotalVolumne;
                cmd.Parameters.Add("@Obs", SqlDbType.VarChar, 500).Value = req.Obs;
                cmd.Parameters.Add("@ArchivoOrigen", SqlDbType.VarChar, 500).Value = req.ArchivoOrigen;
                //Abrimos la conexion y retribuimos los datos del comando

                try
                {
                    sqlCon.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        int i = 0;
                        response.CodResult = rd.GetInt32(i++);
                        response.Msg = rd.GetString(i++);
                    }
                }
                catch (Exception ex)
                {
                    response.CodResult = 500;
                    response.Msg = ex.Message;
                }
            }

            return response;
        }


        public List<ListarCAvsLSCabDTO> ListarCAvsLS(ListarLSRequestDTO req,
                                                  int actualPag,
                                                  int tamanio,
                                                  out int totalPaginas,
                                                  out int totalFilas)
        {
            //Encapsulamos nuestra conexion 
            List<ListarCAvsLSCabDTO> response = new List<ListarCAvsLSCabDTO>();

            totalPaginas = 0;
            totalFilas = 0;

            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                //Creamos y configuramos nuestro comando a ejecutar
                SqlCommand cmd = new SqlCommand("Usp_ListarCAvsLS", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaDespachoInicio", SqlDbType.VarChar,8).Value = Convert.ToDateTime(req.FechaDespachoInicio).ToString("yyyyMMdd");
                cmd.Parameters.Add("@FechaDespachoFinal", SqlDbType.VarChar, 8).Value = Convert.ToDateTime(req.FechaDespachoFinal).ToString("yyyyMMdd");
                cmd.Parameters.Add("@CodPlaca", SqlDbType.TinyInt).Value = req.CodPlaca;

                cmd.Parameters.Add("@ActualPagina", SqlDbType.Int).Value = actualPag;
                cmd.Parameters.Add("@Tamanio", SqlDbType.Int).Value = tamanio;

                SqlParameter sqlprmTotalPagina = new SqlParameter();
                sqlprmTotalPagina.ParameterName = "@totalPaginas";
                sqlprmTotalPagina.SqlDbType = SqlDbType.Int;
                sqlprmTotalPagina.Direction = ParameterDirection.Output;
                sqlprmTotalPagina.Value = totalPaginas;

                cmd.Parameters.Add(sqlprmTotalPagina);

                SqlParameter sqlprmTotalFilas = new SqlParameter();
                sqlprmTotalFilas.ParameterName = "@CantFilas";
                sqlprmTotalFilas.SqlDbType = SqlDbType.Int;
                sqlprmTotalFilas.Direction = ParameterDirection.Output;
                sqlprmTotalFilas.Value = totalFilas;

                cmd.Parameters.Add(sqlprmTotalFilas);
                //Abrimos la conexion y retribuimos los datos del comando

                
                sqlCon.Open();
                using (SqlDataReader rd = cmd.ExecuteReader()) 
                {
                    int i = 0;

                    while (rd.Read())
                    {
                        i = 0;
                        ListarCAvsLSCabDTO item = new ListarCAvsLSCabDTO();

                        item.NroCartaPorte = rd.GetInt32(i++);
                        item.NroViajeCal = rd.GetString(i++);
                        item.Fecha = rd.GetString(i++);
                        item.TotalFlete = rd.GetDecimal(i++);
                        item.Placa = rd.GetString(i++);
                        item.Verificacion = rd.GetString(i++);

                        response.Add(item);
                    }

                }
                totalPaginas = Convert.ToInt32(sqlprmTotalPagina.Value);
                totalFilas = Convert.ToInt32(sqlprmTotalFilas.Value);
            }

            return response;
        }

        public ListarCAvsLSDetDTO ListarCAvsLSDet(ListarCAvsLSReqDTO req)
        {
            //Encapsulamos nuestra conexion 
            ListarCAvsLSDetDTO response = new ListarCAvsLSDetDTO();
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                //Creamos y configuramos nuestro comando a ejecutar
                SqlCommand cmd = new SqlCommand("Usp_ListarCAvsLSDet", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NroCartaPorteCA", SqlDbType.Int).Value = req.NroCartaPorteCA;
                cmd.Parameters.Add("@NroViajeCalCA", SqlDbType.VarChar, 15).Value = req.NroViajeCalCA;

                //Abrimos la conexion y retribuimos los datos del comando
                sqlCon.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    int i = 0;

                    while (rd.Read())
                    {
                        i = 0;

                        response.NroViajeCA = rd.GetInt32(i++);
                        response.NroViajeCalCA = rd.GetString(i++);
                        response.NivelServicioCA = rd.GetString(i++);
                        response.FechaCA = rd.GetString(i++);
                        response.TotalFleteCA = rd.GetDecimal(i++);
                        response.TotalVolEntregaCA = rd.GetDecimal(i++);
                        response.ObsCA = rd.GetString(i++);
                        response.ArchivoOrigenCA = rd.GetString(i++);
                        response.LugarCA = rd.GetString(i++);
                        response.NroViajeLS = rd.GetInt32(i++);
                        response.NroViajeCalLS = rd.GetString(i++);
                        response.PlacaLS = rd.GetString(i++);
                        response.TipoViajeLS = rd.GetString(i++);
                        response.TotalCubiajeLS = rd.GetDecimal(i++);
                        response.MontoLS = rd.GetDecimal(i++);
                        response.FechaDespachoLS = rd.GetString(i++);
                        response.NroViajeAnexoLS = rd.GetInt32(i++);
                        response.NroViajeCalAnexoLS = rd.GetString(i++);
                        response.AlmacenLS = rd.GetString(i++);
                        response.ObsLS = rd.GetString(i++);
                        response.DetalleLS = rd.GetString(i++);
                        response.TransportistaLS = rd.GetString(i++);
                        response.Verificacion = rd.GetString(i++);
                    }

                }
            }

            return response;
        }

        public List<ListarLSDTO> ListarLS(ListarLSRequestDTO req, int actualPag, int tamanio, out int totalPaginas, out int totalFilas)
        {
            //Encapsulamos nuestra conexion 
            List<ListarLSDTO> response = new List<ListarLSDTO>();

            totalPaginas = 0;
            totalFilas = 0;

            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                //Creamos y configuramos nuestro comando a ejecutar
                SqlCommand cmd = new SqlCommand("Usp_ListarLS", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaDespachoInicio", SqlDbType.VarChar, 8).Value = Convert.ToDateTime(req.FechaDespachoInicio).ToString("yyyyMMdd");
                cmd.Parameters.Add("@FechaDespachoFinal", SqlDbType.VarChar, 8).Value = Convert.ToDateTime(req.FechaDespachoFinal).ToString("yyyyMMdd");
                cmd.Parameters.Add("@CodPlaca", SqlDbType.TinyInt).Value = req.CodPlaca;
                cmd.Parameters.Add("@Habilitado", SqlDbType.Bit).Value = req.Habilitado;

                cmd.Parameters.Add("@ActualPagina", SqlDbType.Int).Value = actualPag;
                cmd.Parameters.Add("@Tamanio", SqlDbType.Int).Value = tamanio;

                SqlParameter sqlprmTotalPagina = new SqlParameter();
                sqlprmTotalPagina.ParameterName = "@totalPaginas";
                sqlprmTotalPagina.SqlDbType = SqlDbType.Int;
                sqlprmTotalPagina.Direction = ParameterDirection.Output;
                sqlprmTotalPagina.Value = totalPaginas;

                cmd.Parameters.Add(sqlprmTotalPagina);

                SqlParameter sqlprmTotalFilas = new SqlParameter();
                sqlprmTotalFilas.ParameterName = "@CantFilas";
                sqlprmTotalFilas.SqlDbType = SqlDbType.Int;
                sqlprmTotalFilas.Direction = ParameterDirection.Output;
                sqlprmTotalFilas.Value = totalFilas;

                cmd.Parameters.Add(sqlprmTotalFilas);
                //Abrimos la conexion y retribuimos los datos del comando


                sqlCon.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    int i = 0;

                    while (rd.Read())
                    {
                        i = 0;
                        
                        ListarLSDTO item = new ListarLSDTO();
                        item.NroViaje = rd.GetInt32(i++);
                        item.NroViajeCal = rd.GetString(i++);
                        item.CodTransportista = rd.GetByte(i++);
                        item.NomTransportista = rd.GetString(i++);
                        item.CodPlacas = rd.GetByte(i++);
                        item.DscPlacas = rd.GetString(i++);
                       
                        item.CodTipoAlmacen = rd.GetByte(i++);
                        item.DscTipoAlmacen = rd.GetString(i++);

                        item.CodTipoViaje = rd.GetByte(i++);
                        item.DscTipoViaje = rd.GetString(i++);

                        item.TotalCubicaje = rd.GetDecimal(i++);
                        item.FechaDespacho = rd.GetString(i++);
                        item.Monto = rd.GetDecimal(i++);
                        item.ObsLs = rd.GetString(i++);
                        item.Detalle = rd.GetString(i++);
                        item.TieneAnexo = rd.GetString(i++);
                        item.NroViajeAnexo = rd.GetInt32(i++);
                        item.NroViajeCalAnexo = rd.GetString(i++);
                        item.Habilitado = rd.GetBoolean(i++);
                        item.FechaCreacion = rd.GetString(i++);
                        item.FechaModificacion = rd.GetString(i++);

                        response.Add(item);
                    }

                }
                totalPaginas = Convert.ToInt32(sqlprmTotalPagina.Value);
                totalFilas = Convert.ToInt32(sqlprmTotalFilas.Value);
            }

            return response;
        }

        public ResponseModel MantLS(ListaSeparacionReqDTO req)
        {
            //Encapsulamos nuestra conexion 
            ResponseModel response = new ResponseModel();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //Creamos y configuramos nuestro comando a ejecutar
                SqlCommand cmd = new SqlCommand("Usp_MantListaSeparacion", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NroViaje", SqlDbType.Int).Value = req.NroViaje;
                cmd.Parameters.Add("@NroViajeCal", SqlDbType.VarChar, 15).Value = req.NroViajeCal;
                cmd.Parameters.Add("@NomTransportista", SqlDbType.TinyInt).Value = req.CodTransportista;
                cmd.Parameters.Add("@CodPlaca", SqlDbType.TinyInt).Value = req.CodPlaca;
                cmd.Parameters.Add("@TotalCubicaje", SqlDbType.Decimal).Value = req.TotalCubicaje;
                cmd.Parameters.Add("@CodTipoViaje", SqlDbType.TinyInt).Value = req.CodTipoViaje;
                cmd.Parameters.Add("@FechaDespacho", SqlDbType.VarChar, 8).Value = req.FechaDespacho;

                cmd.Parameters.Add("@CodTipoAlmacen", SqlDbType.TinyInt).Value = req.CodTipoAlmacen;
                cmd.Parameters.Add("@ObsLs", SqlDbType.VarChar, 500).Value = req.Observaciones;
                cmd.Parameters.Add("@Detalle", SqlDbType.VarChar, 500).Value = req.Detalle;

                cmd.Parameters.Add("@TieneAnexo", SqlDbType.Bit).Value = req.TieneAnexo;
                cmd.Parameters.Add("@NroViajeAnexo", SqlDbType.Int).Value = req.NroViajeAnexo;
                cmd.Parameters.Add("@NroViajeCalAnexo", SqlDbType.VarChar, 15).Value = req.NroViajeCalAnexo;
                cmd.Parameters.Add("@FlagMant", SqlDbType.SmallInt).Value = req.FlagMant;

                //Abrimos la conexion y retribuimos los datos del comando
                try
                {
                    sqlCon.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            int i = 0;
                            response.CodResult = rd.GetInt32(i++);
                            response.Msg = rd.GetString(i++);
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.CodResult = 500;
                    response.Msg = ex.Message;
                }
            }

            return response;
        }

        public List<ParametroModel> ObtenerParametros(ParametroModel req)
        {
            List<ParametroModel> result = new List<ParametroModel>();

            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ListarParametros", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodPrm", SqlDbType.VarChar, 10).Value = req.CodPrm == null ? "" : req.CodPrm;
                cmd.Parameters.Add("@CodIden", SqlDbType.VarChar, 10).Value = req.CodIden == null ? "" : req.CodIden;
                cmd.Parameters.Add("@habilitado", SqlDbType.VarChar, 1).Value = req.Habilitado == null ? "" : req.Habilitado;
                cmd.Parameters.Add("@FlagFrm", SqlDbType.TinyInt).Value = req.FlagFrm;

                sqlCon.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int i = 0;
                        var prmBe = new ParametroModel();
                        prmBe.CodPrm = rd.GetString(i++);
                        prmBe.CodIden = rd.GetString(i++);
                        prmBe.Valor1 = rd.GetString(i++);
                        prmBe.Valor2 = rd.GetString(i++);
                        prmBe.Habilitado = rd.GetString(i++);
                        result.Add(prmBe);
                    }
                }
                return result;
            }

        }

        public ResponseModel ParametroMant(ParametroMantReqDTO req)
        {
            //Encapsulamos nuestra conexion 
            ResponseModel response = new ResponseModel();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //Creamos y configuramos nuestro comando a ejecutar
                SqlCommand cmd = new SqlCommand("Usp_MantParametro", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CodPrm", SqlDbType.VarChar,10).Value = req.CodPrm;
                cmd.Parameters.Add("@CodIden", SqlDbType.VarChar, 10).Value = req.CodIden;
                cmd.Parameters.Add("@Valor1", SqlDbType.VarChar,200).Value = req.Valor1;
                cmd.Parameters.Add("@Valor2", SqlDbType.VarChar, 200).Value = req.Valor2;
                cmd.Parameters.Add("@Habilitado", SqlDbType.VarChar, 1).Value = req.Habilitado;
                cmd.Parameters.Add("@FlagMant", SqlDbType.Char, 1).Value = req.FlagMant;
                //Abrimos la conexion y retribuimos los datos del comando

                try
                {
                    sqlCon.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        int i = 0;
                        response.CodResult = rd.GetInt32(i++);
                        response.Msg = rd.GetString(i++);
                    }
                }
                catch (Exception ex)
                {
                    response.CodResult = 500;
                    response.Msg = ex.Message;
                }
            }

            return response;
        }
    }
}
