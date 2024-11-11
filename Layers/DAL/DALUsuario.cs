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


namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla Usuario en SqlServer
    /// </summary>
    public class DALUsuario : IDALUsuario
    {
        /// <summary>
        /// Obtiene una lista con todas las Usuarios almacenadas en la tabla Usuario
        /// </summary>
        /// <returns>Retorna un List<Usuario></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<Usuario> GetAllUsuario()
        {
            string msg = "";
            IDataReader reader = null;
            List<Usuario> lista = new List<Usuario>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from Usuario where activo = 1";

            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Usuario usuario;
                        switch ((TipoUsuario) Convert.ToInt16(reader["tipoUsuario"].ToString()))
                        {
                            case TipoUsuario.Cliente:
                                usuario = new Cliente();
                                break;
                            case TipoUsuario.Vendedor:
                                usuario = new Vendedor();
                                break;
                            case TipoUsuario.Administrador:
                                usuario = new Administrador();
                                break;
                            default:
                                usuario = null;
                                break;
                        }

                        usuario.UsuarioId = (int)reader["id"];
                        usuario.Correo = reader["correo"].ToString();
                        usuario.Contraseña = reader["contrasena"].ToString();
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Apellidos = reader["apellidos"].ToString();
                        lista.Add(usuario);

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

        public void Insertar(Usuario usuario)
        {
            string msg = "";
            string sql = @"Insert into Usuario values (@correo,@contrasena,@nombre,@apellidos,@tipoUsuario,1)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@correo", usuario.Correo);
            command.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
            command.Parameters.AddWithValue("@nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
            command.Parameters.AddWithValue("@tipoUsuario", (short) usuario.TipoUsuario);
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    db.ExecuteNonQuery(command);
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

        public void Actualizar(Usuario usuario)
        {
            string msg = "";
            string sql = @"Update  Usuario SET correo = @correo, contrasena = @contrasena, nombre = @nombre, apellidos = @apellidos, tipoUsuario = @tipoUsuario  Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", usuario.UsuarioId);
            command.Parameters.AddWithValue("@correo", usuario.Correo);
            command.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
            command.Parameters.AddWithValue("@nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
            command.Parameters.AddWithValue("@tipoUsuario", (short)usuario.TipoUsuario);
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    db.ExecuteNonQuery(command);
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

        public void Desactivar(int id)
        {
            string msg = "";
            string sql = @"Update  Usuario SET activo = 0 Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", id);
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    db.ExecuteNonQuery(command);
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

        public Usuario GetUsuarioByID(int id)
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
                        Usuario usuario;

                        switch ((TipoUsuario) Convert.ToInt16(reader["tipoUsuario"].ToString()))
                        {
                            case TipoUsuario.Cliente:
                                usuario = new Cliente();
                                break;
                            case TipoUsuario.Vendedor:
                                usuario = new Vendedor();
                                break;
                            case TipoUsuario.Administrador:
                                usuario = new Administrador();
                                break;
                            default:
                                usuario = null;
                                break;
                        }

                        usuario.UsuarioId = (int)reader["id"];
                        usuario.Correo = reader["correo"].ToString();
                        usuario.Contraseña = reader["contrasena"].ToString();
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Apellidos = reader["apellidos"].ToString();

                        return usuario;
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

        public int GetIdByEmail(string email)
        {
            string msg = "";
            IDataReader reader = null;
            string sql = @"Select  id  from  Usuario   Where (correo = @email)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@email", email);
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        return (int) reader["id"];
                    }

                    return 0;
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
