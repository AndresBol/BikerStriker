using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;
using BikerStriker.Interfaces;
using System.Collections;
using System.Diagnostics;
using BikerStriker.Tools;
using System.Text.RegularExpressions;
using log4net;
using BikerStriker.Extensions;
using BikerStriker.Enums;
using BikerStriker.Layers.BLL;


namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla Administrador en SqlServer
    /// </summary>
    public class DALAdministrador : IDALAdministrador
    {
        /// <summary>
        /// Obtiene una lista con todas las Administradors almacenadas en la tabla Administrador
        /// </summary>
        /// <returns>Retorna un List<Administrador></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<Administrador> GetAllAdministrador()
        {

            string msg = "";
            IDataReader reader = null;
            List<Administrador> lista = new List<Administrador>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from Usuario where activo = 1 and tipoUsuario = 2";

            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Administrador administrador = new Administrador();
                        administrador.UsuarioId = (int) reader["id"];
                        administrador.Correo = reader["correo"].ToString();
                        administrador.Contraseña = reader["contrasena"].ToString();
                        administrador.Nombre = reader["nombre"].ToString();
                        administrador.Apellidos = reader["apellidos"].ToString();
                        lista.Add(administrador);
                    }
                }

                return lista;
            }
            catch (SqlException er)
            {
                _Logger.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new DatabaseException(msg.ToSqlServerDetailError(er), er);
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _Logger.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Administrador GetAdministradorByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            string sql = @"Select  *  from  Usuario   Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", id);
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Administrador administrador = new Administrador();
                        administrador.UsuarioId = (int)reader["id"];
                        administrador.Correo = reader["correo"].ToString();
                        administrador.Contraseña = reader["contrasena"].ToString();
                        administrador.Nombre = reader["nombre"].ToString();
                        administrador.Apellidos = reader["apellidos"].ToString();
                        return administrador;
                    }
                    
                    return null;
                }
            }
            catch (SqlException er)
            {
                _Logger.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new DatabaseException(msg.ToSqlServerDetailError(er), er);
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _Logger.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
    }
}
