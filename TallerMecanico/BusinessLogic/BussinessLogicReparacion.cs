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
    class BussinessLogicReparacion
    {
        private ClassDataAccess objectoDeAcceso =
           new ClassDataAccess(@"Data Source=LAPTOP-SFMTQ4SG\SQLEXPRESS; Initial Catalog=MiTaller; Integrated Security = true;"); 

        //REVISAR
        //Insertar
        public Boolean InsertarRevision(EntityLayerRevision entidadRevision, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Entrada",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.entrada
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "Falla",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.falla
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "Diagnostico",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.diagnostico

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Authorizacion",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.autorizacion

            };

            parametros[4] = new SqlParameter
            {
                ParameterName = "Auto",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.auto
            };

            parametros[5] = new SqlParameter
            {
                ParameterName = "Mecanico",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.mecanico
            };

            string sentencia = "insert into Revision values(@Entrada, @Falla, @Diagnostico, @Authorizacion, @Auto, @Mecanico) ";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }

        //Editar
        public Boolean ActualizarRevision(EntityLayerRevision entidadRevision, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Entrada",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.entrada
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "Falla",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.falla
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "Diagnostico",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.diagnostico

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Authorizacion",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.autorizacion

            };

            parametros[4] = new SqlParameter
            {
                ParameterName = "Auto",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.auto
            };

            parametros[5] = new SqlParameter
            {
                ParameterName = "Mecanico",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.mecanico
            };

            parametros[6] = new SqlParameter
            {
                ParameterName = "id_revision",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.idRevision
            };

            string sentencia = "update Revision set Entrada=@Entrada, Falla=@Falla, diagnostico=@Diagnostico, Authorizacion=@Authorizacion, Auto=@Auto, Mecanico=@Mecanico where id_Revision = @id_revision";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }

        //Devolver lista de Revision
        public List<EntityLayerRevision> RevisionID(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from Revision";

            conextemp = objectoDeAcceso.AbrirConexion(ref msj);

            SqlDataReader ObtenerDatos = null;
            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conextemp, ref msj);

            List<EntityLayerRevision> listaSalida = new List<EntityLayerRevision>();
            if (ObtenerDatos != null)
            {   
                while (ObtenerDatos.Read())
                {
                    listaSalida.Add(new EntityLayerRevision
                    {
                        idRevision = (int)ObtenerDatos[0],
                        falla = (string)ObtenerDatos[1],
                        diagnostico = (string)ObtenerDatos[2],
                        autorizacion = (bool)ObtenerDatos[3],
                        auto = (int)ObtenerDatos[4],
                        mecanico = (int)ObtenerDatos[5]
                    });
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
