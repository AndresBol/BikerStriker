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

namespace BikerStriker.Layers.DAL
{
    /// <summary>
    /// Clase de acceso a datos para el CRUD con la tabla Marca en SqlServer
    /// </summary>
    public class DALMarca : IDALMarca
    {
        /// <summary>
        /// Obtiene una lista con todas las Marcas almacenadas en la tabla Marca
        /// </summary>
        /// <returns>Retorna un List<Marca></returns>
        /// 

        public List<Marca> GetAllMarca()
        {
            IDataReader reader = null;
            List<Marca> lista = new List<Marca>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from Marca WITH (NOLOCK)  ";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Marca marca = new Marca();
                        marca.Id = int.Parse(reader["id"].ToString());
                        marca.Nombre = reader["nombre"].ToString();
                        marca.Logo = ImageSerializer.DeserializeImageFromString(reader["logo"].ToString());
                        lista.Add(marca);
                    }
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insertar(Marca marca)
        {
            string sql = @"Insert into Marca values (@nombre,@logo)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@nombre", marca.Nombre);
            command.Parameters.AddWithValue("@logo", ImageSerializer.SerializeImageToString(marca.Logo));
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    db.ExecuteNonQuery(command);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Marca marca)
        {
            string sql = @"Update  Marca SET nombre = @nombre, logo = @logo  Where (id = @id) ";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", marca.Id);
            command.Parameters.AddWithValue("@nombre", marca.Nombre);
            command.Parameters.AddWithValue("@logo", ImageSerializer.SerializeImageToString(marca.Logo));
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    db.ExecuteNonQuery(command);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(int id)
        {
            string sql = @"Delete from  Marca   Where (id = @id) ";
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
            catch (Exception)
            {
                throw;
            }
        }

        public Marca GetMarcaByID(int id)
        {
            IDataReader reader = null;
            string sql = @"Select  *  from  Marca   Where (id = @id) ";
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
                        Marca marca = new Marca();
                        marca.Id = int.Parse(reader["id"].ToString());
                        marca.Nombre = reader["nombre"].ToString();
                        marca.Logo = ImageSerializer.DeserializeImageFromString(reader["logo"].ToString());

                        return marca;
                    }
                    
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
