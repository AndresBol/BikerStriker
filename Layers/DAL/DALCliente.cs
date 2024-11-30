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
    /// Clase de acceso a datos para el CRUD con la tabla Cliente en SqlServer
    /// </summary>
    public class DALCliente : IDALCliente
    {
        /// <summary>
        /// Obtiene una lista con todas las Clientes almacenadas en la tabla Cliente
        /// </summary>
        /// <returns>Retorna un List<Cliente></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<Cliente> GetAllCliente()
        {
            string msg = "";
            IDataReader reader = null;
            List<Cliente> lista = new List<Cliente>();
            SqlCommand command = new SqlCommand();

            string sql = @"
            SELECT c.id, c.identificacion, c.direccion, c.genero, c.id_Usuario, 
            u.id AS user_id, u.correo AS user_correo, u.contrasena AS user_contrasena, u.nombre AS user_nombre, u.apellidos AS user_apellidos
            FROM Cliente c
            LEFT JOIN Usuario u ON c.id_Usuario = u.id
            WHERE c.activo = 1";

            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        BLLBicicleta bllBicicleta = new BLLBicicleta();
                        BLLTarjeta bllTarjeta = new BLLTarjeta();
                        BLLContacto bLLContacto = new BLLContacto();

                        Cliente cliente = new Cliente();
                        cliente.UsuarioId = (int) reader["user_id"];
                        cliente.Correo = reader["user_correo"].ToString();
                        cliente.Contraseña = reader["user_contrasena"].ToString();
                        cliente.Nombre = reader["user_nombre"].ToString();
                        cliente.Apellidos = reader["user_apellidos"].ToString();
                        cliente.ClienteId = (int) reader["id"];
                        cliente.Identificacion = reader["identificacion"].ToString();
                        cliente.Direccion = reader["direccion"].ToString();
                        cliente.Genero = (TipoGenero) Convert.ToInt16(reader["genero"].ToString());
                        cliente.Bicicletas = bllBicicleta.GetAllBicicletaFromCliente(cliente.ClienteId);
                        cliente.Tarjetas = bllTarjeta.GetAllTarjetaFromCliente(cliente.ClienteId);
                        cliente.Contactos = bLLContacto.GetAllContactoFromCliente(cliente.ClienteId);
                        lista.Add(cliente);
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

        public void Insertar(Cliente cliente)
        {
            BLLUsuario bllUsuario = new BLLUsuario();
            bllUsuario.Save(cliente);

            cliente.UsuarioId = bllUsuario.GetIdByEmail(cliente.Correo);

            string msg = "";
            string sql = @"Insert into Cliente values (@identificacion, @direccion, @genero, @id_Usuario, 1)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@identificacion", cliente.Identificacion);
            command.Parameters.AddWithValue("@direccion", cliente.Direccion);
            command.Parameters.AddWithValue("@genero", cliente.Genero);
            command.Parameters.AddWithValue("@id_Usuario", cliente.UsuarioId);
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

        public void Actualizar(Cliente cliente)
        {
            BLLUsuario bllUsuario = new BLLUsuario();
            bllUsuario.Save(cliente);

            string msg = "";
            string sql = @"Update  Cliente SET identificacion = @identificacion, direccion = @direccion, genero = @genero  Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", cliente.ClienteId);
            command.Parameters.AddWithValue("@identificacion", cliente.Identificacion);
            command.Parameters.AddWithValue("@direccion", cliente.Direccion);
            command.Parameters.AddWithValue("@genero", cliente.Genero);
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
            string sql = @"Update  Cliente SET activo = 0 Where (id = @id)";
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

        public Cliente GetClienteByID(int id)
        {
            string msg = "";
            IDataReader reader = null;

            string sql = @"
            SELECT c.id, c.identificacion, c.direccion, c.genero, c.id_Usuario, 
            u.id AS user_id, u.correo AS user_correo, u.contrasena AS user_contrasena, u.nombre AS user_nombre, u.apellidos AS user_apellidos
            FROM Cliente c
            LEFT JOIN Usuario u ON c.id_Usuario = u.id
            WHERE c.id = @id";

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
                        BLLBicicleta bllBicicleta = new BLLBicicleta();
                        BLLTarjeta bllTarjeta = new BLLTarjeta();
                        BLLContacto bLLContacto = new BLLContacto();

                        Cliente cliente = new Cliente();
                        cliente.UsuarioId = (int)reader["user_id"];
                        cliente.Correo = reader["user_correo"].ToString();
                        cliente.Contraseña = reader["user_contrasena"].ToString();
                        cliente.Nombre = reader["user_nombre"].ToString();
                        cliente.Apellidos = reader["user_apellidos"].ToString();
                        cliente.ClienteId = (int)reader["id"];
                        cliente.Identificacion = reader["identificacion"].ToString();
                        cliente.Direccion = reader["direccion"].ToString();
                        cliente.Genero = (TipoGenero) Convert.ToInt16(reader["genero"].ToString());
                        cliente.Bicicletas = bllBicicleta.GetAllBicicletaFromCliente(cliente.ClienteId);
                        cliente.Tarjetas = bllTarjeta.GetAllTarjetaFromCliente(cliente.ClienteId);
                        cliente.Contactos = bLLContacto.GetAllContactoFromCliente(cliente.ClienteId);
                        return cliente;
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
