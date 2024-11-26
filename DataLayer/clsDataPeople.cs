using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsDataPeople
    {
        public static int AddNewPersonID(string NationalNO, string FirstName, string LastName, DateTime BirthDay, byte Gender, string PhoneNumber, string Address, string Email, int NationalCountryID, string ImagePath)
        {
            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (var command = new SqlCommand("SP_AddNEwPerson", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNO", NationalNO);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@BirthDay", BirthDay);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Address", Address);
                    if (Email != "" && Email != null)
                        command.Parameters.AddWithValue("@Email", Email);
                    else
                        command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                    command.Parameters.AddWithValue("@NationalCountryID", NationalCountryID);
                    if (ImagePath != "" && ImagePath != null)
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    else
                        command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

                    var outputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }; command.Parameters.Add(outputIdParam);
                    Connection.Open();
                    command.ExecuteNonQuery();

                    return (int)outputIdParam.Value;
                }
            }
        }
        public static bool UpdatePersonID(int PersonID, string NationalNO, string FirstName, string LastName, DateTime BirthDay, byte Gender, string PhoneNumber, string Address, string Email, int NationalCountryID, string ImagePath)
        {

            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UpdatePerson", Connection))
            {
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalNO", NationalNO);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@BirthDay", BirthDay);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Address", Address);
                    if (Email != "" && Email != null)
                        command.Parameters.AddWithValue("@Email", Email);
                    else
                        command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                    command.Parameters.AddWithValue("@NationalCountryID", NationalCountryID);
                    if (ImagePath != "" && ImagePath != null)
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    else
                        command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                    Connection.Open();
                    command.ExecuteNonQuery();
                    return true;

                }
            }
        }
        public static bool DeletePersonByID(int PersonID)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_DeletePerson", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID); connection.Open();

                int rowsAffected = (int)command.ExecuteNonQuery();
                return (rowsAffected == 1);


            }
        }
        public static bool IsPersonExistByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM People  
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
        public static bool GetPersonInfoByPersonID(int PersonID, ref string NationalNO, ref string FirstName, ref string LastName, ref DateTime BirthDay, ref byte Gender, ref string PhoneNumber, ref string address, ref string Email, ref int NationalCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE PersonID= @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID ", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    NationalNO = (string)reader["NationalNO"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    BirthDay = (DateTime)reader["BirthDay"];
                    Gender = (byte)reader["Gender"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    address = (string)reader["address"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalCountryID = (int)reader["NationalCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

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

        public static bool GetPersonInfoByFirstName(ref int PersonID, ref string NationalNO, string FirstName, ref string LastName, ref DateTime BirthDay, ref byte Gender, ref string PhoneNumber, ref string address, ref string Email, ref int NationalCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = "SELECT * FROM People WHERE FirstName= @FirstName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName ", FirstName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; PersonID = (int)reader["PersonID"];
                    NationalNO = (string)reader["NationalNO"];
                    LastName = (string)reader["LastName"];
                    BirthDay = (DateTime)reader["BirthDay"];
                    Gender = (byte)reader["Gender"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    address = (string)reader["address"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalCountryID = (int)reader["NationalCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

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

        public static bool GetPersonInfoByLastName(ref int PersonID, ref string NationalNO, ref string FirstName, string LastName, ref DateTime BirthDay, ref byte Gender, ref string PhoneNumber, ref string address, ref string Email, ref int NationalCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE LastName= @LastName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LastName ", LastName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; PersonID = (int)reader["PersonID"];
                    NationalNO = (string)reader["NationalNO"];
                    FirstName = (string)reader["FirstName"];
                    BirthDay = (DateTime)reader["BirthDay"];
                    Gender = (byte)reader["Gender"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    address = (string)reader["address"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalCountryID = (int)reader["NationalCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

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
        public static bool GetPersonInfoByNationalNo(ref int PersonID, string NationalNO, ref string FirstName, ref string LastName, ref DateTime BirthDay, ref byte Gender, ref string PhoneNumber, ref string address, ref string Email, ref int NationalCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE NationalNO= @NationalNO";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNO ", NationalNO);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    BirthDay = (DateTime)reader["BirthDay"];
                    Gender = (byte)reader["Gender"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    address = (string)reader["address"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalCountryID = (int)reader["NationalCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

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
        public static bool IsPersonExistByNationalNo(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM People  
             where NationalNo = @NationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo ", NationalNo);

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
        public static DataTable GetAllProple()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select PersonID , NationalNo , FirstName+ ' '+LastName as FullName ,CASE WHEN People.Gender = 0 THEN 'Male' WHEN People.Gender = 1 THEN 'Woman'  END AS Gender,PhoneNumber, Email ,Countries.CountryName
from People 
inner join  Countries on Countries.CountryID = People.NationalCountryID ";

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


            }
            finally
            {
                connection.Close();
            }
            return dt;
        }


    }
}
