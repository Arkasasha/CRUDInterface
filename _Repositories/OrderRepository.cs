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

namespace CRUDWinFormsMVP._Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        //Constructor
        public OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Methods
        public void Add(OrderModel orderModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO `order` (user_id, address_id, delivery_id, time, status) VALUES(@ordername, @name, @surname, @email, @password)";
                command.Parameters.Add("@ordername", MySqlDbType.Int32).Value = orderModel.UserId;
                command.Parameters.Add("@name", MySqlDbType.Int32).Value = orderModel.AddressId;
                command.Parameters.Add("@surname", MySqlDbType.Int32).Value = orderModel.DeliveryId;
                command.Parameters.Add("@email", MySqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = "In Process";
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
                command.CommandText = "DELETE FROM `order` WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(OrderModel orderModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE `order` set user_id = @ordername, address_id = @name, " +
                                      "delivery_id = @surname, status = @password " +
                                      "WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = orderModel.Id;
                command.Parameters.Add("@ordername", MySqlDbType.Int32).Value = orderModel.UserId;
                command.Parameters.Add("@name", MySqlDbType.Int32).Value = orderModel.AddressId;
                command.Parameters.Add("@surname", MySqlDbType.Int32).Value = orderModel.DeliveryId;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = orderModel.Status;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<OrderModel> GetAll()
        {
            var orderList = new List <OrderModel>();
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM `order` ORDER BY id";
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var orderModel = new OrderModel();
                        orderModel.Id = Convert.ToInt32(reader["id"]);
                        orderModel.UserId = Convert.ToInt32(reader["user_id"]);
                        orderModel.AddressId = Convert.ToInt32(reader["address_id"]);
                        orderModel.DeliveryId = Convert.ToInt32(reader["delivery_id"]);
                        orderModel.Time = Convert.ToDateTime(reader["time"]);
                        orderModel.Status = reader["status"].ToString();
                        orderList.Add(orderModel);
                    }
                }
            }
            return orderList;
        }

        public IEnumerable<OrderModel> GetByValue(string value)
        {
            var orderList = new List<OrderModel>();
            int orderId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            int orderUserId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from `order` 
                                        where id = @id or user_id = @name
                                        order by id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = orderId;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = orderUserId;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var orderModel = new OrderModel();
                        orderModel.Id = Convert.ToInt32(reader["id"]);
                        orderModel.UserId = Convert.ToInt32(reader["user_id"]);
                        orderModel.AddressId = Convert.ToInt32(reader["address_id"]);
                        orderModel.DeliveryId = Convert.ToInt32(reader["delivery_id"]);
                        orderModel.Time = Convert.ToDateTime(reader["time"]);
                        orderModel.Status = reader["status"].ToString();
                        orderList.Add(orderModel);
                    }
                }
            }
            return orderList;
        }
    }
}
