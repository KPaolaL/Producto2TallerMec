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

        public Boolean InsertarCliente(EntityLayerArch entidadClient, ref string mensajeSalida)
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
        
        //Devolver Clientes
        public List<EntityLayerArch> ObtenerClientes(ref string msj_salida)
        {
            SqlConnection conex = null;

            string query = "select * from Cliente";

            conex = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conex, ref msj_salida);

            List<EntityLayerArch> lista = new List<EntityLayerArch>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntityLayerArch
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

        //Insertar Autos.
        public Boolean InsertarAutos(EntityLayerArch nuevoAuto, ref string mensajeSalida)
        {
            SqlParameter[] param1 = new SqlParameter[6];
            param1[0] = new SqlParameter
            {
                ParameterName = "idAut",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.id_Auto

            };
            param1[1] = new SqlParameter
            {
                ParameterName = "marca",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.F_marca

            };
            param1[2] = new SqlParameter
            {
                ParameterName = "Modelo",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.modelo

            };
            param1[3] = new SqlParameter
            {
                ParameterName = "anio",
                SqlDbType = SqlDbType.VarChar,
                Size = 4,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.anio

            };
            param1[4] = new SqlParameter
            {
                ParameterName = "color",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.color

            };
            param1[5] = new SqlParameter
            {
                ParameterName = "placa",
                SqlDbType = SqlDbType.VarChar,
                Size = 16,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.placas

            };
            param1[6] = new SqlParameter
            {
                ParameterName = "dueno",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.dueño

            };

            string sentenciaSql = "insert into Auto values(@idAut,@marca,@Modelo,@anio,@color,@placa,@dueno);";
            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentenciaSql, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, param1);

            return salida;
        }
        //Devolver Autos.
        public List<EntityLayerArch> AutosID(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from Auto";

            conextemp = objectoDeAcceso.AbrirConexion(ref msj);

            SqlDataReader ObtenerDatos = null;
            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conextemp, ref msj);

            List<EntityLayerArch> listaSalida = new List<EntityLayerArch>();
            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    listaSalida.Add(new EntityLayerArch
                    {
                        id_Auto = (int)ObtenerDatos[0],
                        F_marca = (int)ObtenerDatos[1],
                        modelo = (string)ObtenerDatos[2],
                        anio = (string)ObtenerDatos[3],
                        color = (string)ObtenerDatos[4],
                        placas = (string)ObtenerDatos[5],
                        dueño = (int)ObtenerDatos[6]

                    }
                     );
                }

            }
            else
            {
                listaSalida = null;
            }
            conextemp.Close();
            conextemp.Dispose();

            return listaSalida;

        }



    }
}
   