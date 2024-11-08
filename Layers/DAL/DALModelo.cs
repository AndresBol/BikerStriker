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


namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla Modelo en SqlServer
    /// </summary>
    public class DALModelo : IDALModelo
    {
        /// <summary>
        /// Obtiene una lista con todas las Modelos almacenadas en la tabla Modelo
        /// </summary>
        /// <returns>Retorna un List<Modelo></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<Modelo> GetAllModelo()
        {
            string msg = "";
            IDataReader reader = null;
            List<Modelo> lista = new List<Modelo>();
            SqlCommand command = new SqlCommand();

            string sql = @"
            SELECT m.id, m.nombre, m.id_Marca, ma.nombre AS marca_nombre, ma.logo AS marca_logo
            FROM Modelo m
            LEFT JOIN Marca ma ON m.id_Marca = ma.id
            WHERE m.activo = 1";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Modelo modelo = new Modelo();
                        modelo.Id = (int) reader["id"];
                        modelo.Nombre = reader["nombre"].ToString();

                        modelo.Marca = new Marca
                        {
                            Id = (int)reader["id_Marca"],
                            Nombre = reader["marca_nombre"].ToString(),
                            Logo = ImageSerializer.DeserializeImageFromString((byte[])reader["marca_logo"])
                        };

                        lista.Add(modelo);
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

        public void Insertar(Modelo modelo)
        {
            string msg = "";
            string sql = @"Insert into Modelo values (@nombre,@id_Marca,1)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@nombre", modelo.Nombre);
            command.Parameters.AddWithValue("@id_Marca", modelo.Marca.Id);
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

        public void Actualizar(Modelo modelo)
        {
            string msg = "";
            string sql = @"Update  Modelo SET nombre = @nombre, id_Marca = @id_Marca  Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", modelo.Id);
            command.Parameters.AddWithValue("@nombre", modelo.Nombre);
            command.Parameters.AddWithValue("@id_Marca", modelo.Marca.Id);
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
            string sql = @"Update  Modelo SET activo = 0 Where (id = @id)";
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

        public Modelo GetModeloByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();
            
            string sql = @"
            SELECT m.id, m.nombre, m.id_Marca, ma.nombre AS marca_nombre, ma.logo AS marca_logo
            FROM Modelo m
            LEFT JOIN Marca ma ON m.id_Marca = ma.id
            WHERE m.id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                Modelo modelo = new Modelo();

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        
                        modelo.Id = (int)reader["id"];
                        modelo.Nombre = reader["nombre"].ToString();

                        modelo.Marca = new Marca
                        {
                            Id = (int)reader["id_Marca"],
                            Nombre = reader["marca_nombre"].ToString(),
                            Logo = ImageSerializer.DeserializeImageFromString((byte[])reader["marca_logo"])
                        };

                    }
                }

                return modelo;
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
