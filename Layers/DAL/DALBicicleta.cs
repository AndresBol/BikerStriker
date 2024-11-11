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
    /// Clase de acceso a datos para el CRUD con la tabla Bicicleta en SqlServer
    /// </summary>
    public class DALBicicleta : IDALBicicleta
    {
        /// <summary>
        /// Obtiene una lista con todas las Bicicletas almacenadas en la tabla Bicicleta
        /// </summary>
        /// <returns>Retorna un List<Bicicleta></returns>
        /// 

        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        public List<Bicicleta> GetAllBicicleta()
        {
            string msg = "";
            IDataReader reader = null;
            List<Bicicleta> lista = new List<Bicicleta>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from Bicicleta where activo = 1";
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
                        Bicicleta bicicleta = new Bicicleta();
                        bicicleta.Id = (int) reader["id"];
                        bicicleta.NumeroSerie = reader["numeroSerie"].ToString();
                        bicicleta.Color = ColorTranslator.FromHtml(reader["color"].ToString());
                        bicicleta.Modelo = bllModelo.GetModeloByID((int)reader["id_Modelo"]);

                        lista.Add(bicicleta);
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

        public List<Bicicleta> GetAllBicicletaFromCliente(int ClienteId)
        {
            string msg = "";
            IDataReader reader = null;
            List<Bicicleta> lista = new List<Bicicleta>();

            string sql = @" select * from Bicicleta where (id_Cliente = @id and activo = 1)";

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
                        Bicicleta bicicleta = new Bicicleta();
                        bicicleta.Id = (int)reader["id"];
                        bicicleta.NumeroSerie = reader["numeroSerie"].ToString();
                        bicicleta.Color = ColorTranslator.FromHtml(reader["color"].ToString());
                        bicicleta.Modelo = bllModelo.GetModeloByID((int)reader["id_Modelo"]);

                        lista.Add(bicicleta);
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

        public void Insertar(Bicicleta bicicleta, int ClienteId)
        {
            string msg = "";
            string sql = @"Insert into Bicicleta values (@numeroSerie,@color,@id_Modelo,@id_Cliente,1)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@numeroSerie", bicicleta.NumeroSerie);
            command.Parameters.AddWithValue("@color", ColorTranslator.ToHtml(bicicleta.Color));
            command.Parameters.AddWithValue("@id_Modelo", bicicleta.Modelo.Id);
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

        public void Actualizar(Bicicleta bicicleta)
        {
            string msg = "";
            string sql = @"Update  Bicicleta SET numeroSerie = @numeroSerie, color = @color  Where (id = @id)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", bicicleta.Id);
            command.Parameters.AddWithValue("@numeroSerie", bicicleta.NumeroSerie);
            command.Parameters.AddWithValue("@color", ColorTranslator.ToHtml(bicicleta.Color));
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
            string sql = @"Update  Bicicleta SET activo = 0 Where (id = @id)";
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

        public Bicicleta GetBicicletaByID(int id)
        {
            string msg = "";
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();
            
            string sql = @"select * from Bicicleta where id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                Bicicleta bicicleta = new Bicicleta();
                BLLModelo bllModelo = new BLLModelo();

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {

                        bicicleta.Id = (int)reader["id"];
                        bicicleta.NumeroSerie = reader["numeroSerie"].ToString();
                        bicicleta.Color = ColorTranslator.FromHtml(reader["color"].ToString());
                        bicicleta.Modelo = bllModelo.GetModeloByID((int)reader["id_Modelo"]);

                    }
                }

                return bicicleta;
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
