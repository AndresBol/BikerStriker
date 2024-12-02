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


namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla OrdenTrabajo en SqlServer
    /// </summary>
    public class DALOrdenTrabajo : IDALOrdenTrabajo
    {
        /// <summary>
        /// Obtiene una lista con todas las OrdenTrabajos almacenadas en la tabla OrdenTrabajo
        /// </summary>
        /// <returns>Retorna un List<OrdenTrabajo></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<OrdenTrabajo> GetAllOrdenTrabajo()
        {
            string msg = "";
            IDataReader reader = null;
            List<OrdenTrabajo> lista = new List<OrdenTrabajo>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from OrdenTrabajo";
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
                        BLLCliente bLLCliente = new BLLCliente();
                        BLLOrdenDetalle bllOrdenDetalle = new BLLOrdenDetalle();
                        BLLOrdenFoto bLLOrdenFoto = new BLLOrdenFoto();

                        OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
                        ordenTrabajo.Id = (int)reader["id"];
                        ordenTrabajo.FechaInicio = (DateTime) reader["fechaInicio"];
                        ordenTrabajo.FechaFinalizacion = (DateTime) reader["fechaFinalizacion"];
                        ordenTrabajo.Firma = ImageSerializer.DeserializeImageFromString((byte[])reader["firma"]);
                        ordenTrabajo.Cliente = bLLCliente.GetClienteByID((int)reader["id_Cliente"]);
                        ordenTrabajo.Bicicleta = ordenTrabajo.Cliente.Bicicletas.FirstOrDefault(b => b.Id == (int)reader["id_Bicicleta"]);

                        ordenTrabajo.OrdenDetalle = bllOrdenDetalle.GetAllOrdenDetalleById_OrdenTrabajo(ordenTrabajo.Id);
                        ordenTrabajo.ordenFoto = bLLOrdenFoto.GetAllOrdenFotoById_OrdenTrabajo(ordenTrabajo.Id);

                        lista.Add(ordenTrabajo);
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

        public List<OrdenTrabajo> GetAllOrdenTrabajoFromCliente(int ClienteId)
        {
            string msg = "";
            IDataReader reader = null;
            List<OrdenTrabajo> lista = new List<OrdenTrabajo>();

            string sql = @" select * from OrdenTrabajo where id_Cliente = @id";

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
                        BLLCliente bLLCliente = new BLLCliente();
                        BLLOrdenDetalle bllOrdenDetalle = new BLLOrdenDetalle();
                        BLLOrdenFoto bLLOrdenFoto = new BLLOrdenFoto();

                        OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
                        ordenTrabajo.Id = (int)reader["id"];
                        ordenTrabajo.FechaInicio = (DateTime)reader["fechaInicio"];
                        ordenTrabajo.FechaFinalizacion = (DateTime)reader["fechaFinalizacion"];
                        ordenTrabajo.Firma = ImageSerializer.DeserializeImageFromString((byte[])reader["firma"]);
                        ordenTrabajo.Cliente = bLLCliente.GetClienteByID((int)reader["id_Cliente"]);
                        ordenTrabajo.Bicicleta = ordenTrabajo.Cliente.Bicicletas.FirstOrDefault(b => b.Id == (int)reader["id_Bicicleta"]);

                        ordenTrabajo.OrdenDetalle = bllOrdenDetalle.GetAllOrdenDetalleById_OrdenTrabajo(ordenTrabajo.Id);
                        ordenTrabajo.ordenFoto = bLLOrdenFoto.GetAllOrdenFotoById_OrdenTrabajo(ordenTrabajo.Id);

                        lista.Add(ordenTrabajo);
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

        public void Insertar(OrdenTrabajo ordenTrabajo)
        {
            string msg = "";
            string sql = @"Insert into OrdenTrabajo values (@fechaInicio,@fechaFinalizacion,@firma,@id_Cliente,@id_Bicicleta)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@fechaInicio", ordenTrabajo.FechaInicio);
            command.Parameters.AddWithValue("@fechaFinalizacion", ordenTrabajo.FechaFinalizacion);
            command.Parameters.AddWithValue("@firma", ImageSerializer.SerializeImageToString(ordenTrabajo.Firma));
            command.Parameters.AddWithValue("@id_Cliente", ordenTrabajo.Cliente.ClienteId);
            command.Parameters.AddWithValue("@id_Bicicleta", ordenTrabajo.Bicicleta.Id);
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

        public OrdenTrabajo GetOrdenTrabajoByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();

            string sql = @"select * from OrdenTrabajo where id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                OrdenTrabajo ordenTrabajo = null;
                BLLModelo bllModelo = new BLLModelo();

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        BLLCliente bLLCliente = new BLLCliente();
                        BLLOrdenDetalle bllOrdenDetalle = new BLLOrdenDetalle();
                        BLLOrdenFoto bLLOrdenFoto = new BLLOrdenFoto();

                        ordenTrabajo.Id = (int)reader["id"];
                        ordenTrabajo.FechaInicio = (DateTime)reader["fechaInicio"];
                        ordenTrabajo.FechaFinalizacion = (DateTime)reader["fechaFinalizacion"];
                        ordenTrabajo.Firma = ImageSerializer.DeserializeImageFromString((byte[])reader["firma"]);
                        ordenTrabajo.Cliente = bLLCliente.GetClienteByID((int)reader["id_Cliente"]);
                        ordenTrabajo.Bicicleta = ordenTrabajo.Cliente.Bicicletas.FirstOrDefault(b => b.Id == (int)reader["id_Bicicleta"]);

                        ordenTrabajo.OrdenDetalle = bllOrdenDetalle.GetAllOrdenDetalleById_OrdenTrabajo(ordenTrabajo.Id);
                        ordenTrabajo.ordenFoto = bLLOrdenFoto.GetAllOrdenFotoById_OrdenTrabajo(ordenTrabajo.Id);

                    }
                }

                return ordenTrabajo;
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
