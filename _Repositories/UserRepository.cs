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
    public class UserRepository : BaseRepository, IUserRepository
    {
        //Constructor
        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Methods
        public void Add(UserModel userModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO user (username, name, surname, email, password) VALUES(@username, @name, @surname, @email, @password)";
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userModel.Name;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userModel.Surname;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = userModel.Email;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = userModel.Password;
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
                command.CommandText = "DELETE FROM user WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }
        public void Edit(UserModel userModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE user set username = @username, name = @name, " +
                                      "surname = @surname, email = @email, password = @password " +
                                      "WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = userModel.Id;
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userModel.Name;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userModel.Surname;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = userModel.Email;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = userModel.Password;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            var userList = new List <UserModel>();
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM user ORDER BY id";
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var userModel = new UserModel();
                        userModel.Id = Convert.ToInt32(reader["id"]);
                        userModel.Username = reader["username"].ToString();
                        userModel.Name = reader["name"].ToString();
                        userModel.Surname = reader["surname"].ToString();
                        userModel.Email = reader["email"].ToString();
                        userModel.Password = reader["password"].ToString();
                        userList.Add(userModel);
                    }
                }
            }
            return userList;
        }

        public IEnumerable<UserModel> GetByValue(string value)
        {
            var userList = new List<UserModel>();
            int userId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string userName = "%" + value + "%";
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from user 
                                        where id = @id or name like @name
                                        order by id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = userId;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userModel = new UserModel();
                        userModel.Id = Convert.ToInt32(reader["id"]);
                        userModel.Username = reader["username"].ToString();
                        userModel.Name = reader["name"].ToString();
                        userModel.Surname = reader["surname"].ToString();
                        userModel.Email = reader["email"].ToString();
                        userModel.Password = reader["password"].ToString();
                        userList.Add(userModel);
                    }
                }
            }
            return userList;
        }
    }
}
