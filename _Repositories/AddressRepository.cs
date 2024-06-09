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
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        //Constructor
        public AddressRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Methods
        public void Add(AddressModel addressModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO address (user_id, city, street, postal_code) VALUES(@user_id, @city, @street, @postal_code)";
                command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = addressModel.UserId;
                command.Parameters.Add("@city", MySqlDbType.VarChar).Value = addressModel.City;
                command.Parameters.Add("@street", MySqlDbType.VarChar).Value = addressModel.Street;
                command.Parameters.Add("@postal_code", MySqlDbType.VarChar).Value = addressModel.PostalCode;
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
                command.CommandText = @"DELETE FROM address WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(AddressModel addressModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE address set user_id = @user_id, city = @city, 
                                      street = @street, postal_code = @postal_code
                                      WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = addressModel.Id;
                command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = addressModel.UserId;
                command.Parameters.Add("@city", MySqlDbType.VarChar).Value = addressModel.City;
                command.Parameters.Add("@street", MySqlDbType.VarChar).Value = addressModel.Street;
                command.Parameters.Add("@postal_code", MySqlDbType.VarChar).Value = addressModel.PostalCode;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<AddressModel> GetAll()
        {
            var addressList = new List<AddressModel>();
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM address ORDER BY id";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var addressModel = new AddressModel();
                        addressModel.Id = Convert.ToInt32(reader["id"]);
                        addressModel.UserId = Convert.ToInt32(reader["user_id"]);
                        addressModel.City = reader["city"].ToString();
                        addressModel.Street = reader["street"].ToString();
                        addressModel.PostalCode = reader["postal_code"].ToString();
                        addressList.Add(addressModel);
                    }
                }
            }
            return addressList;
        }

        public IEnumerable<AddressModel> GetByValue(string value)
        {
            var addressList = new List<AddressModel>();
            int addressId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            int addressUserId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM address
                                        WHERE id = @id or user_id = @user_id
                                        ORDER BY id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = addressId;
                command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = addressUserId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var addressModel = new AddressModel();
                        addressModel.Id = Convert.ToInt32(reader["id"]);
                        addressModel.UserId = Convert.ToInt32(reader["user_id"]);
                        addressModel.City = reader["city"].ToString();
                        addressModel.Street = reader["street"].ToString();
                        addressModel.PostalCode = reader["postal_code"].ToString();
                        addressList.Add(addressModel);
                    }
                }
            }
            return addressList;
        }
    }
}
