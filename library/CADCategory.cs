using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace library
{
    public class CADCategory
    {
        // Cadena de conexión a la base de datos (debes configurarla según tu entorno)
        private readonly string _connectionString;

        // Constructor que inicializa la cadena de conexión
        public CADCategory(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para leer todas las categorías y devolverlas como una lista
        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "SELECT id, name FROM Categories";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string name = reader["name"].ToString();

                                ENCategory category = new ENCategory(id, name);
                                categories.Add(category);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading categories: {ex.Message}");
            }

            return categories;
        }

        // Otros métodos según sea necesario
    }
}
