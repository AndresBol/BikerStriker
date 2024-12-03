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
    /// Clase de acceso a datos para el CRUD con la tabla FacturaDetalle en SqlServer
    /// </summary>
    public class DALFacturaDetalle : IDALFacturaDetalle
    {
        /// <summary>
        /// Obtiene una lista con todas las FacturaDetalles almacenadas en la tabla FacturaDetalle
        /// </summary>
        /// <returns>Retorna un List<FacturaDetalle></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public async Task<List<FacturaDetalle>> GetAllFacturaDetalle()
        {
            string msg = "";
            IDataReader reader = null;
            List<FacturaDetalle> lista = new List<FacturaDetalle>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from FacturaDetalle";
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

                        FacturaDetalle facturaDetalle = new FacturaDetalle();
                        facturaDetalle.Id = (int) reader["id"];
                        facturaDetalle.Producto = await bllProducto.GetProductoByID((int) reader["id_Producto"]);
                        facturaDetalle.Cantidad = (int) reader["cantidad"];
                        lista.Add(facturaDetalle);
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

        public async Task<List<FacturaDetalle>> GetAllFacturaDetalleById_Factura(int id_Factura)
        {
            string msg = "";
            IDataReader reader = null;
            List<FacturaDetalle> lista = new List<FacturaDetalle>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from FacturaDetalle where id_Factura = @id_Factura";
            command.Parameters.AddWithValue("@id_Factura", id_Factura);
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

                        FacturaDetalle facturaDetalle = new FacturaDetalle();
                        facturaDetalle.Id = (int)reader["id"];
                        facturaDetalle.Producto = await bllProducto.GetProductoByID((int)reader["id_Producto"]);
                        facturaDetalle.Cantidad = (int)reader["cantidad"];
                        lista.Add(facturaDetalle);
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

        public void Insertar(FacturaDetalle facturaDetalle, int id_Factura)
        {
            string msg = "";
            string sql = @"Insert into FacturaDetalle values (@id_Producto,@cantidad,@id_Factura)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id_Producto", facturaDetalle.Producto.Id);
            command.Parameters.AddWithValue("@cantidad", facturaDetalle.Cantidad);
            command.Parameters.AddWithValue("@id_Factura", id_Factura);
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

        public async Task<FacturaDetalle> GetFacturaDetalleByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            string sql = @"Select  *  from  FacturaDetalle   Where id = @id";
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

                        FacturaDetalle facturaDetalle = new FacturaDetalle();
                        facturaDetalle.Id = (int)reader["id"];
                        facturaDetalle.Cantidad = (int)reader["cantidad"];
                        facturaDetalle.Producto = await bllProducto.GetProductoByID((int)reader["id_Producto"]);

                        return facturaDetalle;
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
