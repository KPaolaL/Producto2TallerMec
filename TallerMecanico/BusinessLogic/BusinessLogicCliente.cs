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

        //Insertar Autos.
        public Boolean InsertarAutos(EntidadAuto nuevoAuto, ref string mensajeSalida)
        {
            SqlParameter[] param1 = new SqlParameter[6];
            param1[0] = new SqlParameter
            {
                ParameterName = "marca",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.F_marca

            };
            param1[1] = new SqlParameter
            {
                ParameterName = "Modelo",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = nuevoAuto.modelo

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
        public Boolean ActualizarAutos(EntidadAuto nuevoAuto, ref string mensajeSalida)
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

            string sentenciaSql = "update Auto set F_Marca=@marca, Modelo=@Modelo, año=@anio, color=@color, placas=@placa, dueño=@dueno where Id_Auto = @idAut;";
            =
            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentenciaSql, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, param1);

            return salida;
        }

        //Devolver Autos.
        public List<EntityLayerClient> AutosID(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from Auto";

            conextemp = objectoDeAcceso.AbrirConexion(ref msj);

            SqlDataReader ObtenerDatos = null;
            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conextemp, ref msj);

            List<EntityLayerClient> listaSalida = new List<EntityLayerClient>();
            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    listaSalida.Add(new EntityLayerClient
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

        //MECANICO
        //crear mecanico
        public Boolean InsertarMecanico(EntityLayerMecanico entidadMecanico, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.nombre
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.apellidoPat
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.apellidoMat

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.celular
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
                Value = entidadMecanico.nombre
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.apellidoPat
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.apellidoMat

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = entidadMecanico.celular
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
                Value = entidadMecanico.id_tecnico
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
                    listaSalida.Add(new EntityLayerClient
                    {
                        id_Tecnico = (int)ObtenerDatos[0],
                        Nombre = (string)ObtenerDatos[1],
                        App = (string)ObtenerDatos[2],
                        Apm = (string)ObtenerDatos[3],
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

            arametros[3] = new SqlParameter
            {
                ParameterName = "Authorizacion",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.authorizacion

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

            arametros[3] = new SqlParameter
            {
                ParameterName = "Authorizacion",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadRevision.authorizacion

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
                Value = entidadRevision.id_revision
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
                    listaSalida.Add(new EntityLayerClient
                    {
                        id_revision = (int)ObtenerDatos[0],
                        entrada = (string)ObtenerDatos[1],
                        falla = (string)ObtenerDatos[2],
                        diagnostico = (string)ObtenerDatos[3],
                        authorizacion = (string)ObtenerDatos[4],
                        auto = (int)ObtenerDatos[5],
                        mecanico = (int)ObtenerDatos[6]
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

        //REPARACIÓN
        //Insertar
        public Boolean InsertarReparacion(EntityLayerReparacion entidadReparacion, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Detalles",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.detalles
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "Garantia",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.garantia
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "Salida",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.salida

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Revision",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.fk_revision
            };

            string sentencia = "insert into Reparacion values(@Detalles, @Garantia, @Salida, @Revision) ";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }

        //editar
        public Boolean ActualizarReparacion(EntityLayerReparacion entidadReparacion, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Detalles",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.detalles
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "Garantia",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.garantia
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "Salida",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.salida

            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Revision",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.fk_revision
            };

            parametros[4] = new SqlParameter
            {
                ParameterName = "id_reparacion",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadReparacion.id_reparacion
            };

            string sentencia = "update Reparacion set Detalles=@Detalles, Garantia=@Garantia, Salida=@Salida, Fk_Revision=@Revision where id_reparacion = @id_reparacion ";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }

        //Devolver lista de reparaciones
        public List<EntityLayerReparacion> ReparacionID(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from Reparacion";

            conextemp = objectoDeAcceso.AbrirConexion(ref msj);

            SqlDataReader ObtenerDatos = null;
            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conextemp, ref msj);

            List<EntityLayerReparacion> listaSalida = new List<EntityLayerReparacion>();
            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    listaSalida.Add(new EntityLayerClient
                    {
                        id_reparacion = (int)ObtenerDatos[0],
                        detalles = (string)ObtenerDatos[1],
                        garantia = (string)ObtenerDatos[2],
                        salida = (string)ObtenerDatos[3],
                        fk_revision = (int)ObtenerDatos[4],
                        correo = (string)ObtenerDatos[5]
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
   