using CRUDWinFormsMVP.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CRUDWinFormsMVP._Repositories
{
    public class OrderItemRepository : BaseRepository, IOrderItemRepository
    {
        //Constructor
        public OrderItemRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(OrderItemModel orderItemModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO order_item (order_id, product_id, size) VALUES(@order_id, @product_id, @size)";
                command.Parameters.Add("@order_id", MySqlDbType.Int32).Value = orderItemModel.OrderId;
                command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = orderItemModel.ProductId;
                command.Parameters.Add("@size", MySqlDbType.Int32).Value = orderItemModel.Size;
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
                command.CommandText = "DELETE FROM order_item WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(OrderItemModel orderItemModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE order_item set order_id = @order_id, " +
                                      "product_id = @product_id, size = @size " +
                                      "WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = orderItemModel.Id;
                command.Parameters.Add("@order_id", MySqlDbType.Int32).Value = orderItemModel.OrderId;
                command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = orderItemModel.ProductId;
                command.Parameters.Add("@size", MySqlDbType.Int32).Value = orderItemModel.Size;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<OrderItemModel> GetAll()
        {
            var orderItemList = new List<OrderItemModel>();
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM order_item ORDER BY id";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var orderItemModel = new OrderItemModel();
                        orderItemModel.Id = Convert.ToInt32(reader["id"]);
                        orderItemModel.OrderId = Convert.ToInt32(reader["order_id"]);
                        orderItemModel.ProductId = Convert.ToInt32(reader["product_id"]);
                        orderItemModel.Size = Convert.ToInt32(reader["size"]);
                        orderItemList.Add(orderItemModel);
                    }
                }
            }
            return orderItemList;
        }

        public IEnumerable<OrderItemModel> GetByValue(string value)
        {
            var orderItemList = new List<OrderItemModel>();
            int orderItemId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            int orderItemOrderId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from order_item 
                                        where id = @id or order_id = @order_id
                                        order by id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = orderItemId;
                command.Parameters.Add("@order_id", MySqlDbType.Int32).Value = orderItemOrderId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var orderItemModel = new OrderItemModel();
                        orderItemModel.Id = Convert.ToInt32(reader["id"]);
                        orderItemModel.OrderId = Convert.ToInt32(reader["order_id"]);
                        orderItemModel.ProductId = Convert.ToInt32(reader["product_id"]);
                        orderItemModel.Size = Convert.ToInt32(reader["size"]);
                        orderItemList.Add(orderItemModel);
                    }
                }
            }
            return orderItemList;
        }
    }
}
