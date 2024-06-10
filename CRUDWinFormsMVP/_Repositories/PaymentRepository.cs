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
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        //Constructor
        public PaymentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(PaymentModel paymentModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO payment (order_id, user_id, user_payment_id, price, time) VALUES(@username, @name, @surname, @email, @password)";
                command.Parameters.Add("@username", MySqlDbType.Int32).Value = paymentModel.OrderId;
                command.Parameters.Add("@name", MySqlDbType.Int32).Value = paymentModel.UserId;
                command.Parameters.Add("@surname", MySqlDbType.Int32).Value = paymentModel.UserPaymentId;
                command.Parameters.Add("@email", MySqlDbType.Int32).Value = paymentModel.Price;
                command.Parameters.Add("@password", MySqlDbType.DateTime).Value = DateTime.Now;
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
                command.CommandText = "DELETE FROM payment WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(PaymentModel paymentModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE payment set order_id = @username, user_id = @name, " +
                                      "user_payment_id = @surname, price = @email " +
                                      "WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = paymentModel.Id;
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = paymentModel.OrderId;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = paymentModel.UserId;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = paymentModel.UserPaymentId;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = paymentModel.Price;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<PaymentModel> GetAll()
        {
            var paymentList = new List<PaymentModel>();
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM payment ORDER BY id";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var paymentModel = new PaymentModel();
                        paymentModel.Id = Convert.ToInt32(reader["id"]);
                        paymentModel.OrderId = Convert.ToInt32(reader["order_id"]);
                        paymentModel.UserId = Convert.ToInt32(reader["user_id"]);
                        paymentModel.UserPaymentId = Convert.ToInt32(reader["user_payment_id"]);
                        paymentModel.Price = Convert.ToInt32(reader["price"]);
                        paymentModel.Time = Convert.ToDateTime(reader["time"]);
                        paymentList.Add(paymentModel);
                    }
                }
            }
            return paymentList;
        }

        public IEnumerable<PaymentModel> GetByValue(string value)
        {
            var paymentList = new List<PaymentModel>();
            int paymentId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            int paymentUserId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from payment 
                                        where id = @id or user_id like @name
                                        order by id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = paymentId;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = paymentUserId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var paymentModel = new PaymentModel();
                        paymentModel.Id = Convert.ToInt32(reader["id"]);
                        paymentModel.OrderId = Convert.ToInt32(reader["order_id"]);
                        paymentModel.UserId = Convert.ToInt32(reader["user_id"]);
                        paymentModel.UserPaymentId = Convert.ToInt32(reader["user_payment_id"]);
                        paymentModel.Price = Convert.ToInt32(reader["price"]);
                        paymentModel.Time = Convert.ToDateTime(reader["time"]);
                        paymentList.Add(paymentModel);
                    }
                }
            }
            return paymentList; ;
        }
    }
}
