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
using System.Runtime.Remoting.Messaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CRUDWinFormsMVP._Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        //Constructor
        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(ProductModel productModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO product (title, price, ammount, grade) VALUES(@title, @price, @ammount, @grade)";
                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = productModel.Title;
                command.Parameters.Add("@price", MySqlDbType.Int32).Value = productModel.Price;
                command.Parameters.Add("@ammount", MySqlDbType.Int32).Value = productModel.Ammount;
                command.Parameters.Add("@grade", MySqlDbType.Float).Value = 0;
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
                command.CommandText = "DELETE FROM product WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(ProductModel productModel)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE product set title = @title, price = @price, " +
                                      "ammount = @ammount, grade = @grade " +
                                      "WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = productModel.Id;
                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = productModel.Title;
                command.Parameters.Add("@price", MySqlDbType.Int32).Value = productModel.Price;
                command.Parameters.Add("@ammount", MySqlDbType.Int32).Value = productModel.Ammount;
                command.Parameters.Add("@grade", MySqlDbType.Float).Value = productModel.Grade;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var productList = new List<ProductModel>();
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM product ORDER BY id";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productModel = new ProductModel();
                        productModel.Id = Convert.ToInt32(reader["id"]);
                        productModel.Title = reader["title"].ToString();
                        productModel.Price = Convert.ToInt32(reader["price"]);
                        productModel.Ammount = Convert.ToInt32(reader["ammount"]);
                        productModel.Grade = GetGrade(productModel.Id);
                        productList.Add(productModel);
                    }
                }
            }
            return productList;
        }

        public IEnumerable<ProductModel> GetByValue(string value)
        {
            var productList = new List<ProductModel>();
            int productId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string productTitle = "%" + value + "%";
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM product " +
                                      "WHERE id = @id or title like @title" +
                                      "ORDER BY id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = productId;
                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = productTitle;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productModel = new ProductModel();
                        productModel.Id = Convert.ToInt32(reader["id"]);
                        productModel.Title = reader["title"].ToString();
                        productModel.Price = Convert.ToInt32(reader["price"]);
                        productModel.Ammount = Convert.ToInt32(reader["ammount"]);
                        productModel.Grade = GetGrade(productModel.Id);
                        productList.Add(productModel);
                    }
                }
            }
            return productList;
        }

        public float GetGrade(int id)
        {
            float grade = 0;
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT AVG(grade) FROM comment WHERE product_id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if(reader["AVG(grade)"] != System.DBNull.Value)
                        {
                            grade = Convert.ToSingle(reader["AVG(grade)"]);
                        }
                    }
                }
                return grade;
            }
        }
    }
}
