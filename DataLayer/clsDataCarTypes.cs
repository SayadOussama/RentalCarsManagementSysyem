using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsDataCarTypes
    {
        public static int AddNewCarType(string TypeName, int CreatedByUserID)
        {
            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (var command = new SqlCommand("SP_AddNewCarType", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TypeName", TypeName);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    var outputIdParam = new SqlParameter("@NewCarTypeID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    Connection.Open();
                    command.ExecuteNonQuery();

                    return (int)outputIdParam.Value;
                }
            }
        }
        public static bool UpdateCarTypeInfoByCarTypeID(int CarTypeID, string TypeName, int CreatedByUserID)
        {

            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UpdateCarType", Connection))
            {
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CarTypeID", CarTypeID);
                    command.Parameters.AddWithValue("@TypeName", TypeName);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    Connection.Open();
                    command.ExecuteNonQuery();
                    return true;

                }
            }

        }
        public static bool DeleteCarType(int CarTypeID)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_DeleteCarType", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CarTypeID", CarTypeID); connection.Open();

                int rowsAffected = (int)command.ExecuteScalar();
                return (rowsAffected == 1);


            }
        }
        public static bool GetCarTypeByID(int CarTypeID, ref string TypeName, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM CarTypes WHERE CarTypeID= @CarTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarTypeID ", CarTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; 
                    TypeName = (string)reader["TypeName"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool GetCarTypeByTypeName(ref int CarTypeID,  string TypeName, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM CarTypes WHERE TypeName= @TypeName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TypeName", TypeName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    CarTypeID = (int)reader["CarTypeID"];
                    
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool IsCarTypeExistByID(int CarTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM CarTypes  
             where CarTypeID = @CarTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarTypeID ", CarTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        public static DataTable GetAllByCarType()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM CarTypes  ";

  SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                //return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}