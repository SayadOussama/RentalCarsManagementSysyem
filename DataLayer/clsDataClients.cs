using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsDataClients
    {
        public static int AddNewClientByID(int PersonID, int VehicalLicenseNumber, DateTime LicenseExpirationDate, DateTime AccountCreationDate, int CreatedByUserID)
        {
            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (var command = new SqlCommand("SP_AddNewClient", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@VehicalLicenseNumber", VehicalLicenseNumber);
                    command.Parameters.AddWithValue("@LicenseExpirationDate", LicenseExpirationDate);
                    command.Parameters.AddWithValue("@AccountCreationDate", AccountCreationDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    var outputIdParam = new SqlParameter("@NewClientID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }; command.Parameters.Add(outputIdParam);
                    Connection.Open();
                    command.ExecuteNonQuery();

                    return (int)outputIdParam.Value;
                }
                
            }


        }
        public static bool UpdateClientByClientID(int ClientID, int PersonID, int VehicalLicenseNumber, DateTime LicenseExpirationDate, DateTime AccountCreationDate, int CreatedByUserID)
        {

            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UpdateClient", Connection))
            {
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClientID", ClientID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@VehicalLicenseNumber", VehicalLicenseNumber);
                    command.Parameters.AddWithValue("@LicenseExpirationDate", LicenseExpirationDate);
                    command.Parameters.AddWithValue("@AccountCreationDate", AccountCreationDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    Connection.Open();
                    command.ExecuteNonQuery();
                    return true;

                }
            }
        }
        public static bool DeleteByID(int ClientID)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_DeleteClient", connection))
            {
                try { 
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClientID", ClientID);
                connection.Open();

                int rowsAffected = (int)command.ExecuteNonQuery();
                return (rowsAffected == 1);
                }
                 catch (Exception ex)
                {
                    return false; 
                }

            }
        }
        public static bool GetClientInfoByClientID(int ClientID, ref int PersonID, ref int VehicalLicenseNumber, ref DateTime LicenseExpirationDate, ref DateTime AccountCreationDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = "SELECT * FROM Clients WHERE ClientID= @ClientID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID ", ClientID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; PersonID = (int)reader["PersonID"];
                    VehicalLicenseNumber = (int)reader["VehicalLicenseNumber"];
                    LicenseExpirationDate = (DateTime)reader["LicenseExpirationDate"];
                    AccountCreationDate = (DateTime)reader["AccountCreationDate"];
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
        public static bool GetClientInfoByPersonID(ref int ClientID, int PersonID, ref int VehicalLicenseNumber, ref DateTime LicenseExpirationDate, ref DateTime AccountCreationDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = "SELECT * FROM Clients WHERE PersonID= @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID ", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    ClientID = (int)reader["ClientID"];
                    VehicalLicenseNumber = (int)reader["VehicalLicenseNumber"];
                    LicenseExpirationDate = (DateTime)reader["LicenseExpirationDate"];
                    AccountCreationDate = (DateTime)reader["AccountCreationDate"];
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
        public static bool GetClientInfoByVehicalLicenseNumber(ref int ClientID, ref int PersonID, int VehicalLicenseNumber, ref DateTime LicenseExpirationDate, ref DateTime AccountCreationDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = "SELECT * FROM Clients WHERE VehicalLicenseNumber= @VehicalLicenseNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicalLicenseNumber ", VehicalLicenseNumber);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; ClientID = (int)reader["ClientID"];
                    PersonID = (int)reader["PersonID"];
                    LicenseExpirationDate = (DateTime)reader["LicenseExpirationDate"];
                    AccountCreationDate = (DateTime)reader["AccountCreationDate"];
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
        public static bool ClientExistByID(int ClientID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM Clients  
             where ClientID = @ClientID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID ", ClientID);

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
        public static bool ClientExistByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM Clients  
             where PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID ", PersonID);

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
        public static bool ClientExistByVehicalLicenseNumber(int VehicalLicenseNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM Clients  
             where VehicalLicenseNumber = @VehicalLicenseNumber;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicalLicenseNumber ", VehicalLicenseNumber);

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
        public static DataTable GetAllCLients()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select Clients.ClientID,People.FirstName +' '+People.FirstName as FullName ,case WHEN People.Gender = 0 then 'Male'when People.Gender = 1 then 'Female' end as Gender, Clients.VehicalLicenseNumber , Clients.LicenseExpirationDate,
Clients.AccountCreationDate, Users.Username
from Clients
Inner Join People on Clients.PersonID = People.PersonID


Inner Join Users on CLients.CreatedByUserID = Users.UserID
Order by ClientID DESC  ";

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
               // return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}