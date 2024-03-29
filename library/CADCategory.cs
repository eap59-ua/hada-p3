
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADCategory
    {
        private string constring { get; set; }

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        // Método para leer una categoría por su ID
        public bool Read(ENCategory en)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(constring))
                {
                    sql.Open();
                    string query = "SELECT * FROM Categories WHERE id = @id";

                    using (SqlCommand sqlCMD = new SqlCommand(query, sql))
                    {
                        sqlCMD.Parameters.AddWithValue("@id", en.Id);

                        SqlDataReader reader = sqlCMD.ExecuteReader();
                        if (reader.Read())
                        {
                            en.Id = (int)reader["id"];
                            en.Name = reader["name"].ToString();
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
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return false;
            }
        }

        // Método para leer todas las categorías
        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            try
            {
                using (SqlConnection sql = new SqlConnection(constring))
                {
                    sql.Open();
                    string query = "SELECT * FROM Categories";

                    using (SqlCommand sqlCMD = new SqlCommand(query, sql))
                    {
                        SqlDataReader reader = sqlCMD.ExecuteReader();
                        while (reader.Read())
                        {
                            ENCategory category = new ENCategory();
                            category.Id = (int)reader["id"];
                            category.Name = reader["name"].ToString();
                            categories.Add(category);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
            }

            return categories;
        }
    }
}
