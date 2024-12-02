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


namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla OrdenTrabajoDetalle en SqlServer
    /// </summary>
    public class DALOrdenDetalle : IDALOrdenDetalle
    {
        /// <summary>
        /// Obtiene una lista con todas las OrdenDetalles almacenadas en la tabla OrdenDetalle
        /// </summary>
        /// <returns>Retorna un List<OrdenDetalle></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public async Task<List<OrdenDetalle>> GetAllOrdenDetalle()
        {
            string msg = "";
            IDataReader reader = null;
            List<OrdenDetalle> lista = new List<OrdenDetalle>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from OrdenTrabajoDetalle";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        BLLProducto bllProducto = new BLLProducto();

                        OrdenDetalle ordenDetalle = new OrdenDetalle();
                        ordenDetalle.Id = (int) reader["id"];
                        ordenDetalle.Servicio = await bllProducto.GetProductoByID((int) reader["id_Producto"]);
                        lista.Add(ordenDetalle);
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

        public async Task<List<OrdenDetalle>> GetAllOrdenDetalleById_OrdenTrabajo(int id_OrdenTrabajo)
        {
            string msg = "";
            IDataReader reader = null;
            List<OrdenDetalle> lista = new List<OrdenDetalle>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from OrdenTrabajoDetalle where id_OrdenTrabajo = @id_OrdenTrabajo";
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
                        BLLProducto bllProducto = new BLLProducto();

                        OrdenDetalle ordenDetalle = new OrdenDetalle();
                        ordenDetalle.Id = (int)reader["id"];
                        ordenDetalle.Servicio = await bllProducto.GetProductoByID((int)reader["id_Producto"]);
                        lista.Add(ordenDetalle);
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

        public void Insertar(OrdenDetalle ordenDetalle, int id_OrdenTrabajo)
        {
            string msg = "";
            string sql = @"Insert into OrdenTrabajoDetalle values (@id_Producto,@id_OrdenTrabajo)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id_Producto", ordenDetalle.Servicio.Id);
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

        public async Task<OrdenDetalle> GetOrdenDetalleByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            string sql = @"Select  *  from  OrdenTrabajoDetalle   Where id = @id";
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
                        BLLProducto bllProducto = new BLLProducto();

                        OrdenDetalle ordenDetalle = new OrdenDetalle();
                        ordenDetalle.Id = (int)reader["id"];
                        ordenDetalle.Servicio = await bllProducto.GetProductoByID((int)reader["id_Producto"]);

                        return ordenDetalle;
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
