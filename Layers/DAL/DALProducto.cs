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
using System.Windows.Forms;
using BikerStriker.Util;


namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla Producto en SqlServer
    /// </summary>
    public class DALProducto : IDALProducto
    {
        /// <summary>
        /// Obtiene una lista con todas las Productos almacenadas en la tabla Producto
        /// </summary>
        /// <returns>Retorna un List<Producto></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        private async Task<double> ObtenerDolarizado(double montoColones)
        {
            BancoCentralApiHelper bccrAPI = new BancoCentralApiHelper();
            double tipoCambioCompra = 0;

            await Task.Run(() =>
            {
                tipoCambioCompra = bccrAPI.ObtenerTipoCambio(DateTime.Now);
            });


            return Math.Round(montoColones / tipoCambioCompra, 2);
        }

        public async Task<List<Producto>> GetAllProducto()
        {
            string msg = "";
            IDataReader reader = null;
            List<Producto> lista = new List<Producto>();
            SqlCommand command = new SqlCommand();

            string sql = @"
            SELECT p.id, p.codigo, p.nombre, p.precio, p.descripcion, p.cantidad, p.id_Categoria, p.es_Servicio, ca.nombre AS Categoria_nombre
            FROM Producto p
            LEFT JOIN Categoria ca ON p.id_Categoria = ca.id
            WHERE p.activo = 1";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.Id = (int) reader["id"];
                        producto.Codigo = reader["codigo"].ToString();
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Precio = Convert.ToDouble(reader["precio"].ToString());
                        producto.Dolarizado = await ObtenerDolarizado(producto.Precio);
                        producto.Descripcion = reader["descripcion"].ToString();
                        producto.Cantidad = (int) reader["cantidad"];
                        
                        producto.Categoria = new Categoria
                        {
                            Id = (int)reader["id_Categoria"],
                            Nombre = reader["Categoria_nombre"].ToString(),
                        };

                        producto.EsServicio = (bool) reader["es_Servicio"];

                        lista.Add(producto);
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

        public void Insertar(Producto producto)
        {
            string msg = "";
            string sql = @"Insert into Producto values (@codigo,@nombre,@precio,@descripcion,@cantidad,@id_Categoria,@es_Servicio,1)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@codigo", producto.Codigo);
            command.Parameters.AddWithValue("@nombre", producto.Nombre);
            command.Parameters.AddWithValue("@precio", producto.Precio);
            command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@cantidad", producto.Cantidad);
            command.Parameters.AddWithValue("@id_Categoria", producto.Categoria.Id);
            command.Parameters.AddWithValue("@es_Servicio", producto.EsServicio);
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

        public void Actualizar(Producto producto)
        {
            string msg = "";
            string sql = @"Update  Producto SET codigo = @codigo, nombre = @nombre, precio = @precio, descripcion = @descripcion, cantidad = @cantidad, id_Categoria = @id_Categoria, es_Servicio = @es_Servicio  Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", producto.Id);
            command.Parameters.AddWithValue("@codigo", producto.Codigo);
            command.Parameters.AddWithValue("@nombre", producto.Nombre);
            command.Parameters.AddWithValue("@precio", producto.Precio);
            command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@cantidad", producto.Cantidad);
            command.Parameters.AddWithValue("@id_Categoria", producto.Categoria.Id);
            command.Parameters.AddWithValue("@es_Servicio", producto.EsServicio);
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
            string sql = @"Update  Producto SET activo = 0 Where (id = @id)";
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

        public async Task<Producto> GetProductoByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();

            string sql = @"
            SELECT p.id, p.codigo, p.nombre, p.precio, p.descripcion, p.cantidad, p.id_Categoria, p.es_Servicio, ca.nombre AS Categoria_nombre
            FROM Producto p
            LEFT JOIN Categoria ca ON p.id_Categoria = ca.id
            WHERE p.id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                Producto producto = null;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        producto = new Producto();
                        producto.Id = (int)reader["id"];
                        producto.Codigo = reader["codigo"].ToString();
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Precio = Convert.ToDouble(reader["precio"].ToString());
                        producto.Dolarizado = await ObtenerDolarizado(producto.Precio);
                        producto.Descripcion = reader["descripcion"].ToString();
                        producto.Cantidad = (int)reader["cantidad"];

                        producto.Categoria = new Categoria
                        {
                            Id = (int)reader["id_Categoria"],
                            Nombre = reader["Categoria_nombre"].ToString(),
                        };

                        producto.EsServicio = (bool)reader["es_Servicio"];

                    }
                }

                return producto;
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
