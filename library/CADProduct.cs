using System;

using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {
        // cadena para la conexion, esta en web config
        private string constring { get; set; }
        public CADProduct()
        {
            // Obtener la cadena de conexión desde el archivo Web.config
            constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        // metodo para insertar los datos en products
        public bool Create(ENProduct eNProduct)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection())
                {
                    sql.ConnectionString = constring;
                    sql.Open();
                    string query = "INSERT INTO Products (code, name, amount, price, category, creationDate) VALUES (@code, @name, @amount, @price, @category, @creationDate)";

                    using (SqlCommand sqlCMD = new SqlCommand(query, sql))
                    {
                        sqlCMD.Parameters.AddWithValue("@code", eNProduct.Code);
                        sqlCMD.Parameters.AddWithValue("@name", eNProduct.Name);
                        sqlCMD.Parameters.AddWithValue("@amount", eNProduct.Amount);
                        sqlCMD.Parameters.AddWithValue("@price", eNProduct.Price);
                        sqlCMD.Parameters.AddWithValue("@category", eNProduct.Category);
                        sqlCMD.Parameters.AddWithValue("@creationDate", eNProduct.CreationDate);

                        int sucess_row = sqlCMD.ExecuteNonQuery();
                        // si se insertó al menos una fila
                        return sucess_row > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
        //actualizar la tabla products
        public bool Update(ENProduct eNProduct)
        {
            try
            {
                ///para conectarnos, deberemos de abrir la conexion
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    //la sentencia ssql necesaria: 
                    string query = "UPDATE Products SET name = @name, amount = @amount, price = @price, category = @category, creationDate = @creationDate WHERE code = @code";
                    using (SqlCommand sqlCMD = new SqlCommand(query, con))
                    {
                        sqlCMD.Parameters.AddWithValue("@name", eNProduct.Name);
                        sqlCMD.Parameters.AddWithValue("@amount", eNProduct.Amount);
                        sqlCMD.Parameters.AddWithValue("@price", eNProduct.Price);
                        sqlCMD.Parameters.AddWithValue("@category", eNProduct.Category);
                        sqlCMD.Parameters.AddWithValue("@creationDate", eNProduct.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        sqlCMD.Parameters.AddWithValue("@code", eNProduct.Code);

                        int successRows = sqlCMD.ExecuteNonQuery();
                        return successRows > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
        // borrar un producto 
        public bool Delete(ENProduct eNProduct)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(constring))
                {
                    sql.Open();
                    string query = "DELETE FROM Products WHERE code = @code";

                    using (SqlCommand sqlCMD = new SqlCommand(query, sql))
                    {
                        sqlCMD.Parameters.AddWithValue("@code", eNProduct.Code);
                        int sucess_row = sqlCMD.ExecuteNonQuery();
                        // si se eliminó al menos una fila
                        return sucess_row > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
        // leer segun el codigo
        public bool Read(ENProduct eNProduct)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(constring))
                {
                    sql.Open();
                    string query = "SELECT * FROM Products WHERE code = @code";

                    using (SqlCommand sqlCMD = new SqlCommand(query, sql))
                    {
                        // Agregar el parámetro @code
                        sqlCMD.Parameters.AddWithValue("@code", eNProduct.Code);

                        SqlDataReader reader = sqlCMD.ExecuteReader();
                        if (reader.Read())
                        {
                            eNProduct.Code = reader["code"].ToString();
                            eNProduct.Name = reader["name"].ToString();
                            eNProduct.Amount = (int)reader["amount"];

                            if (float.TryParse(reader["price"].ToString(), out float price))
                            {
                                eNProduct.Price = price;
                            }
                            else
                            {
                                eNProduct.Price = 0.0f;
                            }

                            eNProduct.Category = (int)reader["category"];
                            eNProduct.CreationDate = (DateTime)reader["creationDate"];
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
        //readfirst, el primer elemento de la tabla
        public bool ReadFirst(ENProduct eNProduct)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection())
                {
                    sql.ConnectionString = constring;
                    sql.Open();
                    string query = "SELECT TOP 1 * FROM Products;";

                    using (SqlCommand sqlCMD = new SqlCommand(query, sql))
                    {
                        SqlDataReader reader = sqlCMD.ExecuteReader();
                        if (reader.Read())
                        {
                            eNProduct.Code = reader["code"].ToString();
                            eNProduct.Name = reader["name"].ToString();
                            eNProduct.Amount = Convert.ToInt32(reader["amount"]);

                            if (float.TryParse(reader["price"].ToString(), out float price))
                            {
                                eNProduct.Price = price;
                            }
                            else
                            {
                                eNProduct.Price = 0.0f;

                            }

                            eNProduct.Category = (int)reader["category"];
                            eNProduct.CreationDate = (DateTime)reader["creationDate"];
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
        // leer el siguiente al dado
        public bool ReadNext(ENProduct eNProduct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    string query = $"SELECT TOP 1 * FROM Products WHERE id > (SELECT id FROM Products WHERE code = {eNProduct.Code})";

                    using (SqlCommand sqlCMD = new SqlCommand(query, con))
                    {
                        sqlCMD.Parameters.AddWithValue("@code", eNProduct.Code);
                        SqlDataReader reader = sqlCMD.ExecuteReader();

                        if (reader.Read())
                        {
                            eNProduct.Code = reader["code"].ToString();
                            eNProduct.Name = reader["name"].ToString();
                            eNProduct.Amount = (int)reader["amount"];
                            if (float.TryParse(reader["price"].ToString(), out float price))
                            {
                                eNProduct.Price = price;
                            }
                            else
                            {
                                eNProduct.Price = 0.0f;

                            }
                            eNProduct.Category = (int)reader["category"];
                            eNProduct.CreationDate = (DateTime)reader["creationDate"];

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
        //devuelve el anterior al dado
        public bool ReadPrev(ENProduct eNProduct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    string query = $"SELECT TOP 1 * FROM Products WHERE id < (SELECT id FROM Products WHERE code = @code) ORDER BY id DESC";

                    using (SqlCommand sqlCMD = new SqlCommand(query, con))
                    {
                        sqlCMD.Parameters.AddWithValue("@code", eNProduct.Code);
                        SqlDataReader reader = sqlCMD.ExecuteReader();

                        if (reader.Read())
                        {
                            eNProduct.Code = reader["code"].ToString();
                            eNProduct.Name = reader["name"].ToString();
                            eNProduct.Amount = (int)reader["amount"];
                            if (float.TryParse(reader["price"].ToString(), out float price))
                            {
                                eNProduct.Price = price;
                            }
                            else
                            {
                                eNProduct.Price = 0.0f;
                            }
                            eNProduct.Category = (int)reader["category"];
                            eNProduct.CreationDate = (DateTime)reader["creationDate"];

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
    }
}