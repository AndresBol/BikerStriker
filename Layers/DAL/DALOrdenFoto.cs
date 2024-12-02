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
    /// Clase de acceso a datos para el CRUD con la tabla OrdenFoto en SqlServer
    /// </summary>
    public class DALOrdenFoto : IDALOrdenFoto
    {
        /// <summary>
        /// Obtiene una lista con todas las OrdenFotos almacenadas en la tabla OrdenFoto
        /// </summary>
        /// <returns>Retorna un List<OrdenFoto></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<OrdenFoto> GetAllOrdenFoto()
        {
            string msg = "";
            IDataReader reader = null;
            List<OrdenFoto> lista = new List<OrdenFoto>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from OrdenFoto";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        OrdenFoto ordenFoto = new OrdenFoto();
                        ordenFoto.Id = (int) reader["id"];
                        ordenFoto.Foto = ImageSerializer.DeserializeImageFromString((byte[]) reader["foto"]);
                        lista.Add(ordenFoto);
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

        public List<OrdenFoto> GetAllOrdenFotoById_OrdenTrabajo(int id_OrdenTrabajo)
        {
            string msg = "";
            IDataReader reader = null;
            List<OrdenFoto> lista = new List<OrdenFoto>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from OrdenFoto where id_OrdenTrabajo = @id_OrdenTrabajo";
            command.Parameters.AddWithValue("@id_OrdenTrabajo", id_OrdenTrabajo);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        OrdenFoto ordenFoto = new OrdenFoto();
                        ordenFoto.Id = (int)reader["id"];
                        ordenFoto.Foto = ImageSerializer.DeserializeImageFromString((byte[])reader["foto"]);
                        lista.Add(ordenFoto);
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

        public void Insertar(OrdenFoto ordenFoto, int id_OrdenTrabajo)
        {
            string msg = "";
            string sql = @"Insert into OrdenFoto values (@foto,@id_OrdenTrabajo)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@foto", ImageSerializer.SerializeImageToString(ordenFoto.Foto));
            command.Parameters.AddWithValue("@id_OrdenTrabajo", id_OrdenTrabajo);
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

        public OrdenFoto GetOrdenFotoByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            string sql = @"Select  *  from  OrdenFoto   Where id = @id";
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
                        OrdenFoto ordenFoto = new OrdenFoto();
                        ordenFoto.Id = (int)reader["id"];
                        ordenFoto.Foto = ImageSerializer.DeserializeImageFromString((byte[])reader["foto"]);

                        return ordenFoto;
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
