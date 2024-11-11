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
    /// Clase de acceso a datos para el CRUD con la tabla Vendedor en SqlServer
    /// </summary>
    public class DALVendedor : IDALVendedor
    {
        /// <summary>
        /// Obtiene una lista con todas las Vendedors almacenadas en la tabla Vendedor
        /// </summary>
        /// <returns>Retorna un List<Vendedor></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<Vendedor> GetAllVendedor()
        {
            string msg = "";
            IDataReader reader = null;
            List<Vendedor> lista = new List<Vendedor>();
            SqlCommand command = new SqlCommand();

            string sql = @"
            SELECT v.id, v.codigo, v.fechaNacimiento, v.fotografia, v.id_Usuario, 
            u.id AS user_id, u.correo AS user_correo, u.contrasena AS user_contrasena, u.nombre AS user_nombre, u.apellidos AS user_apellidos
            FROM Vendedor v
            LEFT JOIN Usuario u ON v.id_Usuario = u.id
            WHERE v.activo = 1";

            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Vendedor vendedor = new Vendedor();
                        vendedor.UsuarioId = (int)reader["user_id"];
                        vendedor.Correo = reader["user_correo"].ToString();
                        vendedor.Contraseña = reader["user_contrasena"].ToString();
                        vendedor.Nombre = reader["user_nombre"].ToString();
                        vendedor.Apellidos = reader["user_apellidos"].ToString();
                        vendedor.VendedorId = (int)reader["id"];
                        vendedor.Codigo = reader["codigo"].ToString();
                        vendedor.FechaNacimiento = (DateTime) reader["fechaNacimiento"];
                        vendedor.Fotografia = ImageSerializer.DeserializeImageFromString((byte[])reader["fotografia"]);
                        lista.Add(vendedor);
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

        public void Insertar(Vendedor vendedor)
        {
            BLLUsuario bllUsuario = new BLLUsuario();
            bllUsuario.Save(vendedor);

            vendedor.UsuarioId = bllUsuario.GetIdByEmail(vendedor.Correo);

            string msg = "";
            string sql = @"Insert into Vendedor values (@codigo, @fechaNacimiento, @fotografia, @id_Usuario, 1)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@codigo", vendedor.Codigo);
            command.Parameters.AddWithValue("@fechaNacimiento", vendedor.FechaNacimiento);
            command.Parameters.AddWithValue("@fotografia", ImageSerializer.SerializeImageToString(vendedor.Fotografia));
            command.Parameters.AddWithValue("@id_Usuario", vendedor.UsuarioId);
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

        public void Actualizar(Vendedor vendedor)
        {
            string msg = "";
            string sql = @"Update  Vendedor SET codigo = @codigo, fechaNacimiento = @fechaNacimiento, fotografia = @fotografia  Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", vendedor.VendedorId);
            command.Parameters.AddWithValue("@codigo", vendedor.Codigo);
            command.Parameters.AddWithValue("@fechaNacimiento", vendedor.FechaNacimiento);
            command.Parameters.AddWithValue("@fotografia", ImageSerializer.SerializeImageToString(vendedor.Fotografia));
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
            string sql = @"Update  Vendedor SET activo = 0 Where (id = @id)";
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

        public Vendedor GetVendedorByID(int id)
        {
            string msg = "";
            IDataReader reader = null;

            string sql = @"
            SELECT v.id, v.codigo, v.fechaNacimiento, v.fotografia, v.id_Usuario, 
            u.id AS user_id, u.correo AS user_correo, u.contrasena AS user_contrasena, u.nombre AS user_nombre, u.apellidos AS user_apellidos
            FROM Vendedor v
            LEFT JOIN Usuario u ON v.id_Usuario = u.id
            WHERE v.id = @id";

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
                        Vendedor vendedor = new Vendedor();
                        vendedor.UsuarioId = (int)reader["user_id"];
                        vendedor.Correo = reader["user_correo"].ToString();
                        vendedor.Contraseña = reader["user_contrasena"].ToString();
                        vendedor.Nombre = reader["user_nombre"].ToString();
                        vendedor.Apellidos = reader["user_apellidos"].ToString();
                        vendedor.VendedorId = (int)reader["id"];
                        vendedor.Codigo = reader["codigo"].ToString();
                        vendedor.FechaNacimiento = (DateTime)reader["fechaNacimiento"];
                        vendedor.Fotografia = ImageSerializer.DeserializeImageFromString((byte[])reader["fotografia"]);
                        return vendedor;
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
