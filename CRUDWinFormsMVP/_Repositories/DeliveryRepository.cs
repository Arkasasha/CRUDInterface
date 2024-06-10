using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using CRUDWinFormsMVP.Models;
using Org.BouncyCastle.Bcpg;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CRUDWinFormsMVP._Repositories
{
    public class DeliveryRepository : BaseRepository, IDeliveryRepository
    {
        //Constructor
        public DeliveryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(DeliveryModel deliveryModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO delivery (name) VALUES(@name)";
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = deliveryModel.Name;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM delivery WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(DeliveryModel deliveryModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE delivery set name = @name WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = deliveryModel.Id;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = deliveryModel.Name;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DeliveryModel> GetAll()
        {
            var deliveryList = new List<DeliveryModel>();
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM delivery ORDER BY id";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var deliveryModel = new DeliveryModel();
                        deliveryModel.Id = Convert.ToInt32(reader["id"]);
                        deliveryModel.Name = reader["name"].ToString();
                        deliveryList.Add(deliveryModel);
                    }
                }
            }
            return deliveryList;
        }

        public IEnumerable<DeliveryModel> GetByValue(string value)
        {
            var deliveryList = new List<DeliveryModel>();
            int deliveryId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string deliveryName = "%" + value + "%";
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from delivery 
                                        where id = @id or name like @name
                                        order by id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = deliveryId;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = deliveryName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var deliveryModel = new DeliveryModel();
                        deliveryModel.Id = Convert.ToInt32(reader["id"]);
                        deliveryModel.Name = reader["name"].ToString();
                        deliveryList.Add(deliveryModel);
                    }
                }
            }
            return deliveryList;
        }
    }
}
