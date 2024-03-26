using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    class CADProduct
    {
        private string constring { get; set; }
        public CADProduct()
        {
            // Obtener la cadena de conexión desde el archivo Web.config
            constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        [Obsolete]
        bool Create(ENProduct eNProduct)
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
        bool Update(ENProduct eNProduct)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(constring))
                {
                    sql.Open();
                    string query = "UPDATE Products SET name = @name, amount = @amount, price = @price, category = @category, creationDate = @creationDate WHERE code = @code";

                    using (SqlCommand sqlCMD = new SqlCommand(query, sql))
                    {
                        sqlCMD.Parameters.AddWithValue("@code", eNProduct.Code);
                        sqlCMD.Parameters.AddWithValue("@name", eNProduct.Name);
                        sqlCMD.Parameters.AddWithValue("@amount", eNProduct.Amount);
                        sqlCMD.Parameters.AddWithValue("@price", eNProduct.Price);
                        sqlCMD.Parameters.AddWithValue("@category", eNProduct.Category);
                        sqlCMD.Parameters.AddWithValue("@creationDate", eNProduct.CreationDate);

                        int sucess_row = sqlCMD.ExecuteNonQuery();
                        // si se actualizó al menos una fila
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
        bool Delete(ENProduct eNProduct)
        {
            try
            {
                using(SqlConnection sql = new SqlConnection(constring))
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
        bool read(ENProduct eNProduct)
        {
            return false;
        }
        bool readFirst(ENProduct eNProduct)
        {
            return false;
        }
        bool readNext(ENProduct eNProduct)
        {
            return false;
        }
        bool readPrev(ENProduct eNProduct)
        {
            return false;
        }

    }
}
