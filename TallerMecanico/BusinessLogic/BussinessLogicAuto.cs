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
    class BussinessLogicAuto
    {
        private ClassDataAccess objectoDeAcceso =
           new ClassDataAccess(@"Data Source=LAPTOP-SFMTQ4SG\SQLEXPRESS; Initial Catalog=MiTaller; Integrated Security = true;");

        //Insertar Autos.
        public Boolean InsertarAutos(EntityLayerAuto nuevoAuto, ref string mensajeSalida)
        {
            SqlParameter[] param1 = new SqlParameter[6];
            param1[0] = new SqlParameter
            {
                ParameterName = "marca",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.F_Marca

            };
            param1[1] = new SqlParameter
            {
                ParameterName = "Modelo",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.Modelo

            };
            param1[2] = new SqlParameter
            {
                ParameterName = "anio",
                SqlDbType = SqlDbType.VarChar,
                Size = 4,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.anio

            };
            param1[3] = new SqlParameter
            {
                ParameterName = "color",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.color

            };
            param1[4] = new SqlParameter
            {
                ParameterName = "placa",
                SqlDbType = SqlDbType.VarChar,
                Size = 16,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.placas

            };
            param1[5] = new SqlParameter
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

        //Actualizar auto Autos.
        public Boolean ActualizarAutos(EntityLayerAuto nuevoAuto, ref string mensajeSalida)
        {
            SqlParameter[] param1 = new SqlParameter[6];
            param1[0] = new SqlParameter
            {
                ParameterName = "idAut",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.Id_Auto

            };
            param1[1] = new SqlParameter
            {
                ParameterName = "marca",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.F_Marca

            };
            param1[2] = new SqlParameter
            {
                ParameterName = "Modelo",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.Modelo

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

            string sentenciaSql = "update Auto set F_Marca=@marca, Modelo=@Modelo, año=@anio, color=@color, placas=@placa, dueño=@dueno where Id_Auto = @idAut;";

            Boolean salida = false;
            salida = objectoDeAcceso.OperacionesSQLConParametros(sentenciaSql, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, param1);

            return salida;
        }

        //Devolver Autos.
        public List<EntityLayerAuto> AutosID(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from Auto";

            conextemp = objectoDeAcceso.AbrirConexion(ref msj);

            SqlDataReader ObtenerDatos = null;
            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conextemp, ref msj);

            List<EntityLayerAuto> listaSalida = new List<EntityLayerAuto>();
            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    listaSalida.Add(new EntityLayerAuto
                    {
                        Id_Auto = (int)ObtenerDatos[0],
                        F_Marca = (int)ObtenerDatos[1],
                        Modelo = (string)ObtenerDatos[2],
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

        //Borrar auto

        public Boolean deleteAuto(string id, ref string result)
        {
            string sentencia = "delete from Auto where Id_Auto = " + id + ";";  
            Boolean salida = false;
            salida = objectoDeAcceso.ModificaBDinsegura(sentencia, objectoDeAcceso.AbrirConexion(ref result), ref result);
            return salida;
        }

        public EntityLayerAuto getAuto(string id, ref string msg)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from  Auto where Id_Auto = " + id;
            cnTemp = objectoDeAcceso.AbrirConexion(ref msg);
            SqlDataReader obtenDatos = null;
            EntityLayerAuto atra = new EntityLayerAuto();

            obtenDatos = objectoDeAcceso.ConsultarReader(query1, cnTemp, ref msg);

            if (obtenDatos != null)
            {
                while (obtenDatos.Read())
                {
                    atra.F_Marca = (int)obtenDatos[1];
                    atra.Modelo = (string)obtenDatos[2];
                    atra.anio = (string)obtenDatos[3];
                    atra.color = (string)obtenDatos[4];
                    atra.placas = (string)obtenDatos[5];
                    atra.dueño = (int)obtenDatos[6];
                }
            }
            else
            {
                atra = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return atra;

        }


    }
}