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
    class BussinessLogicMecanico
    {
        private ClassDataAccess objectoDeAcceso =
          new ClassDataAccess(@"Data Source=LAPTOP-SFMTQ4SG\SQLEXPRESS; Initial Catalog=MiTaller; Integrated Security = true;");
        public Boolean InsertarMecanico(EntityLayerMecanico entidadMecanico, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.Nombre
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.apePat
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.apeMat

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.Celular
            };


            parametros[4] = new SqlParameter
            {
                ParameterName = "correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.correo
            };



            string sentencia = "insert into Mecanico values(@Nombre, @App, @Apm, @Celular, @correo) ";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }

        //Editar Mecanico
        public Boolean ActualizarMecanico(EntityLayerMecanico entidadMecanico, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.Nombre
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.apePat
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.apeMat

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.Celular
            };


            parametros[4] = new SqlParameter
            {
                ParameterName = "correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.correo
            };

            parametros[5] = new SqlParameter
            {
                ParameterName = "id_tecnico",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.id_Tecnico
            };

            string sentencia = "update Mecanico set Nombre=@Nombre, App=@App, Apm=@Apm, Celular=@Celular, correo=@correo where id_Tecnico = @id_tecnico; ";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }

        //Devolver Mecanicos.
        public List<EntityLayerMecanico> MecanicoID(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from Mecanico";

            conextemp = objectoDeAcceso.AbrirConexion(ref msj);

            SqlDataReader ObtenerDatos = null;
            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conextemp, ref msj);

            List<EntityLayerMecanico> listaSalida = new List<EntityLayerMecanico>();
            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    listaSalida.Add(new EntityLayerMecanico
                    {
                        id_Tecnico = (int)ObtenerDatos[0],
                        Nombre = (string)ObtenerDatos[1],
                        apePat = (string)ObtenerDatos[2],
                        apeMat = (string)ObtenerDatos[3],
                        Celular = (string)ObtenerDatos[4],
                        correo = (string)ObtenerDatos[5],
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
