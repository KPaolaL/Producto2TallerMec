using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntityLayer;
using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class BusinessLogicCliente
    {
        private ClassDataAccess objectoDeAcceso =
           new ClassDataAccess(@"Data Source=LAPTOP-SFMTQ4SG\SQLEXPRESS; Initial Catalog=MiTaller; Integrated Security = true;");

        public Boolean InsertarCliente(EntityLayerCliente entidadClient, ref string mensajeSalida)
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

        public List<EntityLayerCliente> ObtenerClientes(ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "SELECT * FROM CLIENTE";



            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntityLayerCliente> lista = new List<EntityLayerCliente>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntityLayerCliente
                    {
                        id_cliente = (int)ObtenerDatos[0],
                        nombre = (string)ObtenerDatos[1]

                    });
                }
            }
            else
            {
                lista = null;
            }
            conexion.Close();
            conexion.Dispose();

            return lista;

        }


    }
}
   