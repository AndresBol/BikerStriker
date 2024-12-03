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
using System.Xml;
using System.Windows.Documents;


namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla Factura en SqlServer
    /// </summary>
    public class DALFactura : IDALFactura
    {
        /// <summary>
        /// Obtiene una lista con todas las Facturas almacenadas en la tabla Factura
        /// </summary>
        /// <returns>Retorna un List<Factura></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public async Task<List<Factura>> GetAllFactura()
        {
            string msg = "";
            IDataReader reader = null;
            List<Factura> lista = new List<Factura>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from Factura";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        BLLOrdenTrabajo bLLOrdenTrabajo = new BLLOrdenTrabajo();
                        BLLCliente bLLCliente = new BLLCliente();
                        BLLTarjeta bLLTarjeta = new BLLTarjeta();
                        BLLFacturaDetalle bllFacturaDetalle = new BLLFacturaDetalle();

                        Factura factura = new Factura();
                        factura.Id = (int)reader["id"];
                        if (reader["id_OrdenTrabajo"] != null) factura.OrdenTrabajo = await bLLOrdenTrabajo.GetOrdenTrabajoByID((int)reader["id_OrdenTrabajo"]);
                        factura.Cliente = bLLCliente.GetClienteByID((int)reader["id_Cliente"]);
                        factura.Tarjeta = factura.Cliente.Tarjetas.FirstOrDefault(b => b.Id == (int)reader["id_Tarjeta"]);
                        factura.TotalColones = (double)reader["totalColones"];
                        factura.TotalDolares = (double)reader["totalDolares"];

                        factura.FacturaDetalle = await bllFacturaDetalle.GetAllFacturaDetalleById_Factura(factura.Id);

                        lista.Add(factura);
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

        public async Task<List<Factura>> GetAllFacturaFromCliente(int ClienteId)
        {
            string msg = "";
            IDataReader reader = null;
            List<Factura> lista = new List<Factura>();

            string sql = @" select * from Factura where id_Cliente = @id";

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", ClienteId);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        BLLOrdenTrabajo bLLOrdenTrabajo = new BLLOrdenTrabajo();
                        BLLCliente bLLCliente = new BLLCliente();
                        BLLTarjeta bLLTarjeta = new BLLTarjeta();
                        BLLFacturaDetalle bllFacturaDetalle = new BLLFacturaDetalle();

                        Factura factura = new Factura();
                        factura.Id = (int)reader["id"];
                        if (reader["id_OrdenTrabajo"] != null) factura.OrdenTrabajo = await bLLOrdenTrabajo.GetOrdenTrabajoByID((int)reader["id_OrdenTrabajo"]);
                        factura.Cliente = bLLCliente.GetClienteByID((int)reader["id_Cliente"]);
                        factura.Tarjeta = factura.Cliente.Tarjetas.FirstOrDefault(b => b.Id == (int)reader["id_Tarjeta"]);
                        factura.TotalColones = (double)reader["totalColones"];
                        factura.TotalDolares = (double)reader["totalDolares"];

                        factura.FacturaDetalle = await bllFacturaDetalle.GetAllFacturaDetalleById_Factura(factura.Id);

                        lista.Add(factura);
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

        public void Insertar(Factura factura, XmlDocument XML_Factura)
        {
            string msg = "";
            string sql = @"Insert into Factura values (@XML_Factura,@id_OrdenTrabajo,@id_Cliente,@id_Tarjeta,@totalColones,@totalDolares)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@XML_Factura", XML_Factura);
            command.Parameters.AddWithValue("@id_OrdenTrabajo", factura.OrdenTrabajo.Id);
            command.Parameters.AddWithValue("@id_Cliente", factura.Cliente.ClienteId);
            command.Parameters.AddWithValue("@id_Tarjeta", factura.Tarjeta.Id);
            command.Parameters.AddWithValue("@totalColones", factura.TotalColones);
            command.Parameters.AddWithValue("@totalDolares", factura.TotalDolares);
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

        public async Task<Factura> GetFacturaByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();

            string sql = @"select * from Factura where id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                Factura factura = null;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        BLLOrdenTrabajo bLLOrdenTrabajo = new BLLOrdenTrabajo();
                        BLLCliente bLLCliente = new BLLCliente();
                        BLLTarjeta bLLTarjeta = new BLLTarjeta();
                        BLLFacturaDetalle bllFacturaDetalle = new BLLFacturaDetalle();

                        factura.Id = (int)reader["id"];
                        if (reader["id_OrdenTrabajo"] != null) factura.OrdenTrabajo = await bLLOrdenTrabajo.GetOrdenTrabajoByID((int)reader["id_OrdenTrabajo"]);
                        factura.Cliente = bLLCliente.GetClienteByID((int)reader["id_Cliente"]);
                        factura.Tarjeta = factura.Cliente.Tarjetas.FirstOrDefault(b => b.Id == (int)reader["id_Tarjeta"]);
                        factura.TotalColones = (double)reader["totalColones"];
                        factura.TotalDolares = (double)reader["totalDolares"];

                        factura.FacturaDetalle = await bllFacturaDetalle.GetAllFacturaDetalleById_Factura(factura.Id);

                    }
                }

                return factura;
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

        public int GetIdFactura(Factura factura)
        {
            string msg = "";
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();

            string sql = @"select id from Factura where id_Cliente = @id_Cliente and id_Tarjeta = @id_Tarjeta and totalColones = @totalColones";

            command.Parameters.AddWithValue("@id_Cliente", factura.Cliente.ClienteId);
            command.Parameters.AddWithValue("@id_Tarjeta", factura.Tarjeta.Id);
            command.Parameters.AddWithValue("@totalColones", factura.TotalColones);

            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                int id = -1;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        id = (int)reader["id"];
                    }
                }

                return id;
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

        public XmlDocument GetXMLFacturaByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();

            string sql = @"select XML_Factura from Factura where id = @id";

            command.Parameters.AddWithValue("@id", id);

            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                XmlDocument documento = null;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        documento = (XmlDocument) reader["XML_Factura"];
                    }
                }

                return documento;
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
