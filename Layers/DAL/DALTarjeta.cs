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
using BikerStriker.Layers.BLL;
using System.Drawing;
using BikerStriker.Enums;


namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla Tarjeta en SqlServer
    /// </summary>
    public class DALTarjeta : IDALTarjeta
    {
        /// <summary>
        /// Obtiene una lista con todas las Tarjetas almacenadas en la tabla Tarjeta
        /// </summary>
        /// <returns>Retorna un List<Tarjeta></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<Tarjeta> GetAllTarjeta()
        {
            string msg = "";
            IDataReader reader = null;
            List<Tarjeta> lista = new List<Tarjeta>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from Tarjeta where activo = 1";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                BLLModelo bllModelo = new BLLModelo();

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Tarjeta tarjeta = new Tarjeta();
                        tarjeta.Id = (int)reader["id"];
                        tarjeta.Numero = reader["numero"].ToString();
                        tarjeta.FechaVencimiento = (DateTime)reader["fechaVencimiento"];
                        tarjeta.CodigoSeguridad = (short)reader["codigoSeguridad"];
                        tarjeta.TipoTarjeta = (TipoTarjeta) Convert.ToInt16(reader["tipoTarjeta"]);

                        lista.Add(tarjeta);
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

        public List<Tarjeta> GetAllTarjetaFromCliente(int ClienteId)
        {
            string msg = "";
            IDataReader reader = null;
            List<Tarjeta> lista = new List<Tarjeta>();

            string sql = @" select * from Tarjeta where (id_Cliente = @id and activo = 1)";

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", ClienteId);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                BLLModelo bllModelo = new BLLModelo();

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Tarjeta tarjeta = new Tarjeta();
                        tarjeta.Id = (int)reader["id"];
                        tarjeta.Numero = reader["numero"].ToString();
                        tarjeta.FechaVencimiento = (DateTime)reader["fechaVencimiento"];
                        tarjeta.CodigoSeguridad = (short)reader["codigoSeguridad"];
                        tarjeta.TipoTarjeta = (TipoTarjeta)Convert.ToInt16(reader["tipoTarjeta"]);

                        lista.Add(tarjeta);
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

        public int GetClientIdFromId(int id)
        {
            string msg = "";
            IDataReader reader = null;
            List<Tarjeta> lista = new List<Tarjeta>();

            string sql = @" select id_Cliente from Tarjeta where id = @id";

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", id);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                int idClienteBici = 0;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        idClienteBici = (int)reader["id_Cliente"];

                    }
                }

                return idClienteBici;
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

        public void Insertar(Tarjeta tarjeta, int ClienteId)
        {
            string msg = "";
            string sql = @"Insert into Tarjeta values (@numero,@fechaVencimiento,@codigoSeguridad,@tipoTarjeta,@id_Cliente,1)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@numero", tarjeta.Numero);
            command.Parameters.AddWithValue("@fechaVencimiento", tarjeta.FechaVencimiento);
            command.Parameters.AddWithValue("@codigoSeguridad", tarjeta.CodigoSeguridad);
            command.Parameters.AddWithValue("@tipoTarjeta", tarjeta.TipoTarjeta);
            command.Parameters.AddWithValue("@id_Cliente", ClienteId);
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

        public void Actualizar(Tarjeta tarjeta, int ClienteId)
        {
            string msg = "";
            string sql = @"Update  Tarjeta SET numero = @numero, fechaVencimiento = @fechaVencimiento, codigoSeguridad = @codigoSeguridad, tipoTarjeta = @tipoTarjeta, id_Cliente = @id_Cliente  Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@numero", tarjeta.Numero);
            command.Parameters.AddWithValue("@fechaVencimiento", tarjeta.FechaVencimiento);
            command.Parameters.AddWithValue("@codigoSeguridad", tarjeta.CodigoSeguridad);
            command.Parameters.AddWithValue("@tipoTarjeta", tarjeta.TipoTarjeta);
            command.Parameters.AddWithValue("@id_Cliente", ClienteId);
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
            string sql = @"Update  Tarjeta SET activo = 0 Where (id = @id)";
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

        public Tarjeta GetTarjetaByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();

            string sql = @"select * from Tarjeta where id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                Tarjeta tarjeta = null;
                BLLModelo bllModelo = new BLLModelo();

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        tarjeta.Id = (int)reader["id"];
                        tarjeta.Numero = reader["numero"].ToString();
                        tarjeta.FechaVencimiento = (DateTime)reader["fechaVencimiento"];
                        tarjeta.CodigoSeguridad = (short)reader["codigoSeguridad"];
                        tarjeta.TipoTarjeta = (TipoTarjeta)Convert.ToInt16(reader["tipoTarjeta"]);
                    }
                }

                return tarjeta;
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
