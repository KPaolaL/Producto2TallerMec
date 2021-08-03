using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using EntityLayer;

namespace BusinessLogic
{
    public class BusinessLogicClient
    {
        private ClassDataAccess objectoDeAcceso =
           new ClassDataAccess(@"Data Source=LAPTOP-SFMTQ4SG\SQLEXPRESS; Initial Catalog=MiTaller; Integrated Security = true;");
        public Boolean InsertarCliente(EntityLayerClient entidadClient, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadClient.nombre
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadClient.apellidoPat
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadClient.apellidoMat

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = entidadClient.celular
            };

            parametros[4] = new SqlParameter
            {
                ParameterName = "TelOficina",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = entidadClient.TelOficina
            };

            parametros[5] = new SqlParameter
            {
                ParameterName = "correoPer",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = entidadClient.correoP
            };

            parametros[6] = new SqlParameter
            {
                ParameterName = "correoCorp",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = entidadClient.correoCorp
            };



            string sentencia = "insert into Cliente values(@Nombre, @App, @ApM, @Celular, @TelOficina, @correoPer, @correoCorp) ";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;

        }

        public Boolean ActualizarCliente(EntityLayerClient entidadClient, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadClient.nombre
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadClient.apellidoPat
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadClient.apellidoMat

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = entidadClient.celular
            };

            parametros[4] = new SqlParameter
            {
                ParameterName = "TelOficina",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = entidadClient.TelOficina
            };

            parametros[5] = new SqlParameter
            {
                ParameterName = "correoPer",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = entidadClient.correoP
            };

            parametros[6] = new SqlParameter
            {
                ParameterName = "correoCorp",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = entidadClient.correoCorp
            };

            parametros[7] = new SqlParameter
            {
                ParameterName = "idclient",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadClient.id_cliente
            };

            string sentencia = "update Cliente set Nombre=@Nombre, App=@App, ApM=@ApM, Celular=@Celular, TelOficina=@TelOficina, correoPer=@correoPer, correoCorp=@correoCorp  where id_Cliente = @idclient; ";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }

        //Devolver Clientes
        public List<EntityLayerClient> ObtenerClientes(ref string msj_salida)
        {
            SqlConnection conex = null;

            string query = "select * from Cliente";

            conex = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conex, ref msj_salida);

            List<EntityLayerClient> lista = new List<EntityLayerClient>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntityLayerClient
                    {
                        id_cliente = (int)ObtenerDatos[0],
                        nombre = (string)ObtenerDatos[1],
                        apellidoMat = (string)ObtenerDatos[2],
                        apellidoPat = (string)ObtenerDatos[3],
                        celular = (string)ObtenerDatos[4],
                        TelOficina = (string)ObtenerDatos[5],
                        correoP = (string)ObtenerDatos[6],
                        correoCorp = (string)ObtenerDatos[7]

                    });
                }
            }
            else
            {
                lista = null;
            }
            conex.Close();
            conex.Dispose();

            return lista;

        }

        //Borrar cliente
        public Boolean BorrarCliente(string id, ref string result)
        {
            string sentencia = "delete from Cliente where id_cliente = " + id + ";";
            Boolean salida = false;

            salida = objectoDeAcceso.ModificaBDinsegura(sentencia, objectoDeAcceso.AbrirConexion(ref result), ref id);

            return salida;
        }
        public DataTable getClientsDataSet(ref string msg)
        {
            string cons1 = "Select * from Cliente";
            DataTable atra = null;
            DataSet contenedor = null;
            contenedor = objectoDeAcceso.ConsultaDS(cons1, objectoDeAcceso.AbrirConexion(ref msg), ref msg);
            if (contenedor != null)
            {
                atra = contenedor.Tables[0];
            }
            return atra;
        }

        public DataTable getAutosClient(string id, ref string msg)
        {
            string cons1 = "select Id_Auto, Marca, Modelo, año, color, placas from Auto INNER JOIN Marcas ON Auto.F_Marca = Marcas.id_Marca where dueño = " + id;
            DataTable atra = null;
            DataSet contenedor = null;
            contenedor = objectoDeAcceso.ConsultaDS(cons1, objectoDeAcceso.AbrirConexion(ref msg), ref msg);
            if (contenedor != null)
            {
                atra = contenedor.Tables[0];
            }
            return atra;

        }

    }
}
