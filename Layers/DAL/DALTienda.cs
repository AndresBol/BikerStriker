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
    /// Clase de acceso a datos para el CRUD con la tabla Tienda en SqlServer
    /// </summary>
    public class DALTienda : IDALTienda
    {
        /// <summary>
        /// Obtiene una lista con todas las Tiendas almacenadas en la tabla Tienda
        /// </summary>
        /// <returns>Retorna un List<Tienda></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<Tienda> GetAllTienda()
        {
            string msg = "";
            IDataReader reader = null;
            List<Tienda> lista = new List<Tienda>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from Tienda where activo = 1";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Tienda tienda = new Tienda();
                        tienda.Id = (int) reader["id"];
                        tienda.CedulaJuridica = reader["cedulaJuridica"].ToString();
                        tienda.Nombre = reader["nombre"].ToString();
                        tienda.Telefono = reader["telefono"].ToString();
                        tienda.Direccion = reader["direccion"].ToString();
                        tienda.ImpuestoVenta = Convert.ToDouble(reader["impuestoVenta"].ToString());
                        lista.Add(tienda);
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

        public void Insertar(Tienda tienda)
        {
            string msg = "";
            string sql = @"Insert into Tienda values (@cedulaJuridica,@nombre,@telefono,@direccion,@impuestoVenta,1)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@cedulaJuridica", tienda.CedulaJuridica);
            command.Parameters.AddWithValue("@nombre", tienda.Nombre);
            command.Parameters.AddWithValue("@telefono", tienda.Telefono);
            command.Parameters.AddWithValue("@direccion", tienda.Direccion);
            command.Parameters.AddWithValue("@impuestoVenta", tienda.ImpuestoVenta);
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

        public void Actualizar(Tienda tienda)
        {
            string msg = "";
            string sql = @"Update  Tienda SET cedulaJuridica = @cedulaJuridica, nombre = @nombre, telefono = @telefono, direccion = @direccion, impuestoVenta = @impuestoVenta  Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", tienda.Id);
            command.Parameters.AddWithValue("@cedulaJuridica", tienda.CedulaJuridica);
            command.Parameters.AddWithValue("@nombre", tienda.Nombre);
            command.Parameters.AddWithValue("@telefono", tienda.Telefono);
            command.Parameters.AddWithValue("@direccion", tienda.Direccion);
            command.Parameters.AddWithValue("@impuestoVenta", tienda.ImpuestoVenta);
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
            string sql = @"Update  Tienda SET activo = 0 Where (id = @id)";
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

        public Tienda GetTiendaByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            string sql = @"Select  *  from  Tienda   Where (id = @id)";
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
                        Tienda tienda = new Tienda();
                        tienda.Id = (int)reader["id"];
                        tienda.CedulaJuridica = reader["cedulaJuridica"].ToString();
                        tienda.Nombre = reader["nombre"].ToString();
                        tienda.Telefono = reader["telefono"].ToString();
                        tienda.Direccion = reader["direccion"].ToString();
                        tienda.ImpuestoVenta = Convert.ToDouble(reader["impuestoVenta"].ToString());

                        return tienda;
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
