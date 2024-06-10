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
    public class UserPaymentRepository: BaseRepository, IUserPaymentRepository
    {
        //Constructor
        public UserPaymentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(UserPaymentModel userpaymentModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO user_payment (user_id, payment_type, account_number, expire_date) VALUES(@username, @name, @surname, @email)";
                command.Parameters.Add("@username", MySqlDbType.Int32).Value = userpaymentModel.UserId;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userpaymentModel.PaymentType;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userpaymentModel.AccountNumber;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = userpaymentModel.ExpireDate;
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
                command.CommandText = "DELETE FROM user_payment WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(UserPaymentModel userpaymentModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE user_payment set user_id = @username, payment_type = @name, " +
                                      "account_number = @surname, expire_date = @email " +
                                      "WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = userpaymentModel.Id;
                command.Parameters.Add("@username", MySqlDbType.Int32).Value = userpaymentModel.UserId;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userpaymentModel.PaymentType;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userpaymentModel.AccountNumber;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = userpaymentModel.ExpireDate;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<UserPaymentModel> GetAll()
        {
            var userPaymentList = new List<UserPaymentModel>();
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM user_payment ORDER BY id";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userPaymentModel = new UserPaymentModel();
                        userPaymentModel.Id = Convert.ToInt32(reader["id"]);
                        userPaymentModel.UserId = Convert.ToInt32(reader["user_id"]);
                        userPaymentModel.PaymentType = reader["payment_type"].ToString();
                        userPaymentModel.AccountNumber = reader["account_number"].ToString();
                        userPaymentModel.ExpireDate = reader["expire_date"].ToString();
                        userPaymentList.Add(userPaymentModel);
                    }
                }
            }
            return userPaymentList;
        }

        public IEnumerable<UserPaymentModel> GetByValue(string value)
        {
            var userPaymentList = new List<UserPaymentModel>();
            int userPaymentId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            int userPaymentUserId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from user_payment 
                                        where id = @id or user_id = @user_id
                                        order by id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = userPaymentId;
                command.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userPaymentUserId;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userPaymentModel = new UserPaymentModel();
                        userPaymentModel.Id = Convert.ToInt32(reader["id"]);
                        userPaymentModel.UserId = Convert.ToInt32(reader["user_id"]);
                        userPaymentModel.PaymentType = reader["payment_type"].ToString();
                        userPaymentModel.AccountNumber = reader["account_number"].ToString();
                        userPaymentModel.ExpireDate = reader["expire_date"].ToString();
                        userPaymentList.Add(userPaymentModel);
                    }
                }
            }
            return userPaymentList;
        }
    }
}
